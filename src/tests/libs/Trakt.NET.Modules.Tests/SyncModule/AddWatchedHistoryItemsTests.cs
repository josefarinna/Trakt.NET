using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class AddWatchedHistoryItemsTests
    {
        private const string AddWatchedHistoryItemsUri = "sync/history";

        [Fact]
        public async Task TestAddWatchedHistoryItems()
        {
            var content = new TraktSyncHistoryPost
            {
                Movies = [ new TraktSyncHistoryPostMovie() ]
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\synchistorypostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddWatchedHistoryItemsUri, responseContent);

            TraktResponse<TraktSyncHistoryPostResponse> response = await client.Sync.AddWatchedHistoryItemsAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSyncHistoryPostResponse responseValue = response.Content;

            responseValue.Added.ShouldNotBeNull();
            responseValue.Added.Movies.ShouldBe(2U);
            responseValue.Added.Episodes.ShouldBe(72U);
            responseValue.Added.Shows.ShouldBeNull();
            responseValue.Added.Seasons.ShouldBeNull();

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
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestAddWatchedHistoryItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddWatchedHistoryItemsUri, statusCode);

            var content = new TraktSyncHistoryPost
            {
                Movies = [new TraktSyncHistoryPostMovie()]
            };

            Func<Task<TraktResponse<TraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(content, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddWatchedHistoryItemsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddWatchedHistoryItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(default!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var content = new TraktSyncHistoryPost();
            act = () => client.Sync.AddWatchedHistoryItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movies = [];
            act = () => client.Sync.AddWatchedHistoryItemsAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
