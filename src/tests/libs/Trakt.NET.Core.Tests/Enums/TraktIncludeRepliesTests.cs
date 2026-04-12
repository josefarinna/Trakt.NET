namespace TraktNET.Enums
{
    public sealed class TraktIncludeRepliesTests
    {
        [Fact]
        public void TestTraktIncludeRepliesToJson()
        {
            TraktIncludeReplies.Unspecified.ToJson().ShouldBeNull();
            TraktIncludeReplies.True.ToJson().ShouldBe("true");
            TraktIncludeReplies.False.ToJson().ShouldBe("false");
            TraktIncludeReplies.Only.ToJson().ShouldBe("only");
        }

        [Fact]
        public void TestTraktIncludeRepliesFromJson()
        {
            "unspecified".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.Unspecified);
            "true".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.True);
            "false".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.False);
            "only".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.Only);

            string? nullValue = null;
            nullValue.ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.Unspecified);
        }

        [Fact]
        public void TestTraktIncludeRepliesDisplayName()
        {
            TraktIncludeReplies.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktIncludeReplies.True.DisplayName().ShouldBe("True");
            TraktIncludeReplies.False.DisplayName().ShouldBe("False");
            TraktIncludeReplies.Only.DisplayName().ShouldBe("Only");
        }
    }
}
