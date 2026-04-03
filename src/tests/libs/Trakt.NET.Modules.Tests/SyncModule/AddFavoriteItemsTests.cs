using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class AddFavoriteItemsTests
    {
        private const string AddFavoriteItemsUri = "sync/favorites";

        [Fact]
        public async Task TestAddFavoriteItems()
        {
            var content = new TraktSyncFavoritesPost
            {
                Movies = [new TraktSyncFavoritesPostMovie { IDs = new TraktMovieIDs { Trakt = 1U } }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavoritespostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddFavoriteItemsUri, responseContent, null, null, null, null);
            TraktResponse<TraktSyncFavoritesPostResponse> response = await client.Sync.AddFavoriteItemsAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSyncFavoritesPostResponse responseValue = response.Content;

            responseValue.Added.ShouldNotBeNull();
            responseValue.Added.Movies.ShouldBe(1U);
            responseValue.Added.Shows.ShouldBe(2U);

            responseValue.Existing.ShouldNotBeNull();
            responseValue.Existing.Movies.ShouldBe(3U);
            responseValue.Existing.Shows.ShouldBe(4U);

            responseValue.NotFound.ShouldNotBeNull();

            responseValue.NotFound.Movies.ShouldNotBeNull();
            responseValue.NotFound.Movies.Count.ShouldBe(1);

            TraktSyncFavoritesPostMovie[] notFoundMovies = [.. responseValue.NotFound.Movies];

            notFoundMovies[0].ShouldNotBeNull();
            notFoundMovies[0].IDs.ShouldNotBeNull();
            notFoundMovies[0].IDs!.Trakt.ShouldBeNull();
            notFoundMovies[0].IDs!.Slug.ShouldBeNull();
            notFoundMovies[0].IDs!.IMDB.ShouldBe("tt0000111");
            notFoundMovies[0].IDs!.TMDB.ShouldBeNull();

            responseValue.NotFound.Shows.ShouldNotBeNull();
            responseValue.NotFound.Shows.Count.ShouldBe(1);

            TraktSyncFavoritesPostShow[] notFoundShows = [.. responseValue.NotFound.Shows];

            notFoundShows[0].ShouldNotBeNull();
            notFoundShows[0].IDs.ShouldNotBeNull();
            notFoundShows[0].IDs!.Trakt.ShouldBeNull();
            notFoundShows[0].IDs!.Slug.ShouldBeNull();
            notFoundShows[0].IDs!.IMDB.ShouldBe("tt0000222");
            notFoundShows[0].IDs!.TVDB.ShouldBeNull();
            notFoundShows[0].IDs!.TMDB.ShouldBeNull();
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
        public async Task TestAddFavoriteItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddFavoriteItemsUri, statusCode);

            var content = new TraktSyncFavoritesPost
            {
                Movies = [new TraktSyncFavoritesPostMovie { IDs = new TraktMovieIDs { Trakt = 1U } }]
            };

            Func<Task<TraktResponse<TraktSyncFavoritesPostResponse>>> act = () => client.Sync.AddFavoriteItemsAsync(content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddFavoriteItemsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddFavoriteItemsUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktSyncFavoritesPostResponse>>> act = () => client.Sync.AddFavoriteItemsAsync(default, TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var content = new TraktSyncFavoritesPost();
            act = () => client.Sync.AddFavoriteItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [];
            act = () => client.Sync.AddFavoriteItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [ new TraktSyncFavoritesPostMovie {
                Notes = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
            } ];
            act = () => client.Sync.AddFavoriteItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
