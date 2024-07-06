namespace TraktNET.Enums
{
    public sealed class TraktUserLikeTypeTests
    {
        [Fact]
        public void TestTraktUserLikeTypeToJson()
        {
            TraktUserLikeType.Unspecified.ToJson().Should().BeNull();
            TraktUserLikeType.Comment.ToJson().Should().Be("comment");
            TraktUserLikeType.List.ToJson().Should().Be("list");
        }

        [Fact]
        public void TestTraktUserLikeTypeFromJson()
        {
            "unspecified".ToTraktUserLikeType().Should().Be(TraktUserLikeType.Unspecified);
            "comment".ToTraktUserLikeType().Should().Be(TraktUserLikeType.Comment);
            "list".ToTraktUserLikeType().Should().Be(TraktUserLikeType.List);

            string? nullValue = null;
            nullValue.ToTraktUserLikeType().Should().Be(TraktUserLikeType.Unspecified);
        }

        [Fact]
        public void TestTraktUserLikeTypeDisplayName()
        {
            TraktUserLikeType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktUserLikeType.Comment.DisplayName().Should().Be("Comment");
            TraktUserLikeType.List.DisplayName().Should().Be("List");
        }
    }
}
