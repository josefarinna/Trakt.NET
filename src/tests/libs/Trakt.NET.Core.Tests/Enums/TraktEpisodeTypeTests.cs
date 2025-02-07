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

            string? nullValue = null;
            nullValue.ToTraktEpisodeType().ShouldBe(TraktEpisodeType.Unspecified);
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
        }
    }
}
