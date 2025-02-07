namespace TraktNET.Enums
{
    public sealed class TraktWatchlistSortOrderTests
    {
        [Fact]
        public void TestTraktWatchlistSortOrderToJson()
        {
            TraktWatchlistSortOrder.Unspecified.ToJson().ShouldBeNull();
            TraktWatchlistSortOrder.Rank.ToJson().ShouldBe("rank");
            TraktWatchlistSortOrder.Added.ToJson().ShouldBe("added");
            TraktWatchlistSortOrder.Released.ToJson().ShouldBe("released");
            TraktWatchlistSortOrder.Title.ToJson().ShouldBe("title");
        }

        [Fact]
        public void TestTraktWatchlistSortOrderFromJson()
        {
            "unspecified".ToTraktWatchlistSortOrder().ShouldBe(TraktWatchlistSortOrder.Unspecified);
            "rank".ToTraktWatchlistSortOrder().ShouldBe(TraktWatchlistSortOrder.Rank);
            "added".ToTraktWatchlistSortOrder().ShouldBe(TraktWatchlistSortOrder.Added);
            "released".ToTraktWatchlistSortOrder().ShouldBe(TraktWatchlistSortOrder.Released);
            "title".ToTraktWatchlistSortOrder().ShouldBe(TraktWatchlistSortOrder.Title);

            string? nullValue = null;
            nullValue.ToTraktWatchlistSortOrder().ShouldBe(TraktWatchlistSortOrder.Unspecified);
        }

        [Fact]
        public void TestTraktWatchlistSortOrderDisplayName()
        {
            TraktWatchlistSortOrder.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktWatchlistSortOrder.Rank.DisplayName().ShouldBe("Rank");
            TraktWatchlistSortOrder.Added.DisplayName().ShouldBe("Added");
            TraktWatchlistSortOrder.Released.DisplayName().ShouldBe("Released");
            TraktWatchlistSortOrder.Title.DisplayName().ShouldBe("Title");
        }
    }
}
