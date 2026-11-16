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

        [Theory]
        [InlineData(null, null, $"{GetMinimalWatchedMoviesUri}?extended=min")]
        [InlineData(Page, null, $"{GetMinimalWatchedMoviesUri}?extended=min&page=2")]
        [InlineData(null, Limit, $"{GetMinimalWatchedMoviesUri}?extended=min&limit=4")]
        [InlineData(Page, Limit, $"{GetMinimalWatchedMoviesUri}?extended=min&page=2&limit=4")]
        public async Task TestGetMinimalWatchedMovies(uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\getwatchedmoviesminimal.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, MoviesCount);

            TraktResponse<Dictionary<string, List<string>>> response = await client.Users.GetMinimalWatchedMoviesAsync(Username, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.Content["94024"].ShouldNotBeNull();
            response.Content["94024"].Count.ShouldBe(1);
            response.Content["94024"][0].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMinimalWatchedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
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
