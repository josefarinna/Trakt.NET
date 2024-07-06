namespace TraktNET.Enums
{
    public sealed class TraktListPrivacyTests
    {
        [Fact]
        public void TestTraktListPrivacyToJson()
        {
            TraktListPrivacy.Unspecified.ToJson().Should().BeNull();
            TraktListPrivacy.Private.ToJson().Should().Be("private");
            TraktListPrivacy.Link.ToJson().Should().Be("link");
            TraktListPrivacy.Friends.ToJson().Should().Be("friends");
            TraktListPrivacy.Public.ToJson().Should().Be("public");
        }

        [Fact]
        public void TestTraktListPrivacyFromJson()
        {
            "unspecified".ToTraktListPrivacy().Should().Be(TraktListPrivacy.Unspecified);
            "private".ToTraktListPrivacy().Should().Be(TraktListPrivacy.Private);
            "link".ToTraktListPrivacy().Should().Be(TraktListPrivacy.Link);
            "friends".ToTraktListPrivacy().Should().Be(TraktListPrivacy.Friends);
            "public".ToTraktListPrivacy().Should().Be(TraktListPrivacy.Public);

            string? nullValue = null;
            nullValue.ToTraktListPrivacy().Should().Be(TraktListPrivacy.Unspecified);
        }

        [Fact]
        public void TestTraktListPrivacyDisplayName()
        {
            TraktListPrivacy.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktListPrivacy.Private.DisplayName().Should().Be("Private");
            TraktListPrivacy.Link.DisplayName().Should().Be("Link");
            TraktListPrivacy.Friends.DisplayName().Should().Be("Friends");
            TraktListPrivacy.Public.DisplayName().Should().Be("Public");
        }
    }
}
