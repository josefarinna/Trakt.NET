namespace TraktNET.Enums
{
    public sealed class TraktListSortOrderTests
    {
        [Fact]
        public void TestTraktListSortOrderToJson()
        {
            TraktListSortOrder.Unspecified.ToJson().ShouldBeNull();
            TraktListSortOrder.Popular.ToJson().ShouldBe("popular");
            TraktListSortOrder.Likes.ToJson().ShouldBe("likes");
            TraktListSortOrder.Comments.ToJson().ShouldBe("comments");
            TraktListSortOrder.Items.ToJson().ShouldBe("items");
            TraktListSortOrder.Added.ToJson().ShouldBe("added");
            TraktListSortOrder.Updated.ToJson().ShouldBe("updated");
        }

        [Fact]
        public void TestTraktListSortOrderFromJson()
        {
            "unspecified".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Unspecified);
            "popular".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Popular);
            "likes".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Likes);
            "comments".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Comments);
            "items".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Items);
            "added".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Added);
            "updated".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Updated);

            string? nullValue = null;
            nullValue.ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Unspecified);
        }

        [Fact]
        public void TestTraktListSortOrderDisplayName()
        {
            TraktListSortOrder.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktListSortOrder.Popular.DisplayName().ShouldBe("Popular");
            TraktListSortOrder.Likes.DisplayName().ShouldBe("Likes");
            TraktListSortOrder.Comments.DisplayName().ShouldBe("Comments");
            TraktListSortOrder.Items.DisplayName().ShouldBe("Items");
            TraktListSortOrder.Added.DisplayName().ShouldBe("Added");
            TraktListSortOrder.Updated.DisplayName().ShouldBe("Updated");
        }
    }
}
