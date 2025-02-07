namespace TraktNET.Enums
{
    public sealed class TraktRatingsItemTypeTests
    {
        [Fact]
        public void TestTraktRatingsItemTypeToJson()
        {
            TraktRatingsItemType.Unspecified.ToJson().ShouldBeNull();
            TraktRatingsItemType.Movie.ToJson().ShouldBe("movie");
            TraktRatingsItemType.Show.ToJson().ShouldBe("show");
            TraktRatingsItemType.Season.ToJson().ShouldBe("season");
            TraktRatingsItemType.Episode.ToJson().ShouldBe("episode");
            TraktRatingsItemType.All.ToJson().ShouldBe("all");
        }

        [Fact]
        public void TestTraktRatingsItemTypeFromJson()
        {
            "unspecified".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Unspecified);
            "movie".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Movie);
            "show".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Show);
            "season".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Season);
            "episode".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Episode);
            "all".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.All);

            string? nullValue = null;
            nullValue.ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Unspecified);
        }

        [Fact]
        public void TestTraktRatingsItemTypeDisplayName()
        {
            TraktRatingsItemType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktRatingsItemType.Movie.DisplayName().ShouldBe("Movie");
            TraktRatingsItemType.Show.DisplayName().ShouldBe("Show");
            TraktRatingsItemType.Season.DisplayName().ShouldBe("Season");
            TraktRatingsItemType.Episode.DisplayName().ShouldBe("Episode");
            TraktRatingsItemType.All.DisplayName().ShouldBe("All");
        }
    }
}
