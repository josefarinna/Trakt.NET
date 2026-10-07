namespace TraktNET.Json.Episodes
{
    public sealed class TraktEpisodeCollectionProgressTests
    {
        [Fact]
        public void TestTraktEpisodeCollectionProgressConstructor()
        {
            var episodeProgress = new TraktEpisodeCollectionProgress();

            episodeProgress.Number.ShouldBeNull();
            episodeProgress.Completed.ShouldBeNull();
            episodeProgress.CollectedAt.ShouldBeNull();
        }
    }
}
