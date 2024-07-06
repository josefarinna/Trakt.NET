namespace TraktNET.Enums
{
    public sealed class TraktCommentSortOrderTests
    {
        [Fact]
        public void TestTraktCommentSortOrderToJson()
        {
            TraktCommentSortOrder.Unspecified.ToJson().Should().BeNull();
            TraktCommentSortOrder.Newest.ToJson().Should().Be("newest");
            TraktCommentSortOrder.Oldest.ToJson().Should().Be("oldest");
            TraktCommentSortOrder.Likes.ToJson().Should().Be("likes");
            TraktCommentSortOrder.Replies.ToJson().Should().Be("replies");
            TraktCommentSortOrder.Highest.ToJson().Should().Be("highest");
            TraktCommentSortOrder.Lowest.ToJson().Should().Be("lowest");
            TraktCommentSortOrder.Plays.ToJson().Should().Be("plays");
            TraktCommentSortOrder.Watched.ToJson().Should().Be("watched");
        }

        [Fact]
        public void TestTraktCommentSortOrderFromJson()
        {
            "unspecified".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Unspecified);
            "newest".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Newest);
            "oldest".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Oldest);
            "likes".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Likes);
            "replies".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Replies);
            "highest".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Highest);
            "lowest".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Lowest);
            "plays".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Plays);
            "watched".ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Watched);

            string? nullValue = null;
            nullValue.ToTraktCommentSortOrder().Should().Be(TraktCommentSortOrder.Unspecified);
        }

        [Fact]
        public void TestTraktCommentSortOrderDisplayName()
        {
            TraktCommentSortOrder.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktCommentSortOrder.Newest.DisplayName().Should().Be("Newest");
            TraktCommentSortOrder.Oldest.DisplayName().Should().Be("Oldest");
            TraktCommentSortOrder.Likes.DisplayName().Should().Be("Likes");
            TraktCommentSortOrder.Replies.DisplayName().Should().Be("Replies");
            TraktCommentSortOrder.Highest.DisplayName().Should().Be("Highest");
            TraktCommentSortOrder.Lowest.DisplayName().Should().Be("Lowest");
            TraktCommentSortOrder.Plays.DisplayName().Should().Be("Plays");
            TraktCommentSortOrder.Watched.DisplayName().Should().Be("Watched");
        }
    }
}
