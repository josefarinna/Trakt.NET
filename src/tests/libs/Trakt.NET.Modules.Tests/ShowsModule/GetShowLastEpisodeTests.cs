using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowLastEpisodeTests
    {
        private const string GetShowLastEpisodeUriPrefix = "shows";
        private const string GetShowLastEpisodeUriSuffix = "last_episode";
        private static readonly string GetShowLastEpisodeUri = $"{GetShowLastEpisodeUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowLastEpisodeUriSuffix}";
        private static readonly string GetShowLastEpisodeUriWithSlug = $"{GetShowLastEpisodeUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowLastEpisodeUriSuffix}";
        private readonly TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetShowLastEpisodeWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithIDAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowLastEpisodeUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.TraktShowID, ExtendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUriWithSlug, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithSlugAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowLastEpisodeUriWithSlug}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowSlug, ExtendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithShowIDsTraktID()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.TraktShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithShowIDsSlug()
        {
            var showIDs = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUriWithSlug, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithShowIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUriWithSlug, responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithShowIDsAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowLastEpisodeUriWithSlug}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowIDs, ExtendedInfo, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktResponse<TraktEpisode> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Content!.Title.ShouldBe("Winter Is Coming");
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
        public async Task TestGetShowLastEpisodeThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUriWithSlug, statusCode);

            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowLastEpisodeWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowLastEpisodeUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Shows.GetShowLastEpisodeAsync(new TraktShowIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
