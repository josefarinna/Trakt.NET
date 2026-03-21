namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentPostResponseTests
    {
        [Fact]
        public void TestTraktCommentPostResponseDefaultConstructor()
        {
            var commentPostResponse = new TraktCommentPostResponse();

            commentPostResponse.ID.ShouldBeNull();
            commentPostResponse.ParentID.ShouldBeNull();
            commentPostResponse.CreatedAt.ShouldBe(default);
            commentPostResponse.UpdatedAt.ShouldBeNull();
            commentPostResponse.Comment.ShouldBeNull();
            commentPostResponse.Spoiler.ShouldBeNull();
            commentPostResponse.Review.ShouldBeNull();
            commentPostResponse.Replies.ShouldBeNull();
            commentPostResponse.Likes.ShouldBeNull();
            commentPostResponse.UserStats.ShouldBeNull();
            commentPostResponse.User.ShouldBeNull();
            commentPostResponse.Sharing.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCommentPostResponseFromJson()
        {
            TraktCommentPostResponse? commentPostResponse = await TestUtility.DeserializeJsonAsync<TraktCommentPostResponse>("Comments\\commentpostresponse.json");

            commentPostResponse.ShouldNotBeNull();
            commentPostResponse.ID.ShouldBe(76957U);
            commentPostResponse.ParentID.ShouldBe(1234U);
            commentPostResponse.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-01T12:44:40Z"));
            commentPostResponse.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-03T08:23:38Z"));
            commentPostResponse.Comment.ShouldBe("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            commentPostResponse.Spoiler.ShouldBe(false);
            commentPostResponse.Review.ShouldBe(false);
            commentPostResponse.Replies.ShouldBe(1U);
            commentPostResponse.Likes.ShouldBe(2U);

            commentPostResponse.UserStats.ShouldNotBeNull();
            commentPostResponse.UserStats!.Rating.ShouldBe(8U);
            commentPostResponse.UserStats.PlayCount.ShouldBe(1U);
            commentPostResponse.UserStats.CompletedCount.ShouldBe(1U);

            commentPostResponse.User.ShouldNotBeNull();
            commentPostResponse.User!.Username.ShouldBe("sean");
            commentPostResponse.User.Private.ShouldBe(false);
            commentPostResponse.User.Name.ShouldBe("Sean Rudford");
            commentPostResponse.User.VIP.ShouldBe(true);
            commentPostResponse.User.VIPEP.ShouldBe(true);

            commentPostResponse.User.IDs.ShouldNotBeNull();
            commentPostResponse.User.IDs!.Slug.ShouldBe("sean");

            commentPostResponse.Sharing.ShouldNotBeNull();
            commentPostResponse.Sharing!.Twitter.ShouldBe(true);
            commentPostResponse.Sharing.Tumblr.ShouldBe(true);
        }
    }
}
