namespace TraktNET.Json.Shows
{
    public sealed class TraktHotShowTests
    {
        [Fact]
        public void TestTraktHotShowConstructor()
        {
            var hotShow = new TraktHotShow();

            hotShow.ListCount.ShouldBeNull();
            hotShow.Title.ShouldBeNull();
            hotShow.Year.ShouldBeNull();
            hotShow.IDs.ShouldBeNull();
            hotShow.Tagline.ShouldBeNull();
            hotShow.Overview.ShouldBeNull();
            hotShow.Runtime.ShouldBeNull();
            hotShow.Country.ShouldBeNull();
            hotShow.Trailer.ShouldBeNull();
            hotShow.Homepage.ShouldBeNull();
            hotShow.Status.ShouldBeNull();
            hotShow.Rating.ShouldBeNull();
            hotShow.Votes.ShouldBeNull();
            hotShow.CommentCount.ShouldBeNull();
            hotShow.UpdatedAt.ShouldBeNull();
            hotShow.Language.ShouldBeNull();
            hotShow.Languages.ShouldBeNull();
            hotShow.AvailableTranslations.ShouldBeNull();
            hotShow.Genres.ShouldBeNull();
            hotShow.Certification.ShouldBeNull();

            hotShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktHotShowFromJson()
        {
            TraktHotShow? hotShow = await TestUtility.DeserializeJsonAsync<TraktHotShow>("Shows\\hotshow.json");

            hotShow.ShouldNotBeNull();
            hotShow.ListCount.ShouldBe(85U);

            hotShow.Title.ShouldBe("Game of Thrones");
            hotShow.Year.ShouldBe(2011U);

            hotShow.IDs.ShouldNotBeNull();
            hotShow.IDs.Trakt.ShouldBe(1390U);
            hotShow.IDs.Slug.ShouldBe("game-of-thrones");
            hotShow.IDs.TVDB.ShouldBe(121361U);
            hotShow.IDs.IMDB.ShouldBe("tt0944947");
            hotShow.IDs.TMDB.ShouldBe(1399U);
            hotShow.IDs.HasAnyID.ShouldBe(true);
            hotShow.IDs.BestID.ShouldBe("game-of-thrones");

            hotShow.ToString().ShouldBe("Game of Thrones (2011)");

            hotShow.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros.");

            hotShow.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T01:00:00.000Z"));
            hotShow.Airs.ShouldNotBeNull();
            hotShow.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            hotShow.Airs.Time.ShouldBe(new TimeOnly(21, 0, 0));
#else
            hotShow.Airs.Time.ShouldBe("21:00");
#endif
            hotShow.Airs.Timezone.ShouldBe("America/New_York");

            hotShow.Runtime.ShouldBe(60U);
            hotShow.Certification.ShouldBe("TV-MA");
            hotShow.Network.ShouldBe("HBO");
            hotShow.Country.ShouldBe("us");
            hotShow.Trailer.ShouldBe("http://youtube.com/watch?v=522l0YE9hBw");
            hotShow.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            hotShow.Status.ShouldBe(TraktShowStatus.Ended);
            hotShow.Rating.ShouldBe(8.98226f);
            hotShow.Votes.ShouldBe(112345U);
            hotShow.CommentCount.ShouldBe(521U);
            hotShow.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            hotShow.Language.ShouldBe("en");

            hotShow.Genres.ShouldNotBeNull();
            hotShow.Genres.Count.ShouldBe(5);
            hotShow.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"], Case.Sensitive);
        }
    }
}
