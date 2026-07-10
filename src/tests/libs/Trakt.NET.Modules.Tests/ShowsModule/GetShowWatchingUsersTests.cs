using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowWatchingUsersTests
    {
        private const string GetShowWatchingUsersUri = $"shows/{TestConstants.Shows.ShowID}/watching";
        private const string GetShowWatchingUsersUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/watching";
        private const int ListItemCount = 2;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetShowWatchingUsersWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithIDAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowWatchingUsersUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.TraktShowID, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithSlugAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowWatchingUsersUriWithSlug}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowSlug, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithIDsAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showwatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowWatchingUsersUriWithSlug}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktListResponse<TraktUser> response = await client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowIDs, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
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
        public async Task TestGetShowWatchingUsersThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, statusCode);

            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchingUsersWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchingUsersUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowWatchingUsersAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
