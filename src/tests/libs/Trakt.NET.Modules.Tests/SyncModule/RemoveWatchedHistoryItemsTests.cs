using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class RemoveWatchedHistoryItemsTests
    {
        private const string RemoveWatchedHistoryItemsUri = "sync/history/remove";

        [Fact]
        public async Task TestRemoveWatchedHistoryItems()
        {
            var content = new TraktSyncHistoryRemovePost
            {
                Movies = [new TraktSyncRemovePostMovie { IDs = new TraktMovieIDs { Trakt = 1U } }]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\synchistoryremovepostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveWatchedHistoryItemsUri, responseContent);
            TraktResponse<TraktSyncHistoryRemovePostResponse> response = await client.Sync.RemoveWatchedHistoryItemsAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSyncHistoryRemovePostResponse responseValue = response.Content;

            responseValue.Deleted.ShouldNotBeNull();
            responseValue.Deleted.Movies.ShouldBe(2U);
            responseValue.Deleted.Episodes.ShouldBe(72U);
            responseValue.Deleted.Shows.ShouldBeNull();
            responseValue.Deleted.Seasons.ShouldBeNull();

            responseValue.NotFound.ShouldNotBeNull();
            responseValue.NotFound.Movies.ShouldNotBeNull();
            responseValue.NotFound.Movies.Count.ShouldBe(1);

            TraktPostResponseNotFoundMovie[] movies = [.. responseValue.NotFound.Movies];

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

            responseValue.NotFound.HistoryIDs.ShouldNotBeNull();
            responseValue.NotFound.HistoryIDs.Count.ShouldBe(2);
            responseValue.NotFound.HistoryIDs.ShouldBe([23, 42]);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestRemoveWatchedHistoryItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveWatchedHistoryItemsUri, statusCode);

            var content = new TraktSyncHistoryRemovePost
            {
                Movies = [new TraktSyncRemovePostMovie { IDs = new TraktMovieIDs { Trakt = 1U } }]
            };

            Func<Task<TraktResponse<TraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRemoveWatchedHistoryItemsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveWatchedHistoryItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(default!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var content = new TraktSyncHistoryRemovePost();
            act = () => client.Sync.RemoveWatchedHistoryItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [];
            act = () => client.Sync.RemoveWatchedHistoryItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

        }
    }
}
