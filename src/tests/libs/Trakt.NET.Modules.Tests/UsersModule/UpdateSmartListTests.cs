using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdateSmartListTests
    {
        private const string UpdateSmartListUri = $"users/{Username}/smart-lists/{ListID}";
        private const string Username = "sean";
        private const string ListID = "123456";
        private const uint TraktListID = 123456;
        private const string ListSlug = "sci-fi-movies";

        [Fact]
        public async Task TestUpdateSmartListWithID()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = "updated smart list",
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateSmartListUri, responseContent);

            TraktResponse<TraktSmartList> response = await client.Users.UpdateSmartListAsync(Username, TraktListID, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateSmartListWithSlug()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = "updated smart list",
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.Users.UpdateSmartListAsync(Username, ListSlug, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateSmartListWithList()
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = "updated smart list",
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            var smartList = new TraktSmartList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.Users.UpdateSmartListAsync(Username, smartList, smartListPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestUpdateSmartListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var smartListPost = new TraktSmartListPost
            {
                Name = "updated smart list",
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateSmartListUri, statusCode);
            Func<Task<TraktResponse<TraktSmartList>>> act = () => client.Users.UpdateSmartListAsync(Username, TraktListID, smartListPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateSmartListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateSmartListUri, HttpStatusCode.Created);

            var smartListPost = new TraktSmartListPost
            {
                Name = "updated smart list",
                Source = TraktSmartListSource.Popular,
                MediaType = TraktSmartListMediaType.Movies
            };

            Func<Task<TraktResponse<TraktSmartList>>> act = () => client.Users.UpdateSmartListAsync(null!, ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.UpdateSmartListAsync(string.Empty, ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.UpdateSmartListAsync("username with spaces", ListID, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.UpdateSmartListAsync(Username, default(string)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.UpdateSmartListAsync(Username, string.Empty, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.UpdateSmartListAsync(Username, "list id with spaces", smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.UpdateSmartListAsync(Username, 0, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdateSmartListAsync(Username, default(TraktListIDs)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdateSmartListAsync(Username, new TraktListIDs(), smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdateSmartListAsync(Username, default(TraktSmartList)!, smartListPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.UpdateSmartListAsync(Username, ListID, null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
