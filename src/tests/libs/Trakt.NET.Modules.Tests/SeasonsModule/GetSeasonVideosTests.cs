using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonVideosTests
    {
        private const string GetSeasonVideosUriPrefix = "shows";
        private const string GetSeasonVideosUriSuffix = "videos";
        private const uint SeasonNumber = 1U;
        private static readonly string GetSeasonVideosUri = $"{GetSeasonVideosUriPrefix}/{TestConstants.Shows.ShowID}/seasons/1/{GetSeasonVideosUriSuffix}";
        private static readonly string GetSeasonVideosUriWithSlug = $"{GetSeasonVideosUriPrefix}/{TestConstants.Shows.ShowSlug}/seasons/1/{GetSeasonVideosUriSuffix}";

        [Fact]
        public async Task TestGetSeasonVideosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.ShowID, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonVideosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.ShowSlug, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonVideosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktVideo> seasonVideos = response.Content!;

            seasonVideos[0].ShouldNotBeNull();
            seasonVideos[0].Title.ShouldBe("Game of Thrones | Official Series Trailer");
            seasonVideos[0].Url.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            seasonVideos[0].Site.ShouldBe("youtube");
            seasonVideos[0].Type.ShouldBe(TraktVideoType.Trailer);
            seasonVideos[0].Size.ShouldBe(1080U);
            seasonVideos[0].Official.ShouldBe(true);
            seasonVideos[0].Country.ShouldBe("us");
            seasonVideos[0].Language.ShouldBe("en");

            seasonVideos[1].ShouldNotBeNull();
            seasonVideos[1].Title.ShouldBe("Official Trailer");
            seasonVideos[1].Url.ShouldBe("https://youtube.com/watch?v=BpJYNVhGf1s");
            seasonVideos[1].Size.ShouldBe(720U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetSeasonVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, statusCode);

            try
            {
                await client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.ShowID, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetSeasonVideosWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Seasons.GetSeasonVideosAsync(default(TraktShowIDs), SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var ShowIDs = new TraktShowIDs();
            act = () => client.Seasons.GetSeasonVideosAsync(ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
