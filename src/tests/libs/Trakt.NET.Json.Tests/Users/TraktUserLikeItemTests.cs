namespace TraktNET.Json.Users
{
    public sealed class TraktUserLikeItemTests
    {
        [Fact]
        public void TestTraktUserLikeItemDefaultConstructor()
        {
            var likeItem = new TraktUserLikeItem();

            likeItem.LikedAt.ShouldBeNull();
            likeItem.Type.ShouldBeNull();
            likeItem.Comment.ShouldBeNull();
            likeItem.List.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserLikeItemWithTypeCommentFromJson()
        {
            TraktUserLikeItem? likeItem = await TestUtility.DeserializeJsonAsync<TraktUserLikeItem>("Users\\userlikeitem_comment.json");

            likeItem.ShouldNotBeNull();
            likeItem.ShouldNotBeNull();
            likeItem.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-03-30T23:18:42.000Z"));
            likeItem.Type.ShouldBe(TraktUserLikeType.Comment);
            likeItem.Comment.ShouldNotBeNull();
            likeItem.Comment.ID.ShouldBe(76957U);
            likeItem.Comment.ParentID.ShouldBe(1234U);
            likeItem.Comment.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-01T12:44:40Z"));
            likeItem.Comment.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-03T08:23:38Z"));
            likeItem.Comment.Comment.ShouldBe("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            likeItem.Comment.Spoiler.ShouldBe(false);
            likeItem.Comment.Review.ShouldBe(false);
            likeItem.Comment.Replies.ShouldBe(1U);
            likeItem.Comment.Likes.ShouldBe(2U);
            likeItem.Comment.UserStats.ShouldNotBeNull();
            likeItem.Comment.UserStats.Rating.ShouldBe(8U);
            likeItem.Comment.UserStats.PlayCount.ShouldBe(1U);
            likeItem.Comment.UserStats.CompletedCount.ShouldBe(1U);
            likeItem.Comment.User.ShouldNotBeNull();
            likeItem.Comment.User.Username.ShouldBe("sean");
            likeItem.Comment.User.Private.ShouldBe(false);
            likeItem.Comment.User.Name.ShouldBe("Sean Rudford");
            likeItem.Comment.User.VIP.ShouldBe(true);
            likeItem.Comment.User.VIPEP.ShouldBe(true);
            likeItem.Comment.User.IDs.ShouldNotBeNull();
            likeItem.Comment.User.IDs.Slug.ShouldBe("sean");
            likeItem.List.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserLikeItemWithTypeListFromJson()
        {
            TraktUserLikeItem? likeItem = await TestUtility.DeserializeJsonAsync<TraktUserLikeItem>("Users\\userlikeitem_list.json");

            likeItem.ShouldNotBeNull();
            likeItem.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-03-30T23:18:42.000Z"));
            likeItem.Type.ShouldBe(TraktUserLikeType.List);
            likeItem.List.ShouldNotBeNull();
            likeItem.List.Name.ShouldBe("Star Wars in machete order");
            likeItem.List.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            likeItem.List.Privacy.ShouldBe(TraktListPrivacy.Public);
            likeItem.List.DisplayNumbers.ShouldBe(true);
            likeItem.List.AllowComments.ShouldBe(false);
            likeItem.List.SortBy.ShouldBe(TraktSortBy.Rank);
            likeItem.List.SortHow.ShouldBe(TraktSortHow.Ascending);
            likeItem.List.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            likeItem.List.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            likeItem.List.ItemCount.ShouldBe(5U);
            likeItem.List.CommentCount.ShouldBe(1U);
            likeItem.List.Likes.ShouldBe(2U);
            likeItem.List.IDs.ShouldNotBeNull();
            likeItem.List.IDs.Trakt.ShouldBe(55U);
            likeItem.List.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            likeItem.List.User.ShouldNotBeNull();
            likeItem.List.User.Username.ShouldBe("sean");
            likeItem.List.User.Private.ShouldBe(false);
            likeItem.List.User.Name.ShouldBe("Sean Rudford");
            likeItem.List.User.VIP.ShouldBe(true);
            likeItem.List.User.VIPEP.ShouldBe(false);
            likeItem.List.User.IDs.ShouldNotBeNull();
            likeItem.List.User.IDs.Slug.ShouldBe("sean");
            likeItem.Comment.ShouldBeNull();
        }
    }
}
