namespace TraktNET.Enums
{
    public sealed class TraktReasonTests
    {
        [Fact]
        public void TestTraktReasonToJson()
        {
            TraktReason.Unspecified.ToJson().ShouldBeNull();
            TraktReason.Spam.ToJson().ShouldBe("spam");
            TraktReason.Adult.ToJson().ShouldBe("adult");
            TraktReason.Language.ToJson().ShouldBe("language");
            TraktReason.Other.ToJson().ShouldBe("other");
        }

        [Fact]
        public void TestTraktReasonFromJson()
        {
            "unspecified".ToTraktReason().ShouldBe(TraktReason.Unspecified);
            "spam".ToTraktReason().ShouldBe(TraktReason.Spam);
            "adult".ToTraktReason().ShouldBe(TraktReason.Adult);
            "language".ToTraktReason().ShouldBe(TraktReason.Language);
            "other".ToTraktReason().ShouldBe(TraktReason.Other);

            string? nullValue = null;
            nullValue.ToTraktReason().ShouldBe(TraktReason.Unspecified);
        }

        [Fact]
        public void TestTraktReasonDisplayName()
        {
            TraktReason.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktReason.Spam.DisplayName().ShouldBe("Spam");
            TraktReason.Adult.DisplayName().ShouldBe("Adult");
            TraktReason.Language.DisplayName().ShouldBe("Language");
            TraktReason.Other.DisplayName().ShouldBe("Other");
        }
    }
}
