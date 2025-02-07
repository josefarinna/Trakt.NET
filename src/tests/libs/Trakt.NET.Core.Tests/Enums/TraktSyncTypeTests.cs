namespace TraktNET.Enums
{
    public sealed class TraktSyncTypeTests
    {
        [Fact]
        public void TestTraktSyncTypeToJson()
        {
            TraktSyncType.Unspecified.ToJson().ShouldBeNull();
            TraktSyncType.Movie.ToJson().ShouldBe("movie");
            TraktSyncType.Episode.ToJson().ShouldBe("episode");
        }

        [Fact]
        public void TestTraktSyncTypeFromJson()
        {
            "unspecified".ToTraktSyncType().ShouldBe(TraktSyncType.Unspecified);
            "movie".ToTraktSyncType().ShouldBe(TraktSyncType.Movie);
            "episode".ToTraktSyncType().ShouldBe(TraktSyncType.Episode);

            string? nullValue = null;
            nullValue.ToTraktSyncType().ShouldBe(TraktSyncType.Unspecified);
        }

        [Fact]
        public void TestTraktSyncTypeDisplayName()
        {
            TraktSyncType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSyncType.Movie.DisplayName().ShouldBe("Movie");
            TraktSyncType.Episode.DisplayName().ShouldBe("Episode");
        }
    }
}
