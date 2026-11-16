using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetPlexServerAccountsTests
    {
        private const string ServerID = "some_server_id";
        private const string GetPlexServerAccountsUri = $"users/settings/plex/servers/{ServerID}";

        [Fact]
        public async Task TestGetPlexServerAccounts()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\plexserveraccounts.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexServerAccountsUri, responseContent);
            TraktResponse<TraktPlexServerAccountsAndLibraries> response = await client.Users.GetPlexServerAccountsAsync(ServerID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            response.Content.Accounts.ShouldNotBeNull();
            response.Content.Accounts[0].Name.ShouldBe("account1");

            response.Content.Libraries.ShouldNotBeNull();
            response.Content.Libraries[0].Title.ShouldBe("Movies");
            response.Content.Libraries[0].Selected.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPlexServerAccountsThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexServerAccountsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktPlexServerAccountsAndLibraries>>> act = () => client.Users.GetPlexServerAccountsAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetPlexServerAccountsAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetPlexServerAccountsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexServerAccountsUri, statusCode);

            Func<Task<TraktResponse<TraktPlexServerAccountsAndLibraries>>> act = () => client.Users.GetPlexServerAccountsAsync(ServerID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
