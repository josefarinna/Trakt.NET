using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieWatchingUsersTests
    {
        private const string GetMovieWatchingUsersUriPrefix = "movies";
        private const string GetMovieWatchingUsersUriSuffix = "watching";
        private const string GetMovieWatchingUsersUriWithSlug = GetMovieWatchingUsersUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieWatchingUsersUriSuffix;
        private static readonly string GetMovieWatchingUsersUri = $"{GetMovieWatchingUsersUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieWatchingUsersUriSuffix}";

        [Theory]
        [InlineData(null, $"{GetMovieWatchingUsersUriPrefix}/293990/{GetMovieWatchingUsersUriSuffix}", "Movies\\moviewatchingusers.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetMovieWatchingUsersUriPrefix}/293990/{GetMovieWatchingUsersUriSuffix}", "Movies\\moviewatchingusers.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMovieWatchingUsersUriPrefix}/293990/{GetMovieWatchingUsersUriSuffix}?extended=full", "Movies\\moviewatchingusers.json")]
        public async Task TestGetMovieWatchingUsersWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(TestConstants.Movies.TraktMovieID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktUser> watchingUsers = response.Content;

            TraktUser watchingUser = watchingUsers[0];

            watchingUser.Username.ShouldBe("user1");
            watchingUser.Name.ShouldBe("User Name 1");

            watchingUser = watchingUsers[1];

            watchingUser.Username.ShouldBe("user2");
            watchingUser.Name.ShouldBe("User Name 2");
        }

        [Theory]
        [InlineData(null, GetMovieWatchingUsersUriWithSlug, "Movies\\moviewatchingusers.json")]
        public async Task TestGetMovieWatchingUsersWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(TestConstants.Movies.MovieSlug, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktUser> watchingUsers = response.Content;

            TraktUser watchingUser = watchingUsers[0];

            watchingUser.Username.ShouldBe("user1");
            watchingUser.Name.ShouldBe("User Name 1");

            watchingUser = watchingUsers[1];

            watchingUser.Username.ShouldBe("user2");
            watchingUser.Name.ShouldBe("User Name 2");
        }

        [Theory]
        [InlineData(null, GetMovieWatchingUsersUriWithSlug, "Movies\\moviewatchingusers.json")]
        public async Task TestGetMovieWatchingUsersWithIDs(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(TestConstants.Movies.MovieIDs, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktUser> watchingUsers = response.Content;

            TraktUser watchingUser = watchingUsers[0];

            watchingUser.Username.ShouldBe("user1");
            watchingUser.Name.ShouldBe("User Name 1");

            watchingUser = watchingUsers[1];

            watchingUser.Username.ShouldBe("user2");
            watchingUser.Name.ShouldBe("User Name 2");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieWatchingUsersWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieWatchingUsersUri, statusCode);

            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieWatchingUsersWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviewatchingusers.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieWatchingUsersUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(default(TraktMovieIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieWatchingUsersAsync(movieIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
