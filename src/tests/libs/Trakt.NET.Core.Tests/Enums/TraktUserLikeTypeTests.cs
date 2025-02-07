namespace TraktNET.Enums
{
    public sealed class TraktUserLikeTypeTests
    {
        [Fact]
        public void TestTraktUserLikeTypeToJson()
        {
            TraktUserLikeType.Unspecified.ToJson().ShouldBeNull();
            TraktUserLikeType.Comment.ToJson().ShouldBe("comment");
            TraktUserLikeType.List.ToJson().ShouldBe("list");
        }

        [Fact]
        public void TestTraktUserLikeTypeFromJson()
        {
            "unspecified".ToTraktUserLikeType().ShouldBe(TraktUserLikeType.Unspecified);
            "comment".ToTraktUserLikeType().ShouldBe(TraktUserLikeType.Comment);
            "list".ToTraktUserLikeType().ShouldBe(TraktUserLikeType.List);

            string? nullValue = null;
            nullValue.ToTraktUserLikeType().ShouldBe(TraktUserLikeType.Unspecified);
        }

        [Fact]
        public void TestTraktUserLikeTypeDisplayName()
        {
            TraktUserLikeType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUserLikeType.Comment.DisplayName().ShouldBe("Comment");
            TraktUserLikeType.List.DisplayName().ShouldBe("List");
        }
    }
}
