namespace TraktNET.Enums
{
    public sealed class TraktAccessScopeTests
    {
        [Fact]
        public void TestTraktAccessScopeToJson()
        {
            TraktAccessScope.Unspecified.ToJson().ShouldBeNull();
            TraktAccessScope.Private.ToJson().ShouldBe("private");
            TraktAccessScope.Friends.ToJson().ShouldBe("friends");
            TraktAccessScope.Public.ToJson().ShouldBe("public");
        }

        [Fact]
        public void TestTraktAccessScopeFromJson()
        {
            "unspecified".ToTraktAccessScope().ShouldBe(TraktAccessScope.Unspecified);
            "private".ToTraktAccessScope().ShouldBe(TraktAccessScope.Private);
            "friends".ToTraktAccessScope().ShouldBe(TraktAccessScope.Friends);
            "public".ToTraktAccessScope().ShouldBe(TraktAccessScope.Public);

            string? nullValue = null;
            nullValue.ToTraktAccessScope().ShouldBe(TraktAccessScope.Unspecified);
        }

        [Fact]
        public void TestTraktAccessScopeDisplayName()
        {
            TraktAccessScope.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAccessScope.Private.DisplayName().ShouldBe("Private");
            TraktAccessScope.Friends.DisplayName().ShouldBe("Friends");
            TraktAccessScope.Public.DisplayName().ShouldBe("Public");
        }
    }
}
