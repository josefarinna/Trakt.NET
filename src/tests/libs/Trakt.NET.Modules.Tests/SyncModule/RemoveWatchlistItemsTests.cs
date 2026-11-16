using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class RemoveWatchlistItemsTests
    {
        private const string RemoveWatchlistItemsUri = "sync/watchlist/remove";

        [Fact]
        public async Task TestRemoveWatchlistItems()
        {
            var content = new TraktSyncWatchlistRemovePost
            {
                Movies = [new TraktSyncRemovePostMovie { IDs = new TraktMovieIDs { Trakt = 1U } }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlistremovepostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveWatchlistItemsUri, responseContent);
            TraktResponse<TraktSyncWatchlistRemovePostResponse> response = await client.Sync.RemoveWatchlistItemsAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSyncWatchlistRemovePostResponse responseValue = response.Content;

            responseValue.Deleted.ShouldNotBeNull();
            responseValue.Deleted.Movies.ShouldBe(1U);
            responseValue.Deleted.Episodes.ShouldBe(2U);
            responseValue.Deleted.Shows.ShouldBe(1U);
            responseValue.Deleted.Seasons.ShouldBe(1U);

            responseValue.NotFound.ShouldNotBeNull();
            responseValue.NotFound.Movies.ShouldNotBeNull();
            responseValue.NotFound.Movies.Count.ShouldBe(1);

            TraktPostResponseNotFoundMovie[] movies = responseValue.NotFound.Movies.ToArray();

            movies[0].IDs.ShouldNotBeNull();
            movies[0].IDs!.Trakt.ShouldBeNull();
            movies[0].IDs!.Slug.ShouldBeNullOrEmpty();
            movies[0].IDs!.IMDB.ShouldBe("tt0000111");
            movies[0].IDs!.TMDB.ShouldBeNull();

            responseValue.NotFound.Shows.ShouldNotBeNull();
            responseValue.NotFound.Shows.Count.ShouldBe(0);
            responseValue.NotFound.Seasons.ShouldNotBeNull();
            responseValue.NotFound.Seasons.Count.ShouldBe(0);
            responseValue.NotFound.Episodes.ShouldNotBeNull();
            responseValue.NotFound.Episodes.Count.ShouldBe(0);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestRemoveWatchlistItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveWatchlistItemsUri, statusCode);

            var content = new TraktSyncWatchlistRemovePost
            {
                Movies = [new TraktSyncRemovePostMovie { IDs = new TraktMovieIDs { Trakt = 1U } }]
            };

            Func<Task<TraktResponse<TraktSyncWatchlistRemovePostResponse>>> act = () => client.Sync.RemoveWatchlistItemsAsync(content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRemoveWatchlistItemsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveWatchlistItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSyncWatchlistRemovePostResponse>>> act = () => client.Sync.RemoveWatchlistItemsAsync(default!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var content = new TraktSyncWatchlistRemovePost();
            act = () => client.Sync.RemoveWatchlistItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [];
            act = () => client.Sync.RemoveWatchlistItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
