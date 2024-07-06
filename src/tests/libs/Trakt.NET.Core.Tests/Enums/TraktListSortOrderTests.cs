namespace TraktNET.Enums
{
    public sealed class TraktListSortOrderTests
    {
        [Fact]
        public void TestTraktListSortOrderToJson()
        {
            TraktListSortOrder.Unspecified.ToJson().Should().BeNull();
            TraktListSortOrder.Popular.ToJson().Should().Be("popular");
            TraktListSortOrder.Likes.ToJson().Should().Be("likes");
            TraktListSortOrder.Comments.ToJson().Should().Be("comments");
            TraktListSortOrder.Items.ToJson().Should().Be("items");
            TraktListSortOrder.Added.ToJson().Should().Be("added");
            TraktListSortOrder.Updated.ToJson().Should().Be("updated");
        }

        [Fact]
        public void TestTraktListSortOrderFromJson()
        {
            "unspecified".ToTraktListSortOrder().Should().Be(TraktListSortOrder.Unspecified);
            "popular".ToTraktListSortOrder().Should().Be(TraktListSortOrder.Popular);
            "likes".ToTraktListSortOrder().Should().Be(TraktListSortOrder.Likes);
            "comments".ToTraktListSortOrder().Should().Be(TraktListSortOrder.Comments);
            "items".ToTraktListSortOrder().Should().Be(TraktListSortOrder.Items);
            "added".ToTraktListSortOrder().Should().Be(TraktListSortOrder.Added);
            "updated".ToTraktListSortOrder().Should().Be(TraktListSortOrder.Updated);

            string? nullValue = null;
            nullValue.ToTraktListSortOrder().Should().Be(TraktListSortOrder.Unspecified);
        }

        [Fact]
        public void TestTraktListSortOrderDisplayName()
        {
            TraktListSortOrder.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktListSortOrder.Popular.DisplayName().Should().Be("Popular");
            TraktListSortOrder.Likes.DisplayName().Should().Be("Likes");
            TraktListSortOrder.Comments.DisplayName().Should().Be("Comments");
            TraktListSortOrder.Items.DisplayName().Should().Be("Items");
            TraktListSortOrder.Added.DisplayName().Should().Be("Added");
            TraktListSortOrder.Updated.DisplayName().Should().Be("Updated");
        }
    }
}
