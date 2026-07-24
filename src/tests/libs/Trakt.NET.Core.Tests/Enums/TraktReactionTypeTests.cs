namespace TraktNET.Enums
{
    public sealed class TraktReactionTypeTests
    {
        [Fact]
        public void TestTraktReactionTypeToJson()
        {
            TraktReactionType.Unspecified.ToJson().ShouldBeNull();
            TraktReactionType.Like.ToJson().ShouldBe("like");
            TraktReactionType.Dislike.ToJson().ShouldBe("dislike");
            TraktReactionType.Love.ToJson().ShouldBe("love");
            TraktReactionType.Laugh.ToJson().ShouldBe("laugh");
            TraktReactionType.Shocked.ToJson().ShouldBe("shocked");
            TraktReactionType.Bravo.ToJson().ShouldBe("bravo");
            TraktReactionType.Spoiler.ToJson().ShouldBe("spoiler");
        }

        [Fact]
        public void TestTraktReactionTypeFromJson()
        {
            "unspecified".ToTraktReactionType().ShouldBe(TraktReactionType.Unspecified);
            "like".ToTraktReactionType().ShouldBe(TraktReactionType.Like);
            "dislike".ToTraktReactionType().ShouldBe(TraktReactionType.Dislike);
            "love".ToTraktReactionType().ShouldBe(TraktReactionType.Love);
            "laugh".ToTraktReactionType().ShouldBe(TraktReactionType.Laugh);
            "shocked".ToTraktReactionType().ShouldBe(TraktReactionType.Shocked);
            "bravo".ToTraktReactionType().ShouldBe(TraktReactionType.Bravo);
            "spoiler".ToTraktReactionType().ShouldBe(TraktReactionType.Spoiler);

            string? nullValue = null;
            nullValue.ToTraktReactionType().ShouldBe(TraktReactionType.Unspecified);
        }

        [Fact]
        public void TestTraktReactionTypeDisplayName()
        {
            TraktReactionType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktReactionType.Like.DisplayName().ShouldBe("Like");
            TraktReactionType.Dislike.DisplayName().ShouldBe("Dislike");
            TraktReactionType.Love.DisplayName().ShouldBe("Love");
            TraktReactionType.Laugh.DisplayName().ShouldBe("Laugh");
            TraktReactionType.Shocked.DisplayName().ShouldBe("Shocked");
            TraktReactionType.Bravo.DisplayName().ShouldBe("Bravo");
            TraktReactionType.Spoiler.DisplayName().ShouldBe("Spoiler");
        }
    }
}
