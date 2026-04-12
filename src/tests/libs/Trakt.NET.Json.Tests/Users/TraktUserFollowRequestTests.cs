namespace TraktNET.Json.Users
{
    public sealed class TraktUserFollowRequestTests
    {
        [Fact]
        public void TestTraktUserFollowRequestDefaultConstructor()
        {
            var userFollowRequest = new TraktUserFollowRequest();

            userFollowRequest.Id.ShouldBe(0U);
            userFollowRequest.RequestedAt.ShouldBeNull();
            userFollowRequest.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserFollowRequestFromJson()
        {
            TraktUserFollowRequest? userFollowRequest = await TestUtility.DeserializeJsonAsync<TraktUserFollowRequest>("Users\\userfollowrequest.json");

            userFollowRequest.ShouldNotBeNull();
            userFollowRequest.Id.ShouldBe(12345U);
            userFollowRequest.RequestedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            userFollowRequest.User.ShouldNotBeNull();
            userFollowRequest.User.Username.ShouldBe("sean");
            userFollowRequest.User.Private.ShouldBe(false);
            userFollowRequest.User.Name.ShouldBe("Sean Rudford");
            userFollowRequest.User.VIP.ShouldBe(true);
            userFollowRequest.User.VIPEP.ShouldBe(true);
            userFollowRequest.User.IDs.ShouldNotBeNull();
            userFollowRequest.User.IDs.Slug.ShouldBe("sean");
            userFollowRequest.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            userFollowRequest.User.Location.ShouldBe("SF");
            userFollowRequest.User.About.ShouldBe("I have all your cassette tapes.");
            userFollowRequest.User.Gender.ShouldBe(TraktGender.Male);
            userFollowRequest.User.Age.ShouldBe(35U);
            userFollowRequest.User.Images.ShouldNotBeNull();
            userFollowRequest.User.Images.Avatar.ShouldNotBeNull();
            userFollowRequest.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }
    }
}
