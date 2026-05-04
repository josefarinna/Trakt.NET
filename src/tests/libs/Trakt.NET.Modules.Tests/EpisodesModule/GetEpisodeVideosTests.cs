using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeVideosTests
    {
        private static readonly string GetEpisodeVideosUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/videos";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Fact]
        public async Task TestGetEpisodeVideos()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodevideos.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Episodes.GetEpisodeVideosAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetEpisodeVideosWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodevideos.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Episodes.GetEpisodeVideosAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetEpisodeVideosWithShowIDsTraktID()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.TraktShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodevideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Episodes.GetEpisodeVideosAsync(showIDs, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetEpisodeVideosWithShowIDsSlug()
        {
            var showIDs = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodevideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Episodes.GetEpisodeVideosAsync(showIDs, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetEpisodeVideosWithShowIDs()
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
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetEpisodeVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeVideosUri, statusCode);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Episodes.GetEpisodeVideosAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
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
