using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class AddSavedFilterTests
    {
        private const string URIPath = "users/saved_filters";

        [Fact]
        public async Task TestAddSavedFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usersavedfilterpostresponse.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(URIPath, responseContent);

            var post = new TraktUserSavedFilterPost
            {
                Name = "Movies: IMDB + TMDB ratings",
                Url = "/movies/recommended/weekly?imdb_ratings=6.9-10.0"
            };

            TraktResponse<TraktUserSavedFilterPostResponse> response = await client.Users.AddSavedFilterAsync(post, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Added.ShouldNotBeNull();
            response.Content.Added.Count.ShouldBe(1);
            response.Content.Skipped.ShouldNotBeNull();
            response.Content.Skipped.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestAddSavedFilterWithNameAndUrl()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usersavedfilterpostresponse.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(URIPath, responseContent);

            TraktResponse<TraktUserSavedFilterPostResponse> response = await client.Users.AddSavedFilterAsync(
                "Movies: IMDB + TMDB ratings", "/movies/recommended/weekly?imdb_ratings=6.9-10.0", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Added.ShouldNotBeNull();
            response.Content.Added.Count.ShouldBe(1);
            response.Content.Skipped.ShouldNotBeNull();
            response.Content.Skipped.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestAddSavedFilters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usersavedfilterpostresponse.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(URIPath, responseContent);

            var posts = new List<TraktUserSavedFilterPost>
            {
                new()
                {
                    Name = "Movies: IMDB + TMDB ratings",
                    Url = "/movies/recommended/weekly?imdb_ratings=6.9-10.0"
                }
            };

            TraktResponse<TraktUserSavedFilterPostResponse> response = await client.Users.AddSavedFiltersAsync(posts, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Added.ShouldNotBeNull();
            response.Content.Added.Count.ShouldBe(1);
            response.Content.Skipped.ShouldNotBeNull();
            response.Content.Skipped.Count.ShouldBe(1);
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
        public async Task TestAddSavedFilterThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(URIPath, statusCode);

            var post = new TraktUserSavedFilterPost
            {
                Name = "Test Filter",
                Url = "/movies/recommended/weekly"
            };

            Func<Task<TraktResponse<TraktUserSavedFilterPostResponse>>> act = () => client.Users.AddSavedFilterAsync(post, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddSavedFilterArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(URIPath, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktUserSavedFilterPostResponse>>> act = () => client.Users.AddSavedFilterAsync(default(TraktUserSavedFilterPost)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.AddSavedFiltersAsync(null!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
