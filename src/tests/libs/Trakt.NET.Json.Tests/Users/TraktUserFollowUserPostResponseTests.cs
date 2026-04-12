namespace TraktNET.Json.Users
{
    public sealed class TraktUserFollowUserPostResponseTests
    {
        [Fact]
        public void TestTraktUserFollowUserPostResponseDefaultConstructor()
        {
            var userFollowUserPostResponse = new TraktUserFollowUserPostResponse();

            userFollowUserPostResponse.ApprovedAt.ShouldBeNull();
            userFollowUserPostResponse.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserFollowUserPostResponseFromJson()
        {
            TraktUserFollowUserPostResponse? userFollowUserPostResponse = await TestUtility.DeserializeJsonAsync<TraktUserFollowUserPostResponse>("Users\\userfollowuserpostresponse.json");

            userFollowUserPostResponse.ShouldNotBeNull();

            userFollowUserPostResponse.ApprovedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-15T09:41:34.704Z"));

            userFollowUserPostResponse.User.ShouldNotBeNull();
            userFollowUserPostResponse.User.Username.ShouldBe("sean");
            userFollowUserPostResponse.User.Private.ShouldBe(false);
            userFollowUserPostResponse.User.Name.ShouldBe("Sean Rudford");
            userFollowUserPostResponse.User.VIP.ShouldBe(true);
            userFollowUserPostResponse.User.VIPEP.ShouldBe(true);
            userFollowUserPostResponse.User.IDs.ShouldNotBeNull();
            userFollowUserPostResponse.User.IDs.Slug.ShouldBe("sean");
            userFollowUserPostResponse.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            userFollowUserPostResponse.User.Location.ShouldBe("SF");
            userFollowUserPostResponse.User.About.ShouldBe("I have all your cassette tapes.");
            userFollowUserPostResponse.User.Gender.ShouldBe(TraktGender.Male);
            userFollowUserPostResponse.User.Age.ShouldBe(35U);
            userFollowUserPostResponse.User.Images.ShouldNotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.ShouldNotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }
    }
}
