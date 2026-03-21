namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentItemTests
    {
        [Fact]
        public void TestITraktCommentItemDefaultConstructor()
        {
            var commentItem = new TraktCommentItem();

            commentItem.Type.ShouldBeNull();
            commentItem.Movie.ShouldBeNull();
            commentItem.Show.ShouldBeNull();
            commentItem.Season.ShouldBeNull();
            commentItem.Episode.ShouldBeNull();
            commentItem.List.ShouldBeNull();
        }

        [Fact]
        public async Task TestITraktCommentItemFromJson()
        {
            TraktCommentItem? commentItem = await TestUtility.DeserializeJsonAsync<TraktCommentItem>("Comments\\commentitem.json");

            commentItem.ShouldNotBeNull();
            commentItem.Type.ShouldBe(TraktCommentObjectType.Movie);

            commentItem.Movie.ShouldNotBeNull();
            commentItem.Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            commentItem.Movie.Year.ShouldBe(2015U);
            commentItem.Movie.IDs.ShouldNotBeNull();
            commentItem.Movie.IDs.Trakt.ShouldBe(94024U);
            commentItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            commentItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            commentItem.Movie.IDs.TMDB.ShouldBe(140607U);

            commentItem.Show.ShouldNotBeNull();
            commentItem.Show.Title.ShouldBe("Game of Thrones");
            commentItem.Show.Year.ShouldBe(2011U);
            commentItem.Show.IDs.ShouldNotBeNull();
            commentItem.Show.IDs.Trakt.ShouldBe(1390U);
            commentItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            commentItem.Show.IDs.TVDB.ShouldBe(121361U);
            commentItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            commentItem.Show.IDs.TMDB.ShouldBe(1399U);

            commentItem.Season.ShouldNotBeNull();
            commentItem.Season.Number.ShouldBe(1U);
            commentItem.Season.IDs.ShouldNotBeNull();
            commentItem.Season.IDs.Trakt.ShouldBe(61430U);
            commentItem.Season.IDs.TVDB.ShouldBe(279121U);
            commentItem.Season.IDs.TMDB.ShouldBe(60523U);

            commentItem.Episode.ShouldNotBeNull();
            commentItem.Episode.Season.ShouldBe(1U);
            commentItem.Episode.Number.ShouldBe(1U);
            commentItem.Episode.Title.ShouldBe("Winter Is Coming");
            commentItem.Episode.IDs.ShouldNotBeNull();
            commentItem.Episode.IDs.Trakt.ShouldBe(73640U);
            commentItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            commentItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            commentItem.Episode.IDs.TMDB.ShouldBe(63056U);

            commentItem.List.ShouldNotBeNull();
            commentItem.List.Name.ShouldBe("Star Wars in machete order");
            commentItem.List.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            commentItem.List.Privacy.ShouldBe(TraktListPrivacy.Public);
            commentItem.List.DisplayNumbers!.Value.ShouldBeTrue();
            commentItem.List.AllowComments!.Value.ShouldBeFalse();
            commentItem.List.SortBy.ShouldBe(TraktSortBy.Rank);
            commentItem.List.SortHow.ShouldBe(TraktSortHow.Ascending);
            commentItem.List.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            commentItem.List.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            commentItem.List.ItemCount.ShouldBe(5U);
            commentItem.List.CommentCount.ShouldBe(1U);
            commentItem.List.Likes.ShouldBe(2U);
            commentItem.List.IDs.ShouldNotBeNull();
            commentItem.List.IDs.Trakt.ShouldBe(55U);
            commentItem.List.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            commentItem.List.User.ShouldNotBeNull();
            commentItem.List.User.Username.ShouldBe("sean");
            commentItem.List.User.Private.ShouldBe(false);
            commentItem.List.User.Name.ShouldBe("Sean Rudford");
            commentItem.List.User.VIP.ShouldBe(true);
            commentItem.List.User.VIPEP.ShouldBe(false);
            commentItem.List.User.IDs.ShouldNotBeNull();
            commentItem.List.User.IDs.Slug.ShouldBe("sean");
        }
    }
}
