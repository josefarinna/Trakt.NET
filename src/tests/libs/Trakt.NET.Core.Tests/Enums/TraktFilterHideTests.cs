using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktFilterHideTests
    {
        [Fact]
        public void TestTraktFilterHideToJson()
        {
            TraktFilterHide.Unspecified.ToJson().ShouldBeNull();
            TraktFilterHide.Unwatched.ToJson().ShouldBe("unwatched");
            TraktFilterHide.Collected.ToJson().ShouldBe("collected");
            TraktFilterHide.Uncollected.ToJson().ShouldBe("uncollected");
            TraktFilterHide.Rated.ToJson().ShouldBe("rated");
            TraktFilterHide.Unrated.ToJson().ShouldBe("unrated");
            TraktFilterHide.Unreleased.ToJson().ShouldBe("unreleased");
            TraktFilterHide.NoReleaseDate.ToJson().ShouldBe("noreleasedate");
            TraktFilterHide.Ended.ToJson().ShouldBe("ended");
            TraktFilterHide.Airing.ToJson().ShouldBe("airing");
            TraktFilterHide.Unwatchlisted.ToJson().ShouldBe("unwatchlisted");
            TraktFilterHide.Listed.ToJson().ShouldBe("listed");
            TraktFilterHide.Notes.ToJson().ShouldBe("notes");
            TraktFilterHide.NoNotes.ToJson().ShouldBe("nonotes");
            ((TraktFilterHide)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktFilterHideFromJson()
        {
            "unspecified".ToTraktFilterHide().ShouldBe(TraktFilterHide.Unspecified);
            "unwatched".ToTraktFilterHide().ShouldBe(TraktFilterHide.Unwatched);
            "collected".ToTraktFilterHide().ShouldBe(TraktFilterHide.Collected);
            "uncollected".ToTraktFilterHide().ShouldBe(TraktFilterHide.Uncollected);
            "rated".ToTraktFilterHide().ShouldBe(TraktFilterHide.Rated);
            "unrated".ToTraktFilterHide().ShouldBe(TraktFilterHide.Unrated);
            "unreleased".ToTraktFilterHide().ShouldBe(TraktFilterHide.Unreleased);
            "noreleasedate".ToTraktFilterHide().ShouldBe(TraktFilterHide.NoReleaseDate);
            "ended".ToTraktFilterHide().ShouldBe(TraktFilterHide.Ended);
            "airing".ToTraktFilterHide().ShouldBe(TraktFilterHide.Airing);
            "unwatchlisted".ToTraktFilterHide().ShouldBe(TraktFilterHide.Unwatchlisted);
            "listed".ToTraktFilterHide().ShouldBe(TraktFilterHide.Listed);
            "notes".ToTraktFilterHide().ShouldBe(TraktFilterHide.Notes);
            "nonotes".ToTraktFilterHide().ShouldBe(TraktFilterHide.NoNotes);

            string? nullValue = null;
            nullValue.ToTraktFilterHide().ShouldBe(TraktFilterHide.Unspecified);
            "invalid".ToTraktFilterHide().ShouldBe(TraktFilterHide.Unspecified);
            "".ToTraktFilterHide().ShouldBe(TraktFilterHide.Unspecified);
        }

        [Fact]
        public void TestTraktFilterHideToURI()
        {
            TraktFilterHide.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktFilterHide.Unwatched.ToURI().ShouldBe("unwatched");
            TraktFilterHide.Collected.ToURI().ShouldBe("collected");
            TraktFilterHide.Uncollected.ToURI().ShouldBe("uncollected");
            TraktFilterHide.Rated.ToURI().ShouldBe("rated");
            TraktFilterHide.Unrated.ToURI().ShouldBe("unrated");
            TraktFilterHide.Unreleased.ToURI().ShouldBe("unreleased");
            TraktFilterHide.NoReleaseDate.ToURI().ShouldBe("noreleasedate");
            TraktFilterHide.Ended.ToURI().ShouldBe("ended");
            TraktFilterHide.Airing.ToURI().ShouldBe("airing");
            TraktFilterHide.Unwatchlisted.ToURI().ShouldBe("unwatchlisted");
            TraktFilterHide.Listed.ToURI().ShouldBe("listed");
            TraktFilterHide.Notes.ToURI().ShouldBe("notes");
            TraktFilterHide.NoNotes.ToURI().ShouldBe("nonotes");
            ((TraktFilterHide)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktFilterHideDisplayName()
        {
            TraktFilterHide.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktFilterHide.Unwatched.DisplayName().ShouldBe("Unwatched");
            TraktFilterHide.Collected.DisplayName().ShouldBe("Collected");
            TraktFilterHide.Uncollected.DisplayName().ShouldBe("Uncollected");
            TraktFilterHide.Rated.DisplayName().ShouldBe("Rated");
            TraktFilterHide.Unrated.DisplayName().ShouldBe("Unrated");
            TraktFilterHide.Unreleased.DisplayName().ShouldBe("Unreleased");
            TraktFilterHide.NoReleaseDate.DisplayName().ShouldBe("No Release Date");
            TraktFilterHide.Ended.DisplayName().ShouldBe("Ended");
            TraktFilterHide.Airing.DisplayName().ShouldBe("Airing");
            TraktFilterHide.Unwatchlisted.DisplayName().ShouldBe("Unwatchlisted");
            TraktFilterHide.Listed.DisplayName().ShouldBe("Listed");
            TraktFilterHide.Notes.DisplayName().ShouldBe("Notes");
            TraktFilterHide.NoNotes.DisplayName().ShouldBe("No Notes");
            ((TraktFilterHide)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktFilterHideAsQuery()
        {
            TraktFilterHide.Unspecified.AsQuery().ShouldBe(string.Empty);
            TraktFilterHide.Unwatched.AsQuery().ShouldBe("hide=unwatched");
            TraktFilterHide.Collected.AsQuery().ShouldBe("hide=collected");
            TraktFilterHide.Uncollected.AsQuery().ShouldBe("hide=uncollected");
            TraktFilterHide.Rated.AsQuery().ShouldBe("hide=rated");
            TraktFilterHide.Unrated.AsQuery().ShouldBe("hide=unrated");
            TraktFilterHide.Unreleased.AsQuery().ShouldBe("hide=unreleased");
            TraktFilterHide.NoReleaseDate.AsQuery().ShouldBe("hide=noreleasedate");
            TraktFilterHide.Ended.AsQuery().ShouldBe("hide=ended");
            TraktFilterHide.Airing.AsQuery().ShouldBe("hide=airing");
            TraktFilterHide.Unwatchlisted.AsQuery().ShouldBe("hide=unwatchlisted");
            TraktFilterHide.Listed.AsQuery().ShouldBe("hide=listed");
            TraktFilterHide.Notes.AsQuery().ShouldBe("hide=notes");
            TraktFilterHide.NoNotes.AsQuery().ShouldBe("hide=nonotes");
            ((TraktFilterHide)99).AsQuery().ShouldBe("hide=");
        }

        [Fact]
        public void TestTraktFilterHideJsonConverter()
        {
            var converter = new TraktFilterHideJsonConverter();
            converter.CanConvert(typeof(TraktFilterHide)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktFilterHide.Unwatched, options).ShouldBe("\"unwatched\"");
            JsonSerializer.Deserialize<TraktFilterHide>("\"unwatched\"", options).ShouldBe(TraktFilterHide.Unwatched);
            JsonSerializer.Deserialize<TraktFilterHide>("\"\"", options).ShouldBe(TraktFilterHide.Unspecified);
        }
    }
}
