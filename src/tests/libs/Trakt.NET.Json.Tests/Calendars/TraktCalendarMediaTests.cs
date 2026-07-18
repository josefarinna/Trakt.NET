namespace TraktNET.Json.Calendars
{
    public sealed class TraktCalendarMediaTests
    {
        [Fact]
        public void TestTraktCalendarMediaConstructor()
        {
            var calendarMedia = new TraktCalendarMedia();

            calendarMedia.Released.ShouldBeNull();
            calendarMedia.Movie.ShouldBeNull();
            calendarMedia.FirstAired.ShouldBeNull();
            calendarMedia.Episode.ShouldBeNull();
            calendarMedia.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCalendarMediaFromJson()
        {
            IReadOnlyList<TraktCalendarMedia>? calendarMediaList = await TestUtility.DeserializeJsonAsync<IReadOnlyList<TraktCalendarMedia>>("Calendars\\calendarmedia.json");

            calendarMediaList.ShouldNotBeNull();
            calendarMediaList!.Count.ShouldBe(2);

            TraktCalendarMedia movieItem = calendarMediaList[0];
            movieItem.Released.ShouldNotBeNull();
            movieItem.Released.ShouldBe(TestUtility.ParseUTCDateTime("2012-05-04T00:00:00.000Z"));
            movieItem.Movie.ShouldNotBeNull();
            movieItem.Movie!.Title.ShouldBe("The Avengers");
            movieItem.Movie.Year.ShouldBe(2012U);
            movieItem.Movie.IDs.ShouldNotBeNull();
            movieItem.Movie.IDs!.Trakt.ShouldBe(14701U);
            movieItem.Movie.IDs.Slug.ShouldBe("the-avengers-2012");

            movieItem.FirstAired.ShouldBeNull();
            movieItem.Episode.ShouldBeNull();
            movieItem.Show.ShouldBeNull();

            TraktCalendarMedia showItem = calendarMediaList[1];
            showItem.FirstAired.ShouldNotBeNull();
            showItem.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            showItem.Episode.ShouldNotBeNull();
            showItem.Episode!.Title.ShouldBe("Winter Is Coming");
            showItem.Episode.Season.ShouldBe(1U);
            showItem.Episode.Number.ShouldBe(1U);
            showItem.Episode.IDs.ShouldNotBeNull();
            showItem.Episode.IDs!.Trakt.ShouldBe(73640U);

            showItem.Show.ShouldNotBeNull();
            showItem.Show!.Title.ShouldBe("Game of Thrones");
            showItem.Show.Year.ShouldBe(2011U);
            showItem.Show.IDs.ShouldNotBeNull();
            showItem.Show.IDs!.Trakt.ShouldBe(1390U);
            showItem.Show.IDs.Slug.ShouldBe("game-of-thrones");

            showItem.Released.ShouldBeNull();
            showItem.Movie.ShouldBeNull();
        }
    }
}
