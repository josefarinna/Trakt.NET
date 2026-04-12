namespace TraktNET.Json.Users
{
    public sealed class TraktUserFriendTests
    {
        [Fact]
        public void TestTraktUserFriendDefaultConstructor()
        {
            var userFriend = new TraktUserFriend();

            userFriend.FriendsAt.ShouldBeNull();
            userFriend.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserFriendFromJson()
        {
            TraktUserFriend? userFriend = await TestUtility.DeserializeJsonAsync<TraktUserFriend>("Users\\userfriend.json");

            userFriend.ShouldNotBeNull();
            userFriend.FriendsAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            userFriend.User.ShouldNotBeNull();
            userFriend.User.Username.ShouldBe("sean");
            userFriend.User.Private.ShouldBe(false);
            userFriend.User.Name.ShouldBe("Sean Rudford");
            userFriend.User.VIP.ShouldBe(true);
            userFriend.User.VIPEP.ShouldBe(true);
            userFriend.User.IDs.ShouldNotBeNull();
            userFriend.User.IDs.Slug.ShouldBe("sean");
            userFriend.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            userFriend.User.Location.ShouldBe("SF");
            userFriend.User.About.ShouldBe("I have all your cassette tapes.");
            userFriend.User.Gender.ShouldBe(TraktGender.Male);
            userFriend.User.Age.ShouldBe(35U);
            userFriend.User.Images.ShouldNotBeNull();
            userFriend.User.Images.Avatar.ShouldNotBeNull();
            userFriend.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/userFriends/000/000/001/avatars/large/0ba3f72910.jpg");
        }
    }
}
