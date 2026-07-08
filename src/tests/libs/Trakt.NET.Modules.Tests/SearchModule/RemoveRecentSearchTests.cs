using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class RemoveRecentSearchTests
    {
        private const string RemoveRecentSearchUri = "search/recent/remove";
        private const string Query = "batman";
        private const uint Id = 99U;
        private const TraktSearchRecentType Type = TraktSearchRecentType.Movie;

        [Fact]
        public async Task TestRemoveRecentSearch()
        {
            string requestContent = $"{{\"query\":\"{Query}\",\"id\":{Id},\"type\":\"movies\"}}";

            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveRecentSearchUri);
            ModuleTestUtility.AddMockExpectationResponse(client, RemoveRecentSearchUri, requestContent, HttpStatusCode.NoContent);

            TraktResponse response = await client.Search.RemoveRecentSearchAsync(Query, Id, Type, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
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
        public async Task TestRemoveRecentSearchThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveRecentSearchUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Search.RemoveRecentSearchAsync(Query, Id, Type, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRemoveRecentSearchThrowsArgumentExceptionForQuery()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveRecentSearchUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Search.RemoveRecentSearchAsync(null!, Id, Type, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.RemoveRecentSearchAsync(string.Empty, Id, Type, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.RemoveRecentSearchAsync("  ", Id, Type, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestRemoveRecentSearchThrowsArgumentExceptionForId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveRecentSearchUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Search.RemoveRecentSearchAsync(Query, 0, Type, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestRemoveRecentSearchThrowsArgumentExceptionForType()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveRecentSearchUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Search.RemoveRecentSearchAsync(Query, Id, TraktSearchRecentType.Unspecified, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
