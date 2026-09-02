using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktEpisodeTypeTests
    {
        [Fact]
        public void TestTraktEpisodeTypeToJson()
        {
            TraktEpisodeType.Unspecified.ToJson().ShouldBeNull();
            TraktEpisodeType.Standard.ToJson().ShouldBe("standard");
            TraktEpisodeType.SeriesPremiere.ToJson().ShouldBe("series_premiere");
            TraktEpisodeType.SeasonPremiere.ToJson().ShouldBe("season_premiere");
            TraktEpisodeType.MidSeasonFinale.ToJson().ShouldBe("mid_season_finale");
            TraktEpisodeType.MidSeasonPremiere.ToJson().ShouldBe("mid_season_premiere");
            TraktEpisodeType.SeasonFinale.ToJson().ShouldBe("season_finale");
            TraktEpisodeType.SeriesFinale.ToJson().ShouldBe("series_finale");
            TraktEpisodeType.FullSeason.ToJson().ShouldBe("full_season");
            TraktEpisodeType.MultipleEpisodes.ToJson().ShouldBe("multiple_episodes");
            ((TraktEpisodeType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktEpisodeTypeFromJson()
        {
            "unspecified".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.Unspecified);
            "standard".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.Standard);
            "series_premiere".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.SeriesPremiere);
            "season_premiere".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.SeasonPremiere);
            "mid_season_finale".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.MidSeasonFinale);
            "mid_season_premiere".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.MidSeasonPremiere);
            "season_finale".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.SeasonFinale);
            "series_finale".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.SeriesFinale);
            "full_season".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.FullSeason);
            "multiple_episodes".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.MultipleEpisodes);

            string? nullValue = null;
            nullValue.ToTraktEpisodeType().ShouldBe(TraktEpisodeType.Unspecified);
            "invalid".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.Unspecified);
            "".ToTraktEpisodeType().ShouldBe(TraktEpisodeType.Unspecified);
        }

        [Fact]
        public void TestTraktEpisodeTypeDisplayName()
        {
            TraktEpisodeType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktEpisodeType.Standard.DisplayName().ShouldBe("Standard");
            TraktEpisodeType.SeriesPremiere.DisplayName().ShouldBe("Series Premiere");
            TraktEpisodeType.SeasonPremiere.DisplayName().ShouldBe("Season Premiere");
            TraktEpisodeType.MidSeasonFinale.DisplayName().ShouldBe("Mid Season Finale");
            TraktEpisodeType.MidSeasonPremiere.DisplayName().ShouldBe("Mid Season Premiere");
            TraktEpisodeType.SeasonFinale.DisplayName().ShouldBe("Season Finale");
            TraktEpisodeType.SeriesFinale.DisplayName().ShouldBe("Series Finale");
            TraktEpisodeType.FullSeason.DisplayName().ShouldBe("Full Season");
            TraktEpisodeType.MultipleEpisodes.DisplayName().ShouldBe("Multiple Episodes");
            ((TraktEpisodeType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktEpisodeTypeJsonConverter()
        {
            var converter = new TraktEpisodeTypeJsonConverter();
            converter.CanConvert(typeof(TraktEpisodeType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktEpisodeType.Standard, options).ShouldBe("\"standard\"");
            JsonSerializer.Deserialize<TraktEpisodeType>("\"standard\"", options).ShouldBe(TraktEpisodeType.Standard);
            JsonSerializer.Deserialize<TraktEpisodeType>("\"\"", options).ShouldBe(TraktEpisodeType.Unspecified);
        }
    }
}
