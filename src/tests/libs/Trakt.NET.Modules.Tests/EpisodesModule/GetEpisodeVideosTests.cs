using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeVideosTests
    {
        private static readonly string GetEpisodeVideosUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/videos";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Fact]
        public async Task TestGetEpisodeVideosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodevideos.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Episodes.GetEpisodeVideosAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetEpisodeVideosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodevideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Episodes.GetEpisodeVideosAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetEpisodeVideosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodevideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Episodes.GetEpisodeVideosAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetEpisodeVideosWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodevideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Episodes.GetEpisodeVideosAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktVideo> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktVideo> seasonVideos = response.Content;

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
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodeVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeVideosUri, statusCode);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Episodes.GetEpisodeVideosAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeVideosWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeVideosUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Episodes.GetEpisodeVideosAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeVideosAsync(default(TraktShow)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeVideosAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeVideosAsync(0, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
