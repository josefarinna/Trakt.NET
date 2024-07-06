namespace TraktNET.Enums
{
    public sealed class TraktHiddenItemsSectionTests
    {
        [Fact]
        public void TestTraktHiddenItemsSectionToJson()
        {
            TraktHiddenItemsSection.Unspecified.ToJson().Should().BeNull();
            TraktHiddenItemsSection.Calendar.ToJson().Should().Be("calendar");
            TraktHiddenItemsSection.ProgressWatched.ToJson().Should().Be("progress_watched");
            TraktHiddenItemsSection.ProgressCollected.ToJson().Should().Be("progress_collected");
            TraktHiddenItemsSection.Recommendations.ToJson().Should().Be("recommendations");
            TraktHiddenItemsSection.ProgressWatchedReset.ToJson().Should().Be("progress_watched_reset");
            TraktHiddenItemsSection.Comments.ToJson().Should().Be("comments");
        }

        [Fact]
        public void TestTraktHiddenItemsSectionFromJson()
        {
            "unspecified".ToTraktHiddenItemsSection().Should().Be(TraktHiddenItemsSection.Unspecified);
            "calendar".ToTraktHiddenItemsSection().Should().Be(TraktHiddenItemsSection.Calendar);
            "progress_watched".ToTraktHiddenItemsSection().Should().Be(TraktHiddenItemsSection.ProgressWatched);
            "progress_collected".ToTraktHiddenItemsSection().Should().Be(TraktHiddenItemsSection.ProgressCollected);
            "recommendations".ToTraktHiddenItemsSection().Should().Be(TraktHiddenItemsSection.Recommendations);
            "progress_watched_reset".ToTraktHiddenItemsSection().Should().Be(TraktHiddenItemsSection.ProgressWatchedReset);
            "comments".ToTraktHiddenItemsSection().Should().Be(TraktHiddenItemsSection.Comments);

            string? nullValue = null;
            nullValue.ToTraktHiddenItemsSection().Should().Be(TraktHiddenItemsSection.Unspecified);
        }

        [Fact]
        public void TestTraktHiddenItemsSectionDisplayName()
        {
            TraktHiddenItemsSection.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktHiddenItemsSection.Calendar.DisplayName().Should().Be("Calendar");
            TraktHiddenItemsSection.ProgressWatched.DisplayName().Should().Be("Progress Watched");
            TraktHiddenItemsSection.ProgressCollected.DisplayName().Should().Be("Progress Collected");
            TraktHiddenItemsSection.Recommendations.DisplayName().Should().Be("Recommendations");
            TraktHiddenItemsSection.ProgressWatchedReset.DisplayName().Should().Be("Progress Watched Reset");
            TraktHiddenItemsSection.Comments.DisplayName().Should().Be("Comments");
        }
    }
}
