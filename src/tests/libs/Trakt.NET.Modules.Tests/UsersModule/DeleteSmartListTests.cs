using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class DeleteSmartListTests
    {
        private const string DeleteSmartListUri = $"users/{Username}/smart-lists/{ListID}";
        private const string Username = "sean";
        private const string ListID = "123456";
        private const uint TraktListID = 123456;
        private const string ListSlug = "sci-fi-movies";

        [Fact]
        public async Task TestDeleteSmartListWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeleteSmartListUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.DeleteSmartListAsync(Username, TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestDeleteSmartListWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/smart-lists/{ListSlug}", HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.DeleteSmartListAsync(Username, ListSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestDeleteSmartListWithList()
        {
            var smartList = new TraktSmartList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/smart-lists/{ListSlug}", HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.DeleteSmartListAsync(Username, smartList, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestDeleteSmartListWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeleteSmartListUri, statusCode);
            Func<Task<TraktResponse>> act = () => client.Users.DeleteSmartListAsync(Username, TraktListID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestDeleteSmartListWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeleteSmartListUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.DeleteSmartListAsync(null!, ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.DeleteSmartListAsync(string.Empty, ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.DeleteSmartListAsync("username with spaces", ListID, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.DeleteSmartListAsync(Username, default(string)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.DeleteSmartListAsync(Username, string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.DeleteSmartListAsync(Username, "list id with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.DeleteSmartListAsync(Username, 0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.DeleteSmartListAsync(Username, default(TraktListIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.DeleteSmartListAsync(Username, new TraktListIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.DeleteSmartListAsync(Username, default(TraktSmartList)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
