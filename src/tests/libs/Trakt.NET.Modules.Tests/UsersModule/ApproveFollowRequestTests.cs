using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ApproveFollowRequestTests
    {
        private readonly string ApproveFollowRequestUri = $"users/requests/{RequestID}";
        private const uint RequestID = 3U;

        [Fact]
        public async Task TestApproveFollowRequest()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfollower.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ApproveFollowRequestUri, responseContent);
            
            TraktResponse<TraktUserFollower> response = await client.Users.ApproveFollowRequestAsync(RequestID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserFollower responseValue = response.Content;

            responseValue.FollowedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("sean");
            responseValue.User.Private.ShouldBe(false);
            responseValue.User.Name.ShouldBe("Sean Rudford");
            responseValue.User.VIP.ShouldBe(true);
            responseValue.User.VIPEP.ShouldBe(true);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiUserNotFoundException))]
        public async Task TestApproveFollowRequestThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ApproveFollowRequestUri, statusCode);

            Func<Task<TraktResponse<TraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(RequestID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
