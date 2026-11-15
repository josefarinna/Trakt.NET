using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class FollowUserTests
    {
        private const string FollowUserUri = $"users/{Username}/follow";
        private const string Username = "sean";

        [Fact]
        public async Task TestFollowUser()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfollowuserpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(FollowUserUri, responseContent);
            
            TraktResponse<TraktUserFollowUserPostResponse> response = await client.Users.FollowUserAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserFollowUserPostResponse responseValue = response.Content;

            responseValue.ApprovedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-15T09:41:34.704Z"));
            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("sean");
            responseValue.User.Private.ShouldBe(false);
            responseValue.User.Name.ShouldBe("Sean Rudford");
            responseValue.User.VIP.ShouldBe(true);
            responseValue.User.VIPEP.ShouldBe(true);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestFollowUserThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(FollowUserUri, statusCode);

            Func<Task<TraktResponse<TraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(Username, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
