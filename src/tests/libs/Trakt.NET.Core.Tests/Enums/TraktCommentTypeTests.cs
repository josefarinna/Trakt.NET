namespace TraktNET.Enums
{
    public sealed class TraktCommentTypeTests
    {
        [Fact]
        public void TestTraktCommentTypeToJson()
        {
            TraktCommentType.Unspecified.ToJson().ShouldBeNull();
            TraktCommentType.Review.ToJson().ShouldBe("reviews");
            TraktCommentType.Shout.ToJson().ShouldBe("shouts");
            TraktCommentType.All.ToJson().ShouldBe("all");
        }

        [Fact]
        public void TestTraktCommentTypeFromJson()
        {
            "unspecified".ToTraktCommentType().ShouldBe(TraktCommentType.Unspecified);
            "reviews".ToTraktCommentType().ShouldBe(TraktCommentType.Review);
            "shouts".ToTraktCommentType().ShouldBe(TraktCommentType.Shout);
            "all".ToTraktCommentType().ShouldBe(TraktCommentType.All);

            string? nullValue = null;
            nullValue.ToTraktCommentType().ShouldBe(TraktCommentType.Unspecified);
        }

        [Fact]
        public void TestTraktCommentTypeDisplayName()
        {
            TraktCommentType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCommentType.Review.DisplayName().ShouldBe("Review");
            TraktCommentType.Shout.DisplayName().ShouldBe("Shout");
            TraktCommentType.All.DisplayName().ShouldBe("All");
        }
    }
}
