using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetFollowingTests
    {
        private const string GetFollowingUri = $"users/{Username}/following";
        private const string Username = "sean";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetFollowingUri)]
        [InlineData(ExtendedInfo, $"{GetFollowingUri}?extended=full")]
        public async Task TestGetFollowing(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\follower.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktUserFollower> response = await client.Users.GetFollowingAsync(Username, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetFollowingWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\follower.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFollowingUri, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktListResponse<TraktUserFollower> response = await client.Users.GetFollowingAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetFollowingWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\follower.json");
            
            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/following", responseContent);
            
            TraktListResponse<TraktUserFollower> response = await client.Users.GetFollowingAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetFollowingThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFollowingUri, statusCode);

            Func<Task<TraktListResponse<TraktUserFollower>>> act = () => client.Users.GetFollowingAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
