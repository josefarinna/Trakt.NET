using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class AddRecentSearchTests
    {
        private const string AddRecentSearchUri = "search/recent";
        private const string Query = "batman";
        private const uint ItemID = 99U;
        private const TraktSearchRecentType Type = TraktSearchRecentType.Movie;

        [Fact]
        public async Task TestAddRecentSearch()
        {
            string requestContent = TestUtility.SerializeObject(new TraktSearchRecentPost { Query = Query, ID = ItemID, Type = Type });

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddRecentSearchUri);
            ModuleTestUtility.AddMockExpectationResponse(client, AddRecentSearchUri, requestContent, HttpStatusCode.Created);

            TraktResponse response = await client.Search.AddRecentSearchAsync(Query, ItemID, Type, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestAddRecentSearchThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddRecentSearchUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Search.AddRecentSearchAsync(Query, ItemID, Type, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddRecentSearchThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddRecentSearchUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Search.AddRecentSearchAsync(null!, ItemID, Type, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Search.AddRecentSearchAsync(string.Empty, ItemID, Type, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Search.AddRecentSearchAsync("  ", ItemID, Type, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Search.AddRecentSearchAsync(Query, 0, Type, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.AddRecentSearchAsync(Query, ItemID, TraktSearchRecentType.Unspecified, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
