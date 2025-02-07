namespace TraktNET.Enums
{
    public sealed class TraktHiddenItemsSectionTests
    {
        [Fact]
        public void TestTraktHiddenItemsSectionToJson()
        {
            TraktHiddenItemsSection.Unspecified.ToJson().ShouldBeNull();
            TraktHiddenItemsSection.Calendar.ToJson().ShouldBe("calendar");
            TraktHiddenItemsSection.ProgressWatched.ToJson().ShouldBe("progress_watched");
            TraktHiddenItemsSection.ProgressCollected.ToJson().ShouldBe("progress_collected");
            TraktHiddenItemsSection.Recommendations.ToJson().ShouldBe("recommendations");
            TraktHiddenItemsSection.ProgressWatchedReset.ToJson().ShouldBe("progress_watched_reset");
            TraktHiddenItemsSection.Comments.ToJson().ShouldBe("comments");
        }

        [Fact]
        public void TestTraktHiddenItemsSectionFromJson()
        {
            "unspecified".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Unspecified);
            "calendar".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Calendar);
            "progress_watched".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.ProgressWatched);
            "progress_collected".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.ProgressCollected);
            "recommendations".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Recommendations);
            "progress_watched_reset".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.ProgressWatchedReset);
            "comments".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Comments);

            string? nullValue = null;
            nullValue.ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Unspecified);
        }

        [Fact]
        public void TestTraktHiddenItemsSectionDisplayName()
        {
            TraktHiddenItemsSection.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktHiddenItemsSection.Calendar.DisplayName().ShouldBe("Calendar");
            TraktHiddenItemsSection.ProgressWatched.DisplayName().ShouldBe("Progress Watched");
            TraktHiddenItemsSection.ProgressCollected.DisplayName().ShouldBe("Progress Collected");
            TraktHiddenItemsSection.Recommendations.DisplayName().ShouldBe("Recommendations");
            TraktHiddenItemsSection.ProgressWatchedReset.DisplayName().ShouldBe("Progress Watched Reset");
            TraktHiddenItemsSection.Comments.DisplayName().ShouldBe("Comments");
        }
    }
}
