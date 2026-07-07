namespace TraktNET.Json.Users
{
    public sealed class TraktUserBlockedUserTests
    {
        [Fact]
        public void TestTraktUserBlockedUserConstructor()
        {
            var blockedUser = new TraktUserBlockedUser();

            blockedUser.BlockedAt.ShouldBeNull();
            blockedUser.User.ShouldBeNull();
            blockedUser.Username.ShouldBeNull();
            blockedUser.Name.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserBlockedUserFromJson()
        {
            TraktUserBlockedUser? blockedUser = await TestUtility.DeserializeJsonAsync<TraktUserBlockedUser>("Users\\blockeduser.json");

            blockedUser.ShouldNotBeNull();
            blockedUser.BlockedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-01-15T10:30:00.000Z"));
            blockedUser.User.ShouldNotBeNull();
            blockedUser.User.Username.ShouldBe("baduser");
            blockedUser.User.Private.ShouldBe(false);
            blockedUser.User.Name.ShouldBe("Bad User");
            blockedUser.User.VIP.ShouldBe(false);
            blockedUser.User.VIPEP.ShouldBe(false);
            blockedUser.User.IDs.ShouldNotBeNull();
            blockedUser.User.IDs.Slug.ShouldBe("baduser");
        }

        [Fact]
        public async Task TestTraktUserBlockedUsersFromJson()
        {
            IReadOnlyList<TraktUserBlockedUser>? blockedUsers = await TestUtility.DeserializeJsonListAsync<TraktUserBlockedUser>("Users\\blockedusers.json");

            blockedUsers.ShouldNotBeNull();
            blockedUsers!.Count.ShouldBe(2);

            TraktUserBlockedUser blockedUser = blockedUsers![0];
            blockedUser.ShouldNotBeNull();
            blockedUser.BlockedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-01-15T10:30:00.000Z"));
            blockedUser.User.ShouldNotBeNull();
            blockedUser.User.Username.ShouldBe("baduser");
            blockedUser.User.Private.ShouldBe(false);
            blockedUser.User.Name.ShouldBe("Bad User");
            blockedUser.User.VIP.ShouldBe(false);
            blockedUser.User.VIPEP.ShouldBe(false);
            blockedUser.User.IDs.ShouldNotBeNull();
            blockedUser.User.IDs.Slug.ShouldBe("baduser");

            // --------------------------------------------------------------------------------------------

            blockedUser = blockedUsers![1];
            blockedUser.ShouldNotBeNull();
            blockedUser.BlockedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-20T08:00:00.000Z"));
            blockedUser.User.ShouldNotBeNull();
            blockedUser.User.Username.ShouldBe("spammer");
            blockedUser.User.Private.ShouldBe(true);
            blockedUser.User.Name.ShouldBeNull();
            blockedUser.User.VIP.ShouldBe(false);
            blockedUser.User.VIPEP.ShouldBe(false);
            blockedUser.User.IDs.ShouldNotBeNull();
            blockedUser.User.IDs.Slug.ShouldBe("spammer");
        }
    }
}
