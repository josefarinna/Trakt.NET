namespace TraktNET.Enums
{
    public sealed class TraktSyncItemTypeTests
    {
        [Fact]
        public void TestTraktSyncItemTypeToJson()
        {
            TraktSyncItemType.Unspecified.ToJson().ShouldBeNull();
            TraktSyncItemType.Movie.ToJson().ShouldBe("movie");
            TraktSyncItemType.Show.ToJson().ShouldBe("show");
            TraktSyncItemType.Season.ToJson().ShouldBe("season");
            TraktSyncItemType.Episode.ToJson().ShouldBe("episode");
        }

        [Fact]
        public void TestTraktSyncItemTypeFromJson()
        {
            "unspecified".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Unspecified);
            "movie".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Movie);
            "show".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Show);
            "season".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Season);
            "episode".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Episode);

            string? nullValue = null;
            nullValue.ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Unspecified);
        }

        [Fact]
        public void TestTraktSyncItemTypeDisplayName()
        {
            TraktSyncItemType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSyncItemType.Movie.DisplayName().ShouldBe("Movie");
            TraktSyncItemType.Show.DisplayName().ShouldBe("Show");
            TraktSyncItemType.Season.DisplayName().ShouldBe("Season");
            TraktSyncItemType.Episode.DisplayName().ShouldBe("Episode");
        }
    }
}
