namespace TraktNET.Enums
{
    public sealed class TraktCommentTypeTests
    {
        [Fact]
        public void TestTraktCommentTypeToJson()
        {
            TraktCommentType.Unspecified.ToJson().Should().BeNull();
            TraktCommentType.Review.ToJson().Should().Be("reviews");
            TraktCommentType.Shout.ToJson().Should().Be("shouts");
            TraktCommentType.All.ToJson().Should().Be("all");
        }

        [Fact]
        public void TestTraktCommentTypeFromJson()
        {
            "unspecified".ToTraktCommentType().Should().Be(TraktCommentType.Unspecified);
            "reviews".ToTraktCommentType().Should().Be(TraktCommentType.Review);
            "shouts".ToTraktCommentType().Should().Be(TraktCommentType.Shout);
            "all".ToTraktCommentType().Should().Be(TraktCommentType.All);

            string? nullValue = null;
            nullValue.ToTraktCommentType().Should().Be(TraktCommentType.Unspecified);
        }

        [Fact]
        public void TestTraktCommentTypeDisplayName()
        {
            TraktCommentType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktCommentType.Review.DisplayName().Should().Be("Review");
            TraktCommentType.Shout.DisplayName().Should().Be("Shout");
            TraktCommentType.All.DisplayName().Should().Be("All");
        }
    }
}
