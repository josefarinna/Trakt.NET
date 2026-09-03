using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetMinimalWatchedMoviesTests
    {
        private const string GetMinimalWatchedMoviesUri = $"users/{Username}/watched/movies";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint MoviesCount = 1U;

        [Fact]
        public async Task TestGetMinimalWatchedMovies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedmoviesminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedMoviesUri}?extended=min", responseContent, Page, 1, Limit, MoviesCount);

            TraktResponse<Dictionary<string, List<string>>> response = await client.Users.GetMinimalWatchedMoviesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.Content["94024"].ShouldNotBeNull();
            response.Content["94024"].Count.ShouldBe(1);
            response.Content["94024"][0].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedMoviesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedmoviesminimal.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetMinimalWatchedMoviesUri}?extended=min", responseContent, Page, 1, Limit, MoviesCount);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<Dictionary<string, List<string>>> response = await client.Users.GetMinimalWatchedMoviesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.Content["94024"].ShouldNotBeNull();
            response.Content["94024"].Count.ShouldBe(1);
            response.Content["94024"][0].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedMoviesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedmoviesminimal.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/watched/movies?extended=min", responseContent, Page, 1, Limit, MoviesCount);

            TraktResponse<Dictionary<string, List<string>>> response = await client.Users.GetMinimalWatchedMoviesAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.Content["94024"].ShouldNotBeNull();
            response.Content["94024"].Count.ShouldBe(1);
            response.Content["94024"][0].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedMoviesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedmoviesminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedMoviesUri}?extended=min&page={Page}", responseContent, Page, 1, Limit, MoviesCount);

            TraktResponse<Dictionary<string, List<string>>> response = await client.Users.GetMinimalWatchedMoviesAsync(Username, Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedMoviesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedmoviesminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedMoviesUri}?extended=min&limit={Limit}", responseContent, Page, 1, Limit, MoviesCount);

            TraktResponse<Dictionary<string, List<string>>> response = await client.Users.GetMinimalWatchedMoviesAsync(Username, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetMinimalWatchedMoviesWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedmoviesminimal.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetMinimalWatchedMoviesUri}?extended=min&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, MoviesCount);

            TraktResponse<Dictionary<string, List<string>>> response = await client.Users.GetMinimalWatchedMoviesAsync(Username, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
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
        public async Task TestGetMinimalWatchedMoviesThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMinimalWatchedMoviesUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, List<string>>>>> act = () => client.Users.GetMinimalWatchedMoviesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null!)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("user name")]
        public async Task TestGetMinimalWatchedMoviesThrowsValidationException(string? username)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMinimalWatchedMoviesUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, List<string>>>>> act = () => client.Users.GetMinimalWatchedMoviesAsync(username!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
