using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowVideosTests
    {
        private const string GetShowVideosUriPrefix = "shows";
        private const string GetShowVideosUriSuffix = "videos";
        private static readonly string GetShowVideosUri = $"{GetShowVideosUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowVideosUriSuffix}";
        private static readonly string GetShowVideosUriWithSlug = $"{GetShowVideosUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowVideosUriSuffix}";

        [Fact]
        public async Task TestGetShowVideosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowVideosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowVideosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktVideo> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktVideo> showVideos = response.Content!;

            showVideos[0].ShouldNotBeNull();
            showVideos[0].Title.ShouldBe("Game of Thrones | Official Series Trailer");
            showVideos[0].Url.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            showVideos[0].Site.ShouldBe("youtube");
            showVideos[0].Type.ShouldBe(TraktVideoType.Trailer);
            showVideos[0].Size.ShouldBe(1080U);
            showVideos[0].Official.ShouldBe(true);
            showVideos[0].Country.ShouldBe("us");
            showVideos[0].Language.ShouldBe("en");

            showVideos[1].ShouldNotBeNull();
            showVideos[1].Title.ShouldBe("Official Trailer");
            showVideos[1].Url.ShouldBe("https://youtube.com/watch?v=BpJYNVhGf1s");
            showVideos[1].Size.ShouldBe(720U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUri, statusCode);

            try
            {
                await client.Shows.GetShowVideosAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowVideosWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Shows.GetShowVideosAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowVideosAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
