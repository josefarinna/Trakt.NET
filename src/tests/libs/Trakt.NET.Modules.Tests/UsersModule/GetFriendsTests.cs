using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetFriendsTests
    {
        private const string GetFriendsUri = $"users/{Username}/friends";
        private const string Username = "sean";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetFriendsUri)]
        [InlineData(ExtendedInfo, $"{GetFriendsUri}?extended=full")]
        public async Task TestGetFriends(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\friends.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUserFriend> response = await client.Users.GetFriendsAsync(Username, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetFriendsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\friends.json");
            
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFriendsUri, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktListResponse<TraktUserFriend> response = await client.Users.GetFriendsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetFriendsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\friends.json");
            
            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/friends", responseContent);
            
            TraktListResponse<TraktUserFriend> response = await client.Users.GetFriendsAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetFriendsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFriendsUri, statusCode);

            Func<Task<TraktListResponse<TraktUserFriend>>> act = () => client.Users.GetFriendsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
