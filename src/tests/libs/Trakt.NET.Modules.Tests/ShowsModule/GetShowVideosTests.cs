using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowVideosTests
    {
        private const string GetShowVideosUri = $"shows/{TestConstants.Shows.ShowID}/videos";
        private const string GetShowVideosUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/videos";
        private const int ListItemCount = 2;

        [Fact]
        public async Task TestGetShowVideosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowVideosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowVideosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showvideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Shows.GetShowVideosAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetShowVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUri, statusCode);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Shows.GetShowVideosAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowVideosWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowVideosUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Shows.GetShowVideosAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowVideosAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
