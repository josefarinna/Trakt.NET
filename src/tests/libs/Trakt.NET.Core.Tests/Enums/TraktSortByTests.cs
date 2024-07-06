namespace TraktNET.Enums
{
    public sealed class TraktSortByTests
    {
        [Fact]
        public void TestTraktSortByToJson()
        {
            TraktSortBy.Unspecified.ToJson().Should().BeNull();
            TraktSortBy.Rank.ToJson().Should().Be("rank");
            TraktSortBy.Added.ToJson().Should().Be("added");
            TraktSortBy.Title.ToJson().Should().Be("title");
            TraktSortBy.Released.ToJson().Should().Be("released");
            TraktSortBy.Runtime.ToJson().Should().Be("runtime");
            TraktSortBy.Popularity.ToJson().Should().Be("popularity");
            TraktSortBy.Percentage.ToJson().Should().Be("percentage");
            TraktSortBy.Votes.ToJson().Should().Be("votes");
            TraktSortBy.MyRating.ToJson().Should().Be("my_rating");
            TraktSortBy.Random.ToJson().Should().Be("random");
            TraktSortBy.Watched.ToJson().Should().Be("watched");
            TraktSortBy.Collected.ToJson().Should().Be("collected");
        }

        [Fact]
        public void TestTraktSortByFromJson()
        {
            "unspecified".ToTraktSortBy().Should().Be(TraktSortBy.Unspecified);
            "rank".ToTraktSortBy().Should().Be(TraktSortBy.Rank);
            "added".ToTraktSortBy().Should().Be(TraktSortBy.Added);
            "title".ToTraktSortBy().Should().Be(TraktSortBy.Title);
            "released".ToTraktSortBy().Should().Be(TraktSortBy.Released);
            "runtime".ToTraktSortBy().Should().Be(TraktSortBy.Runtime);
            "popularity".ToTraktSortBy().Should().Be(TraktSortBy.Popularity);
            "percentage".ToTraktSortBy().Should().Be(TraktSortBy.Percentage);
            "votes".ToTraktSortBy().Should().Be(TraktSortBy.Votes);
            "my_rating".ToTraktSortBy().Should().Be(TraktSortBy.MyRating);
            "random".ToTraktSortBy().Should().Be(TraktSortBy.Random);
            "watched".ToTraktSortBy().Should().Be(TraktSortBy.Watched);
            "collected".ToTraktSortBy().Should().Be(TraktSortBy.Collected);

            string? nullValue = null;
            nullValue.ToTraktSortBy().Should().Be(TraktSortBy.Unspecified);
        }

        [Fact]
        public void TestTraktSortByDisplayName()
        {
            TraktSortBy.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktSortBy.Rank.DisplayName().Should().Be("Rank");
            TraktSortBy.Added.DisplayName().Should().Be("Added");
            TraktSortBy.Title.DisplayName().Should().Be("Title");
            TraktSortBy.Released.DisplayName().Should().Be("Released");
            TraktSortBy.Runtime.DisplayName().Should().Be("Runtime");
            TraktSortBy.Popularity.DisplayName().Should().Be("Popularity");
            TraktSortBy.Percentage.DisplayName().Should().Be("Percentage");
            TraktSortBy.Votes.DisplayName().Should().Be("Votes");
            TraktSortBy.MyRating.DisplayName().Should().Be("My Rating");
            TraktSortBy.Random.DisplayName().Should().Be("Random");
            TraktSortBy.Watched.DisplayName().Should().Be("Watched");
            TraktSortBy.Collected.DisplayName().Should().Be("Collected");
        }
    }
}
