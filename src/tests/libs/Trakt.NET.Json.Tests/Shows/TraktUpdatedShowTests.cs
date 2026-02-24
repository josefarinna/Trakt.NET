namespace TraktNET.Json.Shows
{
    public sealed class TraktUpdatedShowTests
    {
        [Fact]
        public void TestTraktUpdatedShowConstructor()
        {
            var updatedShow = new TraktUpdatedShow();

            updatedShow.UpdatedAt.ShouldBeNull();
            updatedShow.Show.ShouldBeNull();
            updatedShow.Title.ShouldBeNull();
            updatedShow.Year.ShouldBeNull();
            updatedShow.IDs.ShouldBeNull();
            updatedShow.Tagline.ShouldBeNull();
            updatedShow.Overview.ShouldBeNull();
            updatedShow.FirstAired.ShouldBeNull();
            updatedShow.Airs.ShouldBeNull();
            updatedShow.Runtime.ShouldBeNull();
            updatedShow.Certification.ShouldBeNull();
            updatedShow.Network.ShouldBeNull();
            updatedShow.Country.ShouldBeNull();
            updatedShow.Trailer.ShouldBeNull();
            updatedShow.Homepage.ShouldBeNull();
            updatedShow.Status.ShouldBeNull();
            updatedShow.Rating.ShouldBeNull();
            updatedShow.Votes.ShouldBeNull();
            updatedShow.CommentCount.ShouldBeNull();
            updatedShow.Language.ShouldBeNull();
            updatedShow.Languages.ShouldBeNull();
            updatedShow.AvailableTranslations.ShouldBeNull();
            updatedShow.Genres.ShouldBeNull();

            updatedShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktUpdatedShowFromJsonMinimal()
        {
            TraktUpdatedShow? updatedShow = await TestUtility.DeserializeJsonAsync<TraktUpdatedShow>("Shows\\updatedshow_minimal.json");

            updatedShow.ShouldNotBeNull();
            updatedShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-22T00:31:21.000Z"));
            updatedShow!.Show.ShouldNotBeNull();

            updatedShow!.Title.ShouldBe("Medalist");
            updatedShow!.Year.ShouldBe(2025U);

            updatedShow!.IDs!.Trakt.ShouldBe(223571U);
            updatedShow!.IDs!.Slug.ShouldBe("medalist");
            updatedShow!.IDs!.TVDB.ShouldBe(433953U);
            updatedShow!.IDs!.IMDB.ShouldBe("tt33310730");
            updatedShow!.IDs!.TMDB.ShouldBe(237529U);

            updatedShow!.ToString().ShouldBe("Medalist (2025)");
        }

        [Fact]
        public async Task TestTraktUpdatedShowFromJson()
        {
            TraktUpdatedShow? updatedShow = await TestUtility.DeserializeJsonAsync<TraktUpdatedShow>("Shows\\updatedshow.json");

            updatedShow.ShouldNotBeNull();
            updatedShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-22T00:31:21.000Z"));

            updatedShow!.Title.ShouldBe("Medalist");
            updatedShow!.Year.ShouldBe(2025U);
            updatedShow!.IDs!.Trakt.ShouldBe(223571U);

            updatedShow!.Overview.ShouldStartWith("Tsukasa Akeuraji, a frustrated skater");
            updatedShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2025-01-04T16:30:00.000Z"));
            updatedShow!.Runtime.ShouldBe(23U);
            updatedShow!.Network.ShouldBe("Iwate Asahi TV");
            updatedShow!.Country.ShouldBe("jp");
            updatedShow!.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            updatedShow!.Rating.ShouldBe(7.93548f);

            updatedShow!.ToString().ShouldBe("Medalist (2025)");
        }

        [Fact]
        public async Task TestTraktUpdatedShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktUpdatedShow>? updatedShows = await TestUtility.DeserializeJsonListAsync<TraktUpdatedShow>("Shows\\updatedshows_minimal.json");

            updatedShows.ShouldNotBeNull();
            updatedShows!.Count.ShouldBe(2);

            // Primer Show: Medalist
            updatedShows[0].Title.ShouldBe("Medalist");
            updatedShows[0].UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-22T00:31:21.000Z"));

            // Segundo Show: Scrubs
            updatedShows[1].Title.ShouldBe("Scrubs");
            updatedShows[1].Year.ShouldBe(2026U);
            updatedShows[1].IDs!.Slug.ShouldBe("scrubs-2026");
            updatedShows[1].UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-22T00:37:47.000Z"));
        }

        [Fact]
        public async Task TestTraktUpdatedShowsFromJson()
        {
            IReadOnlyList<TraktUpdatedShow>? updatedShows = await TestUtility.DeserializeJsonListAsync<TraktUpdatedShow>("Shows\\updatedshows.json");

            updatedShows.ShouldNotBeNull();
            updatedShows!.Count.ShouldBe(2);

            TraktUpdatedShow updatedShow = updatedShows![1]; // Probamos el segundo (Scrubs)

            updatedShow.Title.ShouldBe("Scrubs");
            updatedShow.Year.ShouldBe(2026U);
            updatedShow.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-22T00:37:47.000Z"));
            updatedShow.Trailer.ShouldBe("https://youtube.com/watch?v=dJq8WJ5lMec");
            updatedShow.Genres.ShouldNotBeNull();
            updatedShow.Genres!.Count.ShouldBe(1);
            updatedShow.Genres.ShouldContain("comedy");

            updatedShow.ToString().ShouldBe("Scrubs (2026)");
        }
    }
}
