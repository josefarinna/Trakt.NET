using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class RemoveFavoriteItemsTests
    {
        private const string RemoveFavoritesUri = "sync/favorites/remove";

        [Fact]
        public async Task TestRemoveFavoriteItems()
        {
            var content = new TraktSyncFavoritesRemovePost
            {
                Movies = [new TraktSyncRemovePostMovie { IDs = new TraktMovieIDs { Trakt = 1U } }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavoritesremovepostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveFavoritesUri, responseContent, null, null, null, null);
            TraktResponse<TraktSyncFavoritesRemovePostResponse> response = await client.Sync.RemoveFavoriteItemsAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSyncFavoritesRemovePostResponse responseValue = response.Content;

            responseValue.Deleted.ShouldNotBeNull();
            responseValue.Deleted.Movies.ShouldBe(1U);
            responseValue.Deleted.Shows.ShouldBe(2u);

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
        public async Task TestRemoveFavoriteItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveFavoritesUri, statusCode);

            var content = new TraktSyncFavoritesRemovePost
            {
                Movies = [new TraktSyncRemovePostMovie { IDs = new TraktMovieIDs { Trakt = 1U } }]
            };

            Func<Task<TraktResponse<TraktSyncFavoritesRemovePostResponse>>> act = () => client.Sync.RemoveFavoriteItemsAsync(content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRemoveFavoriteItemsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveFavoritesUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktSyncFavoritesRemovePostResponse>>> act = () => client.Sync.RemoveFavoriteItemsAsync(default, TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var content = new TraktSyncFavoritesRemovePost();
            act = () => client.Sync.RemoveFavoriteItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [];
            act = () => client.Sync.RemoveFavoriteItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

        }
    }
}
