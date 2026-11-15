using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetFollowersTests
    {
        private const string GetFollowersUri = $"users/{Username}/followers";
        private const string Username = "sean";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetFollowersUri)]
        [InlineData(ExtendedInfo, $"{GetFollowersUri}?extended=full")]
        public async Task TestGetFollowers(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\follower.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUserFollower> response = await client.Users.GetFollowersAsync(Username, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetFollowersWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\follower.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFollowersUri, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktListResponse<TraktUserFollower> response = await client.Users.GetFollowersAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetFollowersWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\follower.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/followers", responseContent);
            
            TraktListResponse<TraktUserFollower> response = await client.Users.GetFollowersAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetFollowersThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFollowersUri, statusCode);

            Func<Task<TraktListResponse<TraktUserFollower>>> act = () => client.Users.GetFollowersAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
