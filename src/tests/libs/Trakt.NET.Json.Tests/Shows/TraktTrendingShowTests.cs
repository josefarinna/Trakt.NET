namespace TraktNET.Json.Shows
{
    public sealed class TraktTrendingShowTests
    {
        [Fact]
        public void TestTraktTrendingShowConstructor()
        {
            var trendingShow = new TraktTrendingShow();

            trendingShow.Watchers.ShouldBeNull();
            trendingShow.Title.ShouldBeNull();
            trendingShow.Year.ShouldBeNull();
            trendingShow.IDs.ShouldBeNull();
            trendingShow.Tagline.ShouldBeNull();
            trendingShow.Overview.ShouldBeNull();
            trendingShow.FirstAired.ShouldBeNull();
            trendingShow.Airs.ShouldBeNull();
            trendingShow.Runtime.ShouldBeNull();
            trendingShow.Certification.ShouldBeNull();
            trendingShow.Network.ShouldBeNull();
            trendingShow.Country.ShouldBeNull();
            trendingShow.Trailer.ShouldBeNull();
            trendingShow.Homepage.ShouldBeNull();
            trendingShow.Status.ShouldBeNull();
            trendingShow.Rating.ShouldBeNull();
            trendingShow.Votes.ShouldBeNull();
            trendingShow.CommentCount.ShouldBeNull();
            trendingShow.UpdatedAt.ShouldBeNull();
            trendingShow.Language.ShouldBeNull();
            trendingShow.Languages.ShouldBeNull();
            trendingShow.AvailableTranslations.ShouldBeNull();
            trendingShow.Genres.ShouldBeNull();
            trendingShow.AiredEpisodes.ShouldBeNull();

            trendingShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktTrendingShowFromJsonMinimal()
        {
            TraktTrendingShow? trendingShow = await TestUtility.DeserializeJsonAsync<TraktTrendingShow>("Shows\\trendingshow_minimal.json");

            trendingShow.ShouldNotBeNull();

            trendingShow!.Watchers.ShouldBe(8021U);

            trendingShow!.Title.ShouldBe("The Pitt");
            trendingShow!.Year.ShouldBe(2025U);

            trendingShow!.IDs!.Trakt.ShouldBe(232884U);
            trendingShow!.IDs!.Slug.ShouldBe("the-pitt");
            trendingShow!.IDs!.IMDB.ShouldBe("tt31938062");
            trendingShow!.IDs!.TMDB.ShouldBe(250307U);
            trendingShow!.IDs!.TVDB.ShouldBe(448176U);
            trendingShow!.IDs!.HasAnyID.ShouldBe(true);
            trendingShow!.IDs!.BestID.ShouldBe("the-pitt");

            trendingShow!.ToString().ShouldBe("The Pitt (2025)");
        }

        [Fact]
        public async Task TestTraktTrendingShowFromJson()
        {
            TraktTrendingShow? trendingShow = await TestUtility.DeserializeJsonAsync<TraktTrendingShow>("Shows\\trendingshow.json");

            trendingShow.ShouldNotBeNull();

            trendingShow!.Watchers.ShouldBe(8021U);

            trendingShow!.Title.ShouldBe("The Pitt");
            trendingShow!.Year.ShouldBe(2025U);

            trendingShow!.IDs!.Trakt.ShouldBe(232884U);
            trendingShow!.IDs!.Slug.ShouldBe("the-pitt");
            trendingShow!.IDs!.IMDB.ShouldBe("tt31938062");
            trendingShow!.IDs!.TMDB.ShouldBe(250307U);
            trendingShow!.IDs!.TVDB.ShouldBe(448176U);
            trendingShow!.IDs!.HasAnyID.ShouldBe(true);
            trendingShow!.IDs!.BestID.ShouldBe("the-pitt");

            trendingShow!.ToString().ShouldBe("The Pitt (2025)");

            trendingShow!.Tagline.ShouldBe("The work never stops.");
            trendingShow!.Overview.ShouldBe("The staff of Pittsburgh's Trauma Medical Center work around the clock to save lives in an overcrowded and underfunded emergency department.");
            trendingShow!.Runtime.ShouldBe(48U);
            trendingShow!.Country.ShouldBe("us");
            trendingShow!.Trailer.ShouldBe("https://youtube.com/watch?v=ufR_08V38sQ");
            trendingShow!.Homepage.ShouldBe("https://www.hbomax.com/shows/pitt-2024/e6e7bad9-d48d-4434-b334-7c651ffc4bdf");
            trendingShow!.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            trendingShow!.Rating.ShouldBe(8.76872f);
            trendingShow!.Votes.ShouldBe(5383U);
            trendingShow!.CommentCount.ShouldBe(65U);
            trendingShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-22T15:47:34.000Z"));
            trendingShow!.Language.ShouldBe("en");

            trendingShow!.Languages.ShouldNotBeNull();
            trendingShow!.Languages!.Count.ShouldBe(1);
            trendingShow!.Languages!.ShouldBe(["en"], Case.Sensitive);

            trendingShow!.AvailableTranslations.ShouldNotBeNull();
            trendingShow!.AvailableTranslations!.Count.ShouldBe(35);
            trendingShow!.AvailableTranslations!.ShouldContain("es");

            trendingShow!.Genres.ShouldNotBeNull();
            trendingShow!.Genres!.Count.ShouldBe(1);
            trendingShow!.Genres!.ShouldBe(["drama"], Case.Sensitive);
        }

        [Fact]
        public async Task TestTraktTrendingShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktTrendingShow>? trendingShows = await TestUtility.DeserializeJsonListAsync<TraktTrendingShow>("Shows\\trendingshows_minimal.json");

            trendingShows.ShouldNotBeNull();
            trendingShows!.Count.ShouldBe(2);

            TraktTrendingShow trendingShow = trendingShows![0];
            trendingShow.ShouldNotBeNull();
            trendingShow.Watchers.ShouldBe(8021U);
            trendingShow.Title.ShouldBe("The Pitt");

            // --------------------------------------------------------------------------------------------

            trendingShow = trendingShows![1];
            trendingShow.ShouldNotBeNull();
            trendingShow.Watchers.ShouldBe(5663U);
            trendingShow.Title.ShouldBe("The Night Agent");
            trendingShow.Year.ShouldBe(2023U);
            trendingShow.IDs!.Trakt.ShouldBe(184471U);
        }

        [Fact]
        public async Task TestTraktTrendingShowsFromJson()
        {
            IReadOnlyList<TraktTrendingShow>? trendingShows = await TestUtility.DeserializeJsonListAsync<TraktTrendingShow>("Shows\\trendingshows.json");

            trendingShows.ShouldNotBeNull();
            trendingShows!.Count.ShouldBe(2);

            TraktTrendingShow trendingShow = trendingShows![0];
            trendingShow.ShouldNotBeNull();
            trendingShow.Watchers.ShouldBe(8021U);
            trendingShow.Title.ShouldBe("The Pitt");
            trendingShow.Status.ShouldBe(TraktShowStatus.ReturningSeries);

            // --------------------------------------------------------------------------------------------

            trendingShow = trendingShows![1];
            trendingShow.ShouldNotBeNull();
            trendingShow.Watchers.ShouldBe(5663U);
            trendingShow.Title.ShouldBe("The Night Agent");
            trendingShow.Year.ShouldBe(2023U);
            trendingShow.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            trendingShow.Runtime.ShouldBe(50U);
        }
    }
}
