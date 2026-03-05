namespace TraktNET.Json.Calendars
{
    public sealed class TraktCalendarShowTests
    {
        [Fact]
        public void TestTraktCalendarShowConstructor()
        {
            var calendarShow = new TraktCalendarShow();

            calendarShow.FirstAired.ShouldBeNull();
            calendarShow.Episode.ShouldBeNull();
            calendarShow.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCalendarShowFromJsonMinimal()
        {
            TraktCalendarShow? calendarShow = await TestUtility.DeserializeJsonAsync<TraktCalendarShow>("Calendars\\calendarshow_minimal.json");

            calendarShow.ShouldNotBeNull();
            calendarShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));

            calendarShow.Episode.ShouldNotBeNull();
            calendarShow.Episode!.Title.ShouldBe("Winter Is Coming");
            calendarShow.Episode.Season.ShouldBe(1U);
            calendarShow.Episode.Number.ShouldBe(1U);
            calendarShow.Episode.IDs.ShouldNotBeNull();
            calendarShow.Episode.IDs!.Trakt.ShouldBe(73640U);

            calendarShow.Show.ShouldNotBeNull();
            calendarShow.Show!.Title.ShouldBe("Game of Thrones");
            calendarShow.Show.Year.ShouldBe(2011U);
            calendarShow.Show.IDs.ShouldNotBeNull();
            calendarShow.Show.IDs!.Trakt.ShouldBe(1390U);
            calendarShow.Show.IDs.Slug.ShouldBe("game-of-thrones");
        }

        [Fact]
        public async Task TestTraktCalendarShowFromJsonFull()
        {
            TraktCalendarShow? calendarShow = await TestUtility.DeserializeJsonAsync<TraktCalendarShow>("Calendars\\calendarshow.json");

            calendarShow.ShouldNotBeNull();
            calendarShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));

            calendarShow.Episode.ShouldNotBeNull();
            calendarShow.Episode!.Title.ShouldBe("Winter Is Coming");
            calendarShow.Episode.Rating.ShouldBe(8.06604f);
            calendarShow.Episode.Votes.ShouldBe(15005U);
            calendarShow.Episode.UpdatedAt.ShouldNotBeNull();

            calendarShow.Show.ShouldNotBeNull();
            calendarShow.Show!.Title.ShouldBe("Game of Thrones");
            calendarShow.Show.Status.ShouldBe(TraktShowStatus.Ended);
            calendarShow.Show.Network.ShouldBe("HBO");
            calendarShow.Show.Runtime.ShouldBe(55U);
            calendarShow.Show.Airs.ShouldNotBeNull();
            calendarShow.Show.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            calendarShow.Show!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            calendarShow.Show!.Airs!.Time.ShouldBe("21:00");
#endif
            calendarShow.Show.Rating.ShouldBe(8.89139f);
            calendarShow.Show.Votes.ShouldBe(145330U);
            calendarShow.Show.Genres.ShouldNotBeNull();
            calendarShow.Show.Genres!.Count.ShouldBe(4);
        }
    }
}
