namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentTests
    {
        [Fact]
        public void TestTraktCommentConstructor()
        {
            var comment = new TraktComment();

            comment.ID.Should().BeNull();
            comment.ParentID.Should().BeNull();
            comment.Comment.Should().BeNull();
            comment.Spoiler.Should().BeNull();
            comment.Review.Should().BeNull();
            comment.Replies.Should().BeNull();
            comment.Likes.Should().BeNull();
            comment.CreatedAt.Should().BeNull();
            comment.UpdatedAt.Should().BeNull();
            comment.UserStats.Should().BeNull();
            comment.User.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCommentFromJson()
        {
            TraktComment? comment = await TestUtility.DeserializeJsonAsync<TraktComment>("Comments\\comment.json");

            comment.Should().NotBeNull();

            comment!.ID.Should().Be(7149524U);
            comment!.ParentID.Should().Be(0U);
            comment!.Comment.Should().Be("Comment content.");
            comment!.Spoiler.Should().BeFalse();
            comment!.Review.Should().BeFalse();
            comment!.Replies.Should().Be(0U);
            comment!.Likes.Should().Be(0U);
            comment!.CreatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-10-04T16:25:36.000Z"));
            comment!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-10-04T16:25:36.000Z"));

            comment!.UserStats.Should().NotBeNull();
            comment!.UserStats!.Rating.Should().Be(9U);
            comment!.UserStats!.PlayCount.Should().Be(3U);
            comment!.UserStats!.CompletedCount.Should().Be(1U);

            comment!.User.Should().NotBeNull();
            comment!.User!.Username.Should().Be("user1");
            comment!.User!.Private.Should().BeTrue();
            comment!.User!.IDs.Should().NotBeNull();
            comment!.User!.IDs!.Slug.Should().Be("user1");
        }
    }
}
