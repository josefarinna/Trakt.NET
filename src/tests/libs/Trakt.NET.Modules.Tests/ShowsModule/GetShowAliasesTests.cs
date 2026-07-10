using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowAliasesTests
    {
        private const string GetShowAliasesUri = $"shows/{TestConstants.Shows.ShowID}/aliases";
        private const string GetShowAliasesUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/aliases";
        private const int ListItemCount = 3;

        [Fact]
        public async Task TestGetShowAliasesWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showaliases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUri, responseContent);

            TraktListResponse<TraktShowAlias> response = await client.Shows.GetShowAliasesAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowAliasesWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showaliases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUriWithSlug, responseContent);

            TraktListResponse<TraktShowAlias> response = await client.Shows.GetShowAliasesAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowAliasesWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showaliases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUriWithSlug, responseContent);

            TraktListResponse<TraktShowAlias> response = await client.Shows.GetShowAliasesAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

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
        public async Task TestGetShowAliasesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUri, statusCode);

            Func<Task<TraktListResponse<TraktShowAlias>>> act = () => client.Shows.GetShowAliasesAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowAliasesWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktShowAlias>>> act = () => client.Shows.GetShowAliasesAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowAliasesAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
