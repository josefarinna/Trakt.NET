using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class CreateSmartListTests
    {
        private const string CreateSmartListUri = $"users/{Username}/smart-lists";
        private const string Username = "sean";
        private const string ListName = "new smart list";

        [Fact]
        public async Task TestCreateSmartList()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = ListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(CreateSmartListUri, responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.CreateSmartListAsync(Username, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestCreateSmartListWithFiltersAndPrivacy()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = ListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies,
                Privacy = TraktListPrivacy.Public,
                Filters = new TraktSmartListFilters
                {
                    Genres = ["action"]
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist_post_response.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(CreateSmartListUri, responseContent);

            TraktResponse<TraktSmartListPostResponse> response = await client.Users.CreateSmartListAsync(Username, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
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
        public async Task TestCreateSmartListThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = ListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(CreateSmartListUri, statusCode);
            Func<Task<TraktResponse<TraktSmartListPostResponse>>> act = () => client.Users.CreateSmartListAsync(Username, smartListPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestCreateSmartListArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(CreateSmartListUri, HttpStatusCode.Created);

            var smartListPost = new TraktSmartListPost
            {
                Name = ListName,
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            Func<Task<TraktResponse<TraktSmartListPostResponse>>> act = () => client.Users.CreateSmartListAsync(null!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreateSmartListAsync(string.Empty, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreateSmartListAsync("username with spaces", smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreateSmartListAsync(Username, null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
