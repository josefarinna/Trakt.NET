using static TraktNET.TestConstants;

namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionMovieTests
    {
        [Fact]
        public void TestTraktSyncCollectionMovieConstructor()
        {
            var syncCollectionMovie = new TraktSyncCollectionMovie();

            syncCollectionMovie.Type.ShouldBeNull();
            syncCollectionMovie.CollectedAt.ShouldBeNull();
            syncCollectionMovie.UpdatedAt.ShouldBeNull();
            syncCollectionMovie.Title.ShouldBeNull();
            syncCollectionMovie.Year.ShouldBeNull();
            syncCollectionMovie.IDs.ShouldBeNull();
            syncCollectionMovie.Tagline.ShouldBeNull();
            syncCollectionMovie.Overview.ShouldBeNull();
            syncCollectionMovie.Runtime.ShouldBeNull();
            syncCollectionMovie.Certification.ShouldBeNull();
            syncCollectionMovie.Country.ShouldBeNull();
            syncCollectionMovie.Trailer.ShouldBeNull();
            syncCollectionMovie.Homepage.ShouldBeNull();
            syncCollectionMovie.Status.ShouldBeNull();
            syncCollectionMovie.Rating.ShouldBeNull();
            syncCollectionMovie.Votes.ShouldBeNull();
            syncCollectionMovie.CommentCount.ShouldBeNull();
            syncCollectionMovie.UpdatedAt.ShouldBeNull();
            syncCollectionMovie.Language.ShouldBeNull();
            syncCollectionMovie.Languages.ShouldBeNull();
            syncCollectionMovie.AvailableTranslations.ShouldBeNull();
            syncCollectionMovie.Genres.ShouldBeNull();
            syncCollectionMovie.Subgenres.ShouldBeNull();
            syncCollectionMovie.OriginalTitle.ShouldBeNull();
            syncCollectionMovie.Images.ShouldBeNull();
            syncCollectionMovie.Colors.ShouldBeNull();
            syncCollectionMovie.Released.ShouldBeNull();
            syncCollectionMovie.Images.ShouldBeNull();

            syncCollectionMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktSyncCollectionMovieFromJsonMinimal()
        {
            TraktSyncCollectionMovie? syncCollectionMovie = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionMovie>("Syncs\\Collection\\synccollectionmovie_minimal.json");

            syncCollectionMovie.ShouldNotBeNull();
            syncCollectionMovie.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            syncCollectionMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            syncCollectionMovie!.Title.ShouldBe("The Dark Knight");
            syncCollectionMovie!.Year.ShouldBe(2008U);

            syncCollectionMovie!.IDs!.Trakt.ShouldBe(6U);
            syncCollectionMovie!.IDs!.Slug.ShouldBe("the-dark-knight-2008");
            syncCollectionMovie!.IDs!.IMDB.ShouldBe("tt0468569");
            syncCollectionMovie!.IDs!.TMDB.ShouldBe(155U);
            syncCollectionMovie!.IDs!.HasAnyID.ShouldBe(true);
            syncCollectionMovie!.IDs!.BestID.ShouldBe("the-dark-knight-2008");

            syncCollectionMovie!.ToString().ShouldBe("The Dark Knight (2008)");
        }

        [Fact]
        public async Task TestTraktSyncCollectionMovieFromJson()
        {
            TraktSyncCollectionMovie? syncCollectionMovie = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionMovie>("Syncs\\Collection\\synccollectionmovie.json");

            syncCollectionMovie.ShouldNotBeNull();
            syncCollectionMovie.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.0000000Z"));
            syncCollectionMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.0000000Z"));

            syncCollectionMovie!.Title.ShouldBe("The Dark Knight");
            syncCollectionMovie!.Year.ShouldBe(2008U);

            syncCollectionMovie!.IDs!.Trakt.ShouldBe(120U);
            syncCollectionMovie!.IDs!.Slug.ShouldBe("the-dark-knight-2008");
            syncCollectionMovie!.IDs!.IMDB.ShouldBe("tt0468569");
            syncCollectionMovie!.IDs!.TMDB.ShouldBe(155U);
            syncCollectionMovie!.IDs!.HasAnyID.ShouldBe(true);
            syncCollectionMovie!.IDs!.BestID.ShouldBe("the-dark-knight-2008");

            syncCollectionMovie!.Tagline.ShouldBe("Welcome to a world without rules.");
            syncCollectionMovie!.Overview.ShouldStartWith("Batman raises the stakes in his war on crime.");
            syncCollectionMovie!.Runtime.ShouldBe(152U);
            syncCollectionMovie!.Certification.ShouldBe("PG-13");
            syncCollectionMovie!.Country.ShouldBe("us");
            syncCollectionMovie!.Trailer.ShouldBe("https://youtube.com/watch?v=_PZpmTj1Q8Q");
            syncCollectionMovie!.Homepage.ShouldBe("https://www.warnerbros.com/movies/dark-knight/");
            syncCollectionMovie!.Status.ShouldBe(TraktMovieStatus.Released);
            syncCollectionMovie!.Rating.ShouldBe(8.86959457397461f);
            syncCollectionMovie!.Votes.ShouldBe(89429U);
            syncCollectionMovie!.CommentCount.ShouldBe(191U);
            syncCollectionMovie!.Language.ShouldBe("en");

            syncCollectionMovie!.Languages.ShouldNotBeNull();
            syncCollectionMovie!.Languages!.Count.ShouldBe(2);
            syncCollectionMovie!.Languages.ShouldBe(["en", "zh"], Case.Sensitive);

            syncCollectionMovie!.AvailableTranslations.ShouldNotBeNull();
            syncCollectionMovie!.AvailableTranslations!.Count.ShouldBe(42);
            syncCollectionMovie!.AvailableTranslations!.ShouldContain("es");
            syncCollectionMovie!.AvailableTranslations!.ShouldContain("en");

            syncCollectionMovie!.Genres.ShouldNotBeNull();
            syncCollectionMovie!.Genres!.Count.ShouldBe(4);
            syncCollectionMovie!.Genres.ShouldBe(["action", "crime", "thriller", "superhero"], Case.Sensitive);

            syncCollectionMovie!.OriginalTitle.ShouldBe("The Dark Knight");
#if NET7_0_OR_GREATER
            syncCollectionMovie!.Released.ShouldBe(TestUtility.ParseDate("2008-07-18"));
#else
            syncCollectionMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2008-07-18T00:00:00.000Z"));
#endif
        }
    }
}
