namespace TraktNET.Enums
{
    public sealed class TraktWatchlistSortOrderTests
    {
        [Fact]
        public void TestTraktWatchlistSortOrderToJson()
        {
            TraktWatchlistSortOrder.Unspecified.ToJson().Should().BeNull();
            TraktWatchlistSortOrder.Rank.ToJson().Should().Be("rank");
            TraktWatchlistSortOrder.Added.ToJson().Should().Be("added");
            TraktWatchlistSortOrder.Released.ToJson().Should().Be("released");
            TraktWatchlistSortOrder.Title.ToJson().Should().Be("title");
        }

        [Fact]
        public void TestTraktWatchlistSortOrderFromJson()
        {
            "unspecified".ToTraktWatchlistSortOrder().Should().Be(TraktWatchlistSortOrder.Unspecified);
            "rank".ToTraktWatchlistSortOrder().Should().Be(TraktWatchlistSortOrder.Rank);
            "added".ToTraktWatchlistSortOrder().Should().Be(TraktWatchlistSortOrder.Added);
            "released".ToTraktWatchlistSortOrder().Should().Be(TraktWatchlistSortOrder.Released);
            "title".ToTraktWatchlistSortOrder().Should().Be(TraktWatchlistSortOrder.Title);

            string? nullValue = null;
            nullValue.ToTraktWatchlistSortOrder().Should().Be(TraktWatchlistSortOrder.Unspecified);
        }

        [Fact]
        public void TestTraktWatchlistSortOrderDisplayName()
        {
            TraktWatchlistSortOrder.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktWatchlistSortOrder.Rank.DisplayName().Should().Be("Rank");
            TraktWatchlistSortOrder.Added.DisplayName().Should().Be("Added");
            TraktWatchlistSortOrder.Released.DisplayName().Should().Be("Released");
            TraktWatchlistSortOrder.Title.DisplayName().Should().Be("Title");
        }
    }
}
