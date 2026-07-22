namespace TraktNET.Enums
{
    public sealed class TraktUserSocialActivityTypeTests
    {
        [Fact]
        public void TestTraktUserSocialActivityTypeToJson()
        {
            TraktUserSocialActivityType.Unspecified.ToJson().ShouldBeNull();
            TraktUserSocialActivityType.Friends.ToJson().ShouldBe("friends");
            TraktUserSocialActivityType.Followers.ToJson().ShouldBe("followers");
            TraktUserSocialActivityType.Following.ToJson().ShouldBe("following");
        }

        [Fact]
        public void TestTraktUserSocialActivityTypeFromJson()
        {
            "unspecified".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Unspecified);
            "friends".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Friends);
            "followers".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Followers);
            "following".ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Following);

            string? nullValue = null;
            nullValue.ToTraktUserSocialActivityType().ShouldBe(TraktUserSocialActivityType.Unspecified);
        }

        [Fact]
        public void TestTraktUserSocialActivityTypeDisplayName()
        {
            TraktUserSocialActivityType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUserSocialActivityType.Friends.DisplayName().ShouldBe("Friends");
            TraktUserSocialActivityType.Followers.DisplayName().ShouldBe("Followers");
            TraktUserSocialActivityType.Following.DisplayName().ShouldBe("Following");
        }
    }
}
