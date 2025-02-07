namespace TraktNET.Enums
{
    public sealed class TraktListPrivacyTests
    {
        [Fact]
        public void TestTraktListPrivacyToJson()
        {
            TraktListPrivacy.Unspecified.ToJson().ShouldBeNull();
            TraktListPrivacy.Private.ToJson().ShouldBe("private");
            TraktListPrivacy.Link.ToJson().ShouldBe("link");
            TraktListPrivacy.Friends.ToJson().ShouldBe("friends");
            TraktListPrivacy.Public.ToJson().ShouldBe("public");
        }

        [Fact]
        public void TestTraktListPrivacyFromJson()
        {
            "unspecified".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Unspecified);
            "private".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Private);
            "link".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Link);
            "friends".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Friends);
            "public".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Public);

            string? nullValue = null;
            nullValue.ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Unspecified);
        }

        [Fact]
        public void TestTraktListPrivacyDisplayName()
        {
            TraktListPrivacy.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktListPrivacy.Private.DisplayName().ShouldBe("Private");
            TraktListPrivacy.Link.DisplayName().ShouldBe("Link");
            TraktListPrivacy.Friends.DisplayName().ShouldBe("Friends");
            TraktListPrivacy.Public.DisplayName().ShouldBe("Public");
        }
    }
}
