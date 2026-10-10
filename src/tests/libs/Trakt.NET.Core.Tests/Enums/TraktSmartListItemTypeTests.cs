using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSmartListItemTypeTests
    {
        [Fact]
        public void TestTraktSmartListItemTypeToJson()
        {
            TraktSmartListItemType.Unspecified.ToJson().ShouldBeNull();
            TraktSmartListItemType.All.ToJson().ShouldBe("all");
            TraktSmartListItemType.Movies.ToJson().ShouldBe("movies");
            TraktSmartListItemType.Shows.ToJson().ShouldBe("shows");
            ((TraktSmartListItemType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSmartListItemTypeFromJson()
        {
            "unspecified".ToTraktSmartListItemType().ShouldBe(TraktSmartListItemType.Unspecified);
            "all".ToTraktSmartListItemType().ShouldBe(TraktSmartListItemType.All);
            "movies".ToTraktSmartListItemType().ShouldBe(TraktSmartListItemType.Movies);
            "shows".ToTraktSmartListItemType().ShouldBe(TraktSmartListItemType.Shows);

            string? nullValue = null;
            nullValue.ToTraktSmartListItemType().ShouldBe(TraktSmartListItemType.Unspecified);
            "invalid".ToTraktSmartListItemType().ShouldBe(TraktSmartListItemType.Unspecified);
            "".ToTraktSmartListItemType().ShouldBe(TraktSmartListItemType.Unspecified);
        }

        [Fact]
        public void TestTraktSmartListItemTypeToURI()
        {
            TraktSmartListItemType.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktSmartListItemType.All.ToURI().ShouldBe("all");
            TraktSmartListItemType.Movies.ToURI().ShouldBe("movies");
            TraktSmartListItemType.Shows.ToURI().ShouldBe("shows");
            ((TraktSmartListItemType)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktSmartListItemTypeAsPathParameter()
        {
            TraktSmartListItemType.Unspecified.AsPathParameter().ShouldBe(string.Empty);
            TraktSmartListItemType.All.AsPathParameter().ShouldBe("all");
            TraktSmartListItemType.Movies.AsPathParameter().ShouldBe("movies");
            TraktSmartListItemType.Shows.AsPathParameter().ShouldBe("shows");
            ((TraktSmartListItemType)99).AsPathParameter().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktSmartListItemTypeDisplayName()
        {
            TraktSmartListItemType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSmartListItemType.All.DisplayName().ShouldBe("All");
            TraktSmartListItemType.Movies.DisplayName().ShouldBe("Movies");
            TraktSmartListItemType.Shows.DisplayName().ShouldBe("Shows");
            ((TraktSmartListItemType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSmartListItemTypeJsonConverter()
        {
            var converter = new TraktSmartListItemTypeJsonConverter();
            converter.CanConvert(typeof(TraktSmartListItemType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSmartListItemType.Movies, options).ShouldBe("\"movies\"");
            JsonSerializer.Deserialize<TraktSmartListItemType>("\"movies\"", options).ShouldBe(TraktSmartListItemType.Movies);
            JsonSerializer.Deserialize<TraktSmartListItemType>("\"\"", options).ShouldBe(TraktSmartListItemType.Unspecified);
        }
    }
}

