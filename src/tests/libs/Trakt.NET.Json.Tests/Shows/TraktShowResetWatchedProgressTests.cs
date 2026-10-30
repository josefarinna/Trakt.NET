namespace TraktNET.Json.Shows
{
    public sealed class TraktShowResetWatchedProgressTests
    {
        [Fact]
        public void TestTraktShowResetWatchedProgressDefaultConstructor()
        {
            var resetWatchedProgress = new TraktShowResetWatchedProgress();

            resetWatchedProgress.ResetAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktShowResetWatchedProgressFromJson()
        {
            TraktShowResetWatchedProgress? resetWatchedProgress = await TestUtility.DeserializeJsonAsync<TraktShowResetWatchedProgress>("Shows\\showresetwatchedprogress.json");

            resetWatchedProgress.ShouldNotBeNull();
            resetWatchedProgress!.ResetAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T19:08:15.000Z"));
        }

        [Fact]
        public void TestTraktShowResetWatchedProgressToJson()
        {
            var resetWatchedProgress = new TraktShowResetWatchedProgress
            {
                ResetAt = new DateTime(2024, 9, 23, 19, 8, 15, DateTimeKind.Utc)
            };

            string json = TestUtility.SerializeObject(resetWatchedProgress);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"reset_at\":\"2024-09-23T19:08:15Z\"");
        }
    }
}
