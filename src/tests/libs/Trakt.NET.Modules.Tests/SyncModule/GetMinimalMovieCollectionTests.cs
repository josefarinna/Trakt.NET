using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetMinimalMovieCollectionTests
    {
        private const string GetMinimalMovieCollectionUri = "sync/collection/minimal/movies";

        [Fact]
        public async Task TestGetMinimalMovieCollection()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\getsynccollectionminimalmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMinimalMovieCollectionUri, responseContent);
            TraktResponse<Dictionary<string, string>> response = await client.Sync.GetMinimalMovieCollectionAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
            response.Content["batman-begins-2005"].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Content["the-dark-knight-2008"].ShouldBe("2014-10-11T17:00:54.000Z");
        }

        [Fact]
        public async Task TestGetMinimalMovieCollectionWithAvailableOn()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\getsynccollectionminimalmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMinimalMovieCollectionUri}?available_on=netflix", responseContent);
            TraktResponse<Dictionary<string, string>> response = await client.Sync.GetMinimalMovieCollectionAsync("netflix", TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        public async Task TestGetMinimalMovieCollectionThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMinimalMovieCollectionUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Sync.GetMinimalMovieCollectionAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
