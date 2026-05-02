using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonVideosVideosTests
    {
        private static readonly string GetSeasonVideosUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/videos";
        private readonly string ShowID = $"{TestConstants.Shows.ShowID}";
        private const uint SeasonNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetSeasonVideos()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(ShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonVideosWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.ShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonVideosWithShowIDsTraktID()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(showIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonVideosWithShowIDsSlug()
        {
            var showIDs = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(showIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonVideosWithShowIDs()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID,
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(showIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonVideosWithShow()
        {
            var show = new TraktShow
            {
                IDs = new TraktShowIDs
                {
                    Trakt = TestConstants.Shows.ShowID,
                    Slug = TestConstants.Shows.ShowSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/videos", responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(show, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonVideosWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonvideos.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonVideosUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktListResponse<TraktVideo> response = await client.Seasons.GetSeasonVideosAsync(ShowID, SeasonNr, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
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
        public async Task TestGetSeasonVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, statusCode);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Seasons.GetSeasonVideosAsync(TestConstants.Shows.ShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonVideosWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonVideosUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktVideo>>> act =
                () => client.Seasons.GetSeasonVideosAsync(default(TraktShowIDs)!, SeasonNr);

            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonVideosAsync(default(TraktShow)!, SeasonNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonVideosAsync(new TraktShowIDs(), SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonVideosAsync(0, SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
