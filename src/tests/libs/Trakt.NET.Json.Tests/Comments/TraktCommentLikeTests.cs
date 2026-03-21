namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentLikeTests
    {
        [Fact]
        public void TestITraktCommentLikeDefaultConstructor()
        {
            var commentLike = new TraktCommentLike();

            commentLike.LikedAt.ShouldBeNull();
            commentLike.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestITraktCommentLikeFromJson()
        {
            TraktCommentLike? commentLike = await TestUtility.DeserializeJsonAsync<TraktCommentLike>("Comments\\commentlike.json");

            commentLike.ShouldNotBeNull();
            commentLike.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));

            commentLike.User.ShouldNotBeNull();
            commentLike.User!.Username.ShouldBe("sean");
            commentLike.User.Private.ShouldBe(false);
            commentLike.User.Name.ShouldBe("Sean Rudford");
            commentLike.User.VIP.ShouldBe(true);
            commentLike.User.VIPEP.ShouldBe(false);

            commentLike.User.IDs.ShouldNotBeNull();
            commentLike.User.IDs!.Slug.ShouldBe("sean");
        }
    }
}
