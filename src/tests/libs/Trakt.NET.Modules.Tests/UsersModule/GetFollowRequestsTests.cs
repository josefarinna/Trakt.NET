using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetFollowRequestsTests
    {
        private const string GetFollowRequestUri = "users/requests";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetFollowRequestUri)]
        [InlineData(ExtendedInfo, $"{GetFollowRequestUri}?extended=full")]
        public async Task TestGetFollowRequests(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\followrequests.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent);

            TraktListResponse<TraktUserFollowRequest> response = await client.Users.GetFollowRequestsAsync(extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetFollowRequestsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFollowRequestUri, statusCode);

            Func<Task<TraktListResponse<TraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
