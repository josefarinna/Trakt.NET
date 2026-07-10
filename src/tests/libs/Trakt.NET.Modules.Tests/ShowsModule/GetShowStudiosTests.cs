using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowStudiosTests
    {
        private const string GetShowStudiosUri = $"shows/{TestConstants.Shows.ShowID}/studios";
        private const string GetShowStudiosUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/studios";
        private const int ListItemCount = 2;

        [Fact]
        public async Task TestGetShowStudiosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUri, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowStudiosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowStudiosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, responseContent);

            TraktListResponse<TraktStudio> response = await client.Shows.GetShowStudiosAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

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
        public async Task TestGetShowStudiosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUri, statusCode);

            Func<Task<TraktListResponse<TraktStudio>>> act = () => client.Shows.GetShowStudiosAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowStudiosWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowStudiosUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktStudio>>> act = () => client.Shows.GetShowStudiosAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowStudiosAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
