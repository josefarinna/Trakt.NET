using System.Text.Json;

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
            TraktHiddenItemsSection.Dropped.ToJson().ShouldBe("dropped");
            ((TraktHiddenItemsSection)99).ToJson().ShouldBeNull();
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
            "dropped".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Dropped);

            string? nullValue = null;
            nullValue.ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Unspecified);
            "invalid".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Unspecified);
            "".ToTraktHiddenItemsSection().ShouldBe(TraktHiddenItemsSection.Unspecified);
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
            TraktHiddenItemsSection.Dropped.DisplayName().ShouldBe("Dropped");
            ((TraktHiddenItemsSection)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktHiddenItemsSectionJsonConverter()
        {
            var converter = new TraktHiddenItemsSectionJsonConverter();
            converter.CanConvert(typeof(TraktHiddenItemsSection)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktHiddenItemsSection.Calendar, options).ShouldBe("\"calendar\"");
            JsonSerializer.Deserialize<TraktHiddenItemsSection>("\"calendar\"", options).ShouldBe(TraktHiddenItemsSection.Calendar);
            JsonSerializer.Deserialize<TraktHiddenItemsSection>("\"\"", options).ShouldBe(TraktHiddenItemsSection.Unspecified);
        }
    }
}
