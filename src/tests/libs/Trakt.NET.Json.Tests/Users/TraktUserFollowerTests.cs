namespace TraktNET.Json.Users
{
    public sealed class TraktUserFollowerTests
    {
        [Fact]
        public void TestTraktUserFollowerDefaultConstructor()
        {
            var userFollower = new TraktUserFollower();

            userFollower.FollowedAt.ShouldBeNull();
            userFollower.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserFollowerFromJson()
        {
            TraktUserFollower? userFollower = await TestUtility.DeserializeJsonAsync<TraktUserFollower>("Users\\userfollower.json");

            userFollower.ShouldNotBeNull();
            userFollower.FollowedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            userFollower.User.ShouldNotBeNull();
            userFollower.User.Username.ShouldBe("sean");
            userFollower.User.Private.ShouldBe(false);
            userFollower.User.Name.ShouldBe("Sean Rudford");
            userFollower.User.VIP.ShouldBe(true);
            userFollower.User.VIPEP.ShouldBe(true);
            userFollower.User.IDs.ShouldNotBeNull();
            userFollower.User.IDs.Slug.ShouldBe("sean");
            userFollower.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            userFollower.User.Location.ShouldBe("SF");
            userFollower.User.About.ShouldBe("I have all your cassette tapes.");
            userFollower.User.Gender.ShouldBe(TraktGender.Male);
            userFollower.User.Age.ShouldBe(35U);
            userFollower.User.Images.ShouldNotBeNull();
            userFollower.User.Images.Avatar.ShouldNotBeNull();
            userFollower.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/userFollowers/000/000/001/avatars/large/0ba3f72910.jpg");
        }
    }
}
