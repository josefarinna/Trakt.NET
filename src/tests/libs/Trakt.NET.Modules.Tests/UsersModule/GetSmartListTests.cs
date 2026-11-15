using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSmartListTests
    {
        private const string GetSmartListUri = $"users/{Username}/smart-lists/{ListID}";
        private const string Username = "sean";
        private const string ListID = "123456";
        private const uint TraktListID = 123456;
        private const string ListSlug = "sci-fi-movies";

        [Fact]
        public async Task TestGetSmartListWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSmartListUri, responseContent);

            TraktResponse<TraktSmartList> response = await client.Users.GetSmartListAsync(Username, TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.Users.GetSmartListAsync(Username, ListSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            var smartList = new TraktSmartList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/smart-lists/{ListSlug}", responseContent);

            TraktResponse<TraktSmartList> response = await client.Users.GetSmartListAsync(Username, smartList, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSmartListUri, responseContent, null, null, null, null);
            client.IgnoreOAuthIfOptional = false;

            TraktResponse<TraktSmartList> response = await client.Users.GetSmartListAsync(Username, TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestGetSmartListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListUri, statusCode);
            Func<Task<TraktResponse<TraktSmartList>>> act = () => client.Users.GetSmartListAsync(Username, TraktListID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListWithIDsThrowsArgumentException()
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            Func<Task<TraktResponse<TraktSmartList>>> act = () => client.Users.GetSmartListAsync(null!, ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListAsync(string.Empty, ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListAsync("username with spaces", ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListAsync(Username, default(string)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListAsync(Username, string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListAsync(Username, "list id with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListAsync(Username, 0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetSmartListAsync(Username, default(TraktListIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetSmartListAsync(Username, new TraktListIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetSmartListAsync(Username, default(TraktSmartList)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
