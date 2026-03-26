namespace TraktNET.Json.Lists
{
    public sealed partial class TraktTrendingListTests
    {
        [Fact]
        public void TestTrendingListDefaultConstructor()
        {
            var trendingList = new TraktTrendingList();

            trendingList.LikeCount.ShouldBeNull();
            trendingList.CommentCount.ShouldBeNull();
            trendingList.List.ShouldBeNull();
        }

        [Fact]
        public async Task TestTrendingListFromJson()
        {
            TraktTrendingList? trendingList = await TestUtility.DeserializeJsonAsync<TraktTrendingList>("Lists\\listtrending.json");

            trendingList.ShouldNotBeNull();
            trendingList.LikeCount.ShouldBe(5);
            trendingList.CommentCount.ShouldBe(5);

            trendingList.List.ShouldNotBeNull();
            trendingList.List.Name.ShouldBe("Incredible Thoughts");
            trendingList.List.Description.ShouldBe("How could my brain conceive them?");
            trendingList.List.Privacy.ShouldBe(TraktListPrivacy.Public);
            trendingList.List.ShareLink.ShouldBe("https://trakt.tv/lists/1337");
            trendingList.List.Type.ShouldBe(TraktListType.Personal);
            trendingList.List.DisplayNumbers.ShouldBe(true);
            trendingList.List.AllowComments.ShouldBe(true);
            trendingList.List.SortBy.ShouldBe(TraktSortBy.Rank);
            trendingList.List.SortHow.ShouldBe(TraktSortHow.Ascending);
            trendingList.List.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            trendingList.List.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            trendingList.List.ItemCount.ShouldBe(50U);
            trendingList.List.CommentCount.ShouldBe(10U);
            trendingList.List.Likes.ShouldBe(99U);

            trendingList.List.IDs.ShouldNotBeNull();
            trendingList.List.IDs.Trakt.ShouldBe(1337U);
            trendingList.List.IDs.Slug.ShouldBe("incredible-thoughts");

            trendingList.List.User.ShouldNotBeNull();
            trendingList.List.User.Username.ShouldBe("justin");
            trendingList.List.User.Private.ShouldBe(false);
            trendingList.List.User.Name.ShouldBe("Justin Nemeth");
            trendingList.List.User.VIP.ShouldBe(true);
            trendingList.List.User.VIPEP.ShouldBe(false);

            trendingList.List.User.IDs.ShouldNotBeNull();
            trendingList.List.User.IDs.Slug.ShouldBe("justin");
        }
    }
}
