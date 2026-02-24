using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowRelatedShowsTests
    {
        private const string GetShowRelatedShowsUriPrefix = "shows";
        private const string GetShowRelatedShowsUriSuffix = "related";
        private const string GetShowRelatedShowsUriWithSlug = GetShowRelatedShowsUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/" + GetShowRelatedShowsUriSuffix;
        private static readonly string GetShowRelatedShowsUri = $"{GetShowRelatedShowsUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowRelatedShowsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, GetShowRelatedShowsUriWithSlug, "Shows\\showrelatedshows.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetShowRelatedShowsUriWithSlug, "Shows\\showrelatedshows.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetShowRelatedShowsUriWithSlug}?extended=full", "Shows\\showrelatedshows.json")]
        [InlineData(null, 4U, null, $"{GetShowRelatedShowsUriWithSlug}?page=4", "Shows\\showrelatedshows.json")]
        [InlineData(null, null, 20U, $"{GetShowRelatedShowsUriWithSlug}?limit=20", "Shows\\showrelatedshows.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetShowRelatedShowsUriWithSlug}?extended=full&page=4&limit=20", "Shows\\showrelatedshows.json")]
        public async Task TestGetShowRelatedShows(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktShow> response = await client.Shows.GetShowRelatedShowsAsync(TestConstants.Shows.ShowSlug, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            ValidateResponse(response, page ?? 1U, limit ?? 10U);
        }

        [Fact]
        public async Task TestGetShowRelatedShowsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showrelatedshows.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowRelatedShowsUri, responseContent);

            TraktPagedResponse<TraktShow> response = await client.Shows.GetShowRelatedShowsAsync(TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        [Fact]
        public async Task TestGetShowRelatedShowsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showrelatedshows.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowRelatedShowsUriWithSlug, responseContent);

            TraktPagedResponse<TraktShow> response = await client.Shows.GetShowRelatedShowsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response, null, null);
        }

        private static void ValidateResponse(TraktPagedResponse<TraktShow> response, uint? page, uint? limit)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page);
            response.Limit.ShouldBe(limit);

            IReadOnlyList<TraktShow> shows = response.Content!;

            // Primer show relacionado: House of the Dragon
            shows[0].ShouldNotBeNull();
            shows[0].Title.ShouldBe("House of the Dragon");
            shows[0].Year.ShouldBe(2022U);
            shows[0].IDs!.Trakt.ShouldBe(154574U);
            shows[0].IDs!.Slug.ShouldBe("house-of-the-dragon");

            // Segundo show relacionado: The Witcher
            shows[1].ShouldNotBeNull();
            shows[1].Title.ShouldBe("The Witcher");
            shows[1].Year.ShouldBe(2019U);
            shows[1].IDs!.Trakt.ShouldBe(138163U);
            shows[1].IDs!.Slug.ShouldBe("the-witcher-2019");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowRelatedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowRelatedShowsUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowRelatedShowsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowRelatedShowsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showrelatedshows.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowRelatedShowsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowRelatedShowsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
