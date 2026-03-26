namespace TraktNET.Json.Lists
{
    public sealed partial class TraktPopularListTests
    {
        [Fact]
        public void TestPopularListDefaultConstructor()
        {
            var popularList = new TraktPopularList();

            popularList.LikeCount.ShouldBeNull();
            popularList.CommentCount.ShouldBeNull();
            popularList.List.ShouldBeNull();
        }

        [Fact]
        public async Task TestPopularListFromJson()
        {
            TraktPopularList? popularList = await TestUtility.DeserializeJsonAsync<TraktPopularList>("Lists\\listpopular.json");

            popularList.ShouldNotBeNull();
            popularList.LikeCount.ShouldBe(5);
            popularList.CommentCount.ShouldBe(5);

            popularList.List.ShouldNotBeNull();
            popularList.List.Name.ShouldBe("Incredible Thoughts");
            popularList.List.Description.ShouldBe("How could my brain conceive them?");
            popularList.List.Privacy.ShouldBe(TraktListPrivacy.Public);
            popularList.List.ShareLink.ShouldBe("https://trakt.tv/lists/1337");
            popularList.List.Type.ShouldBe(TraktListType.Personal);
            popularList.List.DisplayNumbers.ShouldBe(true);
            popularList.List.AllowComments.ShouldBe(true);
            popularList.List.SortBy.ShouldBe(TraktSortBy.Rank);
            popularList.List.SortHow.ShouldBe(TraktSortHow.Ascending);
            popularList.List.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            popularList.List.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            popularList.List.ItemCount.ShouldBe(50U);
            popularList.List.CommentCount.ShouldBe(10U);
            popularList.List.Likes.ShouldBe(99U);

            popularList.List.IDs.ShouldNotBeNull();
            popularList.List.IDs.Trakt.ShouldBe(1337U);
            popularList.List.IDs.Slug.ShouldBe("incredible-thoughts");

            popularList.List.User.ShouldNotBeNull();
            popularList.List.User.Username.ShouldBe("justin");
            popularList.List.User.Private.ShouldBe(false);
            popularList.List.User.Name.ShouldBe("Justin Nemeth");
            popularList.List.User.VIP.ShouldBe(true);
            popularList.List.User.VIPEP.ShouldBe(false);

            popularList.List.User.IDs.ShouldNotBeNull();
            popularList.List.User.IDs.Slug.ShouldBe("justin");
        }
    }
}
