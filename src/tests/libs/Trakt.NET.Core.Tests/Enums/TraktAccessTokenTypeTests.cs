namespace TraktNET.Enums
{
    public sealed class TraktAccessTokenTypeTests
    {
        [Fact]
        public void TestTraktAccessTokenTypeToJson()
        {
            TraktAccessTokenType.Unspecified.ToJson().ShouldBeNull();
            TraktAccessTokenType.Bearer.ToJson().ShouldBe("bearer");
        }

        [Fact]
        public void TestTraktAccessTokenTypeFromJson()
        {
            "unspecified".ToTraktAccessTokenType().ShouldBe(TraktAccessTokenType.Unspecified);
            "bearer".ToTraktAccessTokenType().ShouldBe(TraktAccessTokenType.Bearer);

            string? nullValue = null;
            nullValue.ToTraktAccessTokenType().ShouldBe(TraktAccessTokenType.Unspecified);
        }

        [Fact]
        public void TestTraktAccessTokenTypeDisplayName()
        {
            TraktAccessTokenType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAccessTokenType.Bearer.DisplayName().ShouldBe("Bearer");
        }
    }
}
