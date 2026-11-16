using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdatePersonalListItemTests
    {
        private readonly string UpdatePersonalListItemUri = $"users/{Username}/lists/{ListID}/items/{ListItemID}";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55U;
        private const string ListSlug = "incredible-thoughts";
        private const string Notes = "This is a great movie!";
        private const uint ListItemID = 1U;

        [Fact]
        public async Task TestUpdatePersonalListItemWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListItemUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, TraktListID, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/{ListItemID}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, ListSlug, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithIDs()
        {
            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/{ListItemID}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, listIds, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithList()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/{ListItemID}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePersonalListItemAsync(Username, list, ListItemID, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestUpdatePersonalListItemWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListItemUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UpdatePersonalListItemAsync(Username, TraktListID, ListItemID, Notes, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdatePersonalListItemWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePersonalListItemUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.UpdatePersonalListItemAsync(Username, default(TraktListIDs)!, ListItemID, Notes, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListItemAsync(Username, default(TraktList)!, ListItemID, Notes, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdatePersonalListItemAsync(Username, new TraktListIDs(), ListItemID, Notes, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdatePersonalListItemAsync(Username, 0, ListItemID, Notes, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
