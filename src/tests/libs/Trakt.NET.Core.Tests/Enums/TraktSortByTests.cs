namespace TraktNET.Enums
{
    public sealed class TraktSortByTests
    {
        [Fact]
        public void TestTraktSortByToJson()
        {
            TraktSortBy.Unspecified.ToJson().ShouldBeNull();
            TraktSortBy.Rank.ToJson().ShouldBe("rank");
            TraktSortBy.Added.ToJson().ShouldBe("added");
            TraktSortBy.Title.ToJson().ShouldBe("title");
            TraktSortBy.Released.ToJson().ShouldBe("released");
            TraktSortBy.Runtime.ToJson().ShouldBe("runtime");
            TraktSortBy.Popularity.ToJson().ShouldBe("popularity");
            TraktSortBy.Percentage.ToJson().ShouldBe("percentage");
            TraktSortBy.Votes.ToJson().ShouldBe("votes");
            TraktSortBy.MyRating.ToJson().ShouldBe("my_rating");
            TraktSortBy.Random.ToJson().ShouldBe("random");
            TraktSortBy.Watched.ToJson().ShouldBe("watched");
            TraktSortBy.Collected.ToJson().ShouldBe("collected");
        }

        [Fact]
        public void TestTraktSortByFromJson()
        {
            "unspecified".ToTraktSortBy().ShouldBe(TraktSortBy.Unspecified);
            "rank".ToTraktSortBy().ShouldBe(TraktSortBy.Rank);
            "added".ToTraktSortBy().ShouldBe(TraktSortBy.Added);
            "title".ToTraktSortBy().ShouldBe(TraktSortBy.Title);
            "released".ToTraktSortBy().ShouldBe(TraktSortBy.Released);
            "runtime".ToTraktSortBy().ShouldBe(TraktSortBy.Runtime);
            "popularity".ToTraktSortBy().ShouldBe(TraktSortBy.Popularity);
            "percentage".ToTraktSortBy().ShouldBe(TraktSortBy.Percentage);
            "votes".ToTraktSortBy().ShouldBe(TraktSortBy.Votes);
            "my_rating".ToTraktSortBy().ShouldBe(TraktSortBy.MyRating);
            "random".ToTraktSortBy().ShouldBe(TraktSortBy.Random);
            "watched".ToTraktSortBy().ShouldBe(TraktSortBy.Watched);
            "collected".ToTraktSortBy().ShouldBe(TraktSortBy.Collected);

            string? nullValue = null;
            nullValue.ToTraktSortBy().ShouldBe(TraktSortBy.Unspecified);
        }

        [Fact]
        public void TestTraktSortByDisplayName()
        {
            TraktSortBy.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSortBy.Rank.DisplayName().ShouldBe("Rank");
            TraktSortBy.Added.DisplayName().ShouldBe("Added");
            TraktSortBy.Title.DisplayName().ShouldBe("Title");
            TraktSortBy.Released.DisplayName().ShouldBe("Released");
            TraktSortBy.Runtime.DisplayName().ShouldBe("Runtime");
            TraktSortBy.Popularity.DisplayName().ShouldBe("Popularity");
            TraktSortBy.Percentage.DisplayName().ShouldBe("Percentage");
            TraktSortBy.Votes.DisplayName().ShouldBe("Votes");
            TraktSortBy.MyRating.DisplayName().ShouldBe("My Rating");
            TraktSortBy.Random.DisplayName().ShouldBe("Random");
            TraktSortBy.Watched.DisplayName().ShouldBe("Watched");
            TraktSortBy.Collected.DisplayName().ShouldBe("Collected");
        }
    }
}
