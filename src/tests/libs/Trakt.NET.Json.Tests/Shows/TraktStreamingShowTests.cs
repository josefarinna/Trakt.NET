namespace TraktNET.Json.Shows
{
    public sealed class TraktStreamingShowTests
    {
        [Fact]
        public void TestTraktStreamingShowConstructor()
        {
            var streamingShow = new TraktStreamingShow();

            streamingShow.Rank.ShouldBeNull();
            streamingShow.Delta.ShouldBeNull();
            streamingShow.Title.ShouldBeNull();
            streamingShow.Year.ShouldBeNull();
            streamingShow.IDs.ShouldBeNull();
            streamingShow.Tagline.ShouldBeNull();
            streamingShow.Overview.ShouldBeNull();
            streamingShow.Runtime.ShouldBeNull();
            streamingShow.Country.ShouldBeNull();
            streamingShow.Trailer.ShouldBeNull();
            streamingShow.Homepage.ShouldBeNull();
            streamingShow.Status.ShouldBeNull();
            streamingShow.Rating.ShouldBeNull();
            streamingShow.Votes.ShouldBeNull();
            streamingShow.CommentCount.ShouldBeNull();
            streamingShow.UpdatedAt.ShouldBeNull();
            streamingShow.Language.ShouldBeNull();
            streamingShow.Languages.ShouldBeNull();
            streamingShow.AvailableTranslations.ShouldBeNull();
            streamingShow.Genres.ShouldBeNull();
            streamingShow.Certification.ShouldBeNull();

            streamingShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktStreamingShowFromJson()
        {
            TraktStreamingShow? streamingShow = await TestUtility.DeserializeJsonAsync<TraktStreamingShow>("Shows\\streamingshow.json");

            streamingShow.ShouldNotBeNull();
            streamingShow.Rank.ShouldNotBeNull();
            streamingShow.Rank.Value.ShouldBe(1);
            streamingShow.Delta.ShouldNotBeNull();
            streamingShow.Delta.Value.ShouldBe(3);

            streamingShow.Title.ShouldBe("Game of Thrones");
            streamingShow.Year.ShouldBe(2011U);

            streamingShow.IDs.ShouldNotBeNull();
            streamingShow.IDs.Trakt.ShouldBe(1390U);
            streamingShow.IDs.Slug.ShouldBe("game-of-thrones");
            streamingShow.IDs.TVDB.ShouldBe(121361U);
            streamingShow.IDs.IMDB.ShouldBe("tt0944947");
            streamingShow.IDs.TMDB.ShouldBe(1399U);
            streamingShow.IDs.HasAnyID.ShouldBe(true);
            streamingShow.IDs.BestID.ShouldBe("game-of-thrones");

            streamingShow.ToString().ShouldBe("Game of Thrones (2011)");

            streamingShow.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros.");

            streamingShow.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T01:00:00.000Z"));
            streamingShow.Airs.ShouldNotBeNull();
            streamingShow.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            streamingShow.Airs.Time.ShouldBe(new TimeOnly(21, 0, 0));
#else
            streamingShow.Airs.Time.ShouldBe("21:00");
#endif
            streamingShow.Airs.Timezone.ShouldBe("America/New_York");

            streamingShow.Runtime.ShouldBe(60U);
            streamingShow.Certification.ShouldBe("TV-MA");
            streamingShow.Network.ShouldBe("HBO");
            streamingShow.Country.ShouldBe("us");
            streamingShow.Trailer.ShouldBe("http://youtube.com/watch?v=522l0YE9hBw");
            streamingShow.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            streamingShow.Status.ShouldBe(TraktShowStatus.Ended);
            streamingShow.Rating.ShouldBe(8.98226f);
            streamingShow.Votes.ShouldBe(112345U);
            streamingShow.CommentCount.ShouldBe(521U);
            streamingShow.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            streamingShow.Language.ShouldBe("en");

            streamingShow.Genres.ShouldNotBeNull();
            streamingShow.Genres.Count.ShouldBe(5);
            streamingShow.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"], Case.Sensitive);
        }
    }
}
