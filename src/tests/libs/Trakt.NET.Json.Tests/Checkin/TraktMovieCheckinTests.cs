namespace TraktNET.Json.Checkin
{
    public sealed class TraktMovieCheckinTests
    {
        [Fact]
        public void TestTraktMovieCheckinConstructor()
        {
            var movieCheckin = new TraktMovieCheckin
            {
                Movie = new TraktMovie()
            };

            movieCheckin.Sharing.ShouldBeNull();
            movieCheckin.Message.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMovieCheckinFromJson()
        {
            TraktMovieCheckin? movieCheckin = await TestUtility.DeserializeJsonAsync<TraktMovieCheckin>("Checkin\\checkinmovie.json");

            movieCheckin.ShouldNotBeNull();

            movieCheckin!.Movie.ShouldNotBeNull();
            movieCheckin!.Movie!.Title.ShouldBe("Guardians of the Galaxy");
            movieCheckin!.Movie!.Year.ShouldBe(2014U);
            movieCheckin!.Movie!.IDs.ShouldNotBeNull();
            movieCheckin!.Movie!.IDs!.Trakt.ShouldBe(28U);
            movieCheckin!.Movie!.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-2014");
            movieCheckin!.Movie!.IDs!.IMDB.ShouldBe("tt2015381");
            movieCheckin!.Movie!.IDs!.TMDB.ShouldBe(118340U);

            movieCheckin!.Sharing.ShouldNotBeNull();
            movieCheckin!.Sharing!.Twitter.ShouldBe(true);
            movieCheckin!.Sharing!.Tumblr.ShouldBe(false);

            movieCheckin!.Message.ShouldBe("Guardians of the Galaxy FTW!");
        }
    }
}
