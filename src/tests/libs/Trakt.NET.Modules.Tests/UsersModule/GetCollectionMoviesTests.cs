using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetCollectionMoviesTests
    {
        private const string GetCollectionMoviesUri = $"users/{Username}/collection/movies";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint MoviesCount = 2U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, $"{GetCollectionMoviesUri}?page=2&limit=4")]
        [InlineData(ExtendedInfo, $"{GetCollectionMoviesUri}?extended=full&page=2&limit=4")]
        public async Task TestGetCollectionMovies(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, Page, 1, Limit, MoviesCount);

            TraktPagedResponse<TraktCollectionMovie> response = await client.Users.GetCollectionMoviesAsync(Username, extendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, MoviesCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktCollectionMovie> response = await client.Users.GetCollectionMoviesAsync(Username, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");
            
            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/collection/movies?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, MoviesCount);
            
            TraktPagedResponse<TraktCollectionMovie> response = await client.Users.GetCollectionMoviesAsync("me", null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, MoviesCount);

            TraktPagedResponse<TraktCollectionMovie> response =
                await client.Users.GetCollectionMoviesAsync(Username, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCollectionMoviesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MoviesCount);

            TraktPagedResponse<TraktCollectionMovie> response =
                await client.Users.GetCollectionMoviesAsync(Username, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCollectionMoviesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MoviesCount);

            TraktPagedResponse<TraktCollectionMovie> response =
                await client.Users.GetCollectionMoviesAsync(Username, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCollectionMoviesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, MoviesCount);

            TraktPagedResponse<TraktCollectionMovie> response =
                await client.Users.GetCollectionMoviesAsync(Username, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCollectionMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MoviesCount);

            TraktPagedResponse<TraktCollectionMovie> response =
                await client.Users.GetCollectionMoviesAsync(Username, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MoviesCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCollectionMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\usercollection_movies.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, MoviesCount);

            TraktPagedResponse<TraktCollectionMovie> response =
                await client.Users.GetCollectionMoviesAsync(Username, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, MoviesCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)MoviesCount);
            response.ItemCount.ShouldBe(MoviesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetCollectionMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCollectionMoviesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktCollectionMovie>>> act = () => client.Users.GetCollectionMoviesAsync(Username, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetCollectionMoviesThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCollectionMoviesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktCollectionMovie>>> act = () => client.Users.GetCollectionMoviesAsync(Username, null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetCollectionMoviesAsync(Username, null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
