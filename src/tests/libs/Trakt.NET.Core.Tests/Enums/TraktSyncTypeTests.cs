namespace TraktNET.Enums
{
    public sealed class TraktSyncTypeTests
    {
        [Fact]
        public void TestTraktSyncTypeToJson()
        {
            TraktSyncType.Unspecified.ToJson().Should().BeNull();
            TraktSyncType.Movie.ToJson().Should().Be("movie");
            TraktSyncType.Episode.ToJson().Should().Be("episode");
        }

        [Fact]
        public void TestTraktSyncTypeFromJson()
        {
            "unspecified".ToTraktSyncType().Should().Be(TraktSyncType.Unspecified);
            "movie".ToTraktSyncType().Should().Be(TraktSyncType.Movie);
            "episode".ToTraktSyncType().Should().Be(TraktSyncType.Episode);

            string? nullValue = null;
            nullValue.ToTraktSyncType().Should().Be(TraktSyncType.Unspecified);
        }

        [Fact]
        public void TestTraktSyncTypeDisplayName()
        {
            TraktSyncType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktSyncType.Movie.DisplayName().Should().Be("Movie");
            TraktSyncType.Episode.DisplayName().Should().Be("Episode");
        }
    }
}
