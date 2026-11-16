using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetPendingFollowingRequestsTests
    {
        private const string GetPendingFollowingRequestsUri = "users/requests/following";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, GetPendingFollowingRequestsUri)]
        [InlineData(ExtendedInfo, $"{GetPendingFollowingRequestsUri}?extended=full")]
        public async Task TestGetPendingFollowingRequests(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\followrequests.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent);

            TraktListResponse<TraktUserFollowRequest> response = await client.Users.GetPendingFollowingRequestsAsync(extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetPendingFollowingRequestsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPendingFollowingRequestsUri, statusCode);

            Func<Task<TraktListResponse<TraktUserFollowRequest>>> act = () => client.Users.GetPendingFollowingRequestsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
