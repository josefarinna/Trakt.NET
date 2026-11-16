using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSmartListsTests
    {
        private const string GetSmartListsUri = $"users/{Username}/smart-lists";
        private const string Username = "sean";

        [Fact]
        public async Task TestGetSmartLists()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlists.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSmartListsUri, responseContent);

            TraktListResponse<TraktSmartList> response = await client.Users.GetSmartListsAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("SmartLists\\smartlists.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSmartListsUri, responseContent, null, null, null, null);
            client.IgnoreOAuthIfOptional = false;

            TraktListResponse<TraktSmartList> response = await client.Users.GetSmartListsAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetSmartListsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListsUri, statusCode);
            Func<Task<TraktListResponse<TraktSmartList>>> act = () => client.Users.GetSmartListsAsync(Username, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListsArgumentExceptions()
        {
            var client = TraktClient.Create(TestConstants.ClientID, TestConstants.ClientSecret);

            Func<Task<TraktListResponse<TraktSmartList>>> act = () => client.Users.GetSmartListsAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListsAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.GetSmartListsAsync("username with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
