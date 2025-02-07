namespace TraktNET.Enums
{
    public sealed class TraktCommentSortOrderTests
    {
        [Fact]
        public void TestTraktCommentSortOrderToJson()
        {
            TraktCommentSortOrder.Unspecified.ToJson().ShouldBeNull();
            TraktCommentSortOrder.Newest.ToJson().ShouldBe("newest");
            TraktCommentSortOrder.Oldest.ToJson().ShouldBe("oldest");
            TraktCommentSortOrder.Likes.ToJson().ShouldBe("likes");
            TraktCommentSortOrder.Replies.ToJson().ShouldBe("replies");
            TraktCommentSortOrder.Highest.ToJson().ShouldBe("highest");
            TraktCommentSortOrder.Lowest.ToJson().ShouldBe("lowest");
            TraktCommentSortOrder.Plays.ToJson().ShouldBe("plays");
            TraktCommentSortOrder.Watched.ToJson().ShouldBe("watched");
        }

        [Fact]
        public void TestTraktCommentSortOrderFromJson()
        {
            "unspecified".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Unspecified);
            "newest".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Newest);
            "oldest".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Oldest);
            "likes".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Likes);
            "replies".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Replies);
            "highest".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Highest);
            "lowest".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Lowest);
            "plays".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Plays);
            "watched".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Watched);

            string? nullValue = null;
            nullValue.ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Unspecified);
        }

        [Fact]
        public void TestTraktCommentSortOrderDisplayName()
        {
            TraktCommentSortOrder.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCommentSortOrder.Newest.DisplayName().ShouldBe("Newest");
            TraktCommentSortOrder.Oldest.DisplayName().ShouldBe("Oldest");
            TraktCommentSortOrder.Likes.DisplayName().ShouldBe("Likes");
            TraktCommentSortOrder.Replies.DisplayName().ShouldBe("Replies");
            TraktCommentSortOrder.Highest.DisplayName().ShouldBe("Highest");
            TraktCommentSortOrder.Lowest.DisplayName().ShouldBe("Lowest");
            TraktCommentSortOrder.Plays.DisplayName().ShouldBe("Plays");
            TraktCommentSortOrder.Watched.DisplayName().ShouldBe("Watched");
        }
    }
}
