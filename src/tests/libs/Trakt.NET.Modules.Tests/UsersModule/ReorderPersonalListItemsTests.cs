using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ReorderPersonalListItemsTests
    {
        private readonly string ReorderPersonalListItemsUri = $"users/{Username}/lists/{ListID}/items/reorder";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private readonly List<uint> ReorderedCustomListItems = [923, 324, 98768, 456456, 345, 12, 990];

        [Fact]
        public async Task TestReorderPersonalListItemsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, responseContent, null, null, null, null);
            TraktResponse<TraktListItemsReorderPostResponse> response = await client.Users.ReorderPersonalListItemsAsync(Username, TraktListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktListItemsReorderPostResponse responseValue = response.Content;

            responseValue.Updated.ShouldBe(6U);
            responseValue.SkippedIDs.ShouldNotBeNull();
            responseValue.SkippedIDs.Count.ShouldBe(1);
            responseValue.SkippedIDs.ShouldBeEquivalentTo(new List<uint> { 12 });
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/reorder",
                responseContent, null, null, null, null);

            TraktResponse<TraktListItemsReorderPostResponse> response =
                await client.Users.ReorderPersonalListItemsAsync(Username, ListSlug, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/reorder",
                responseContent, null, null, null, null);

            TraktResponse<TraktListItemsReorderPostResponse> response =
                await client.Users.ReorderPersonalListItemsAsync(Username, listIds, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistimtesreorderpostresponse.json");

            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/reorder",
                responseContent, null, null, null, null);

            TraktResponse<TraktListItemsReorderPostResponse> response =
                await client.Users.ReorderPersonalListItemsAsync(Username, list, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestReorderPersonalListItemsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, statusCode);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Users.ReorderPersonalListItemsAsync(Username, TraktListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsExceptions()
        {
            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Users.ReorderPersonalListItemsAsync(null!, ListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(string.Empty, ListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("user name", ListID, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", default(string)!, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", string.Empty, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync("username", "list id", ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(Username, TraktListID, null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }

        [Fact]
        public async Task TestReorderPersonalListItemsWithIDsThrowsArgumentException()
        {
            var content = new TraktListItemsReorderPost
            {
                Rank = ReorderedCustomListItems
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderPersonalListItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act =
                () => client.Users.ReorderPersonalListItemsAsync(Username, default(TraktListIDs)!, ReorderedCustomListItems, TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(Username, default(TraktList)!, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(Username, new TraktListIDs(), ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.ReorderPersonalListItemsAsync(Username, 0, ReorderedCustomListItems, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
