using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowStudiosTests
    {
        private const string GetShowStudiosUriPrefix = "shows";
        private const string GetShowStudiosUriSuffix = "studios";
        private static readonly string GetShowStudiosUri = $"{GetShowStudiosUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowStudiosUriSuffix}";
        private static readonly string GetShowStudiosUriWithSlug = $"{GetShowStudiosUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowStudiosUriSuffix}";

        [Fact]
        public async Task TestGetShowStudiosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUri, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowStudiosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowStudiosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktStudio> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktStudio> showStudios = response.Content!;

            showStudios[0].Name.ShouldBe("Marvel Studios");
            showStudios[0].Country.ShouldBe("us");
            showStudios[0].IDs.ShouldNotBeNull();
            showStudios[0].IDs!.Trakt.ShouldBe(181U);
            showStudios[0].IDs!.Slug.ShouldBe("marvel-studios");
            showStudios[0].IDs!.TMDB.ShouldBe(420U);

            showStudios[1].Name.ShouldBe("Kevin Feige Productions");
            showStudios[1].Country.ShouldBe("us");
            showStudios[1].IDs.ShouldNotBeNull();
            showStudios[1].IDs!.Trakt.ShouldBe(126097U);
            showStudios[1].IDs!.Slug.ShouldBe("kevin-feige-productions");
            showStudios[1].IDs!.TMDB.ShouldBe(176762U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetShowStudiosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUri, statusCode);

            try
            {
                await client.Shows.GetShowStudiosAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowStudiosWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktStudio>>> act = () => client.Shows.GetShowStudiosAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowStudiosAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
