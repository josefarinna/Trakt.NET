using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeStatisticsTests
    {
        private readonly string GetEpisodeStatisticsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/stats";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Fact]
        public async Task TestGetEpisodeStatistics()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeStatisticsUri, responseContent);
            
            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktEpisodeStatistics responseValue = response.Content;

            responseValue.Watchers.ShouldBe(233273U);
            responseValue.Plays.ShouldBe(303464U);
            responseValue.Collectors.ShouldBe(92759U);
            responseValue.Comments.ShouldBe(4U);
            responseValue.Lists.ShouldBe(418U);
            responseValue.Votes.ShouldBe(3919U);
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeStatisticsUri, responseContent);

            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithShowIdsTraktID()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.TraktShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeStatisticsUri, responseContent);

            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(showIds, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithShowIdsSlug()
        {
            var showIds = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/stats",
                responseContent);

            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(showIds, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithShowIds()
        {

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/stats",
                responseContent);

            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/stats",
                responseContent);

            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(show, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
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
        public async Task TestGetEpisodeStatisticsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeStatisticsUri, statusCode);

            Func<Task<TraktResponse<TraktEpisodeStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeStatisticsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktEpisodeStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(default(TraktShow)!, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(0, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
