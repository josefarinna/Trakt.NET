using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeWatchingUsersTests
    {
        private readonly string GetEpisodeWatchingUsersUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/watching";
        private readonly string ShowID = $"{TestConstants.Shows.ShowID}";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetEpisodeWatchingUsers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodewatchingusers.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeWatchingUsersUri, responseContent);
            
            TraktListResponse<TraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeWatchingUsersWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodewatchingusers.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeWatchingUsersUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeWatchingUsersWithShowIdsTraktID()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodewatchingusers.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeWatchingUsersUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeWatchingUsersWithShowIdsSlug()
        {
            var showIds = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodewatchingusers.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/watching",
                responseContent);

            TraktListResponse<TraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeWatchingUsersWithShowIds()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID,
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodewatchingusers.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/watching",
                responseContent);

            TraktListResponse<TraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeWatchingUsersWithShow()
        {
            var show = new TraktShow
            {
                IDs = new TraktShowIDs
                {
                    Trakt = TestConstants.Shows.ShowID,
                    Slug = TestConstants.Shows.ShowSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodewatchingusers.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/watching",
                responseContent);

            TraktListResponse<TraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeWatchingUsersWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodewatchingusers.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetEpisodeWatchingUsersUri}?extended={ExtendedInfo.ToURI()}",
                responseContent);

            TraktListResponse<TraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(ShowID, SeasonNr, EpisodeNr, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
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
        public async Task TestGetEpisodeWatchingUsersThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeWatchingUsersUri, statusCode);

            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeWatchingUsersThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeWatchingUsersUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeWatchingUsersAsync(default(TraktShow)!, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeWatchingUsersAsync(new TraktShowIDs(), SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeWatchingUsersAsync(0, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
