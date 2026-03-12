namespace TraktNET.Json.Checkin
{
    public sealed class TraktMovieCheckinResponseTests
    {
        [Fact]
        public void TestTraktMovieCheckinResponseConstructor()
        {
            var response = new TraktMovieCheckinResponse();

            response.Id.ShouldBe(0UL);
            response.WatchedAt.ShouldBeNull();
            response.Sharing.ShouldBeNull();
            response.Movie.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMovieCheckinResponseFromJson()
        {
            TraktMovieCheckinResponse? response = await TestUtility.DeserializeJsonAsync<TraktMovieCheckinResponse>("Checkin\\checkinmovie_response.json");

            response.ShouldNotBeNull();

            response!.Id.ShouldBe(3373536619UL);
            response!.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-06T01:11:37.000Z"));

            response!.Sharing.ShouldNotBeNull();
            response!.Sharing!.Twitter.ShouldBe(true);
            response!.Sharing!.Tumblr.ShouldBe(false);

            response!.Movie.ShouldNotBeNull();
            response!.Movie!.Title.ShouldBe("Guardians of the Galaxy");
            response!.Movie!.Year.ShouldBe(2014U);
            response!.Movie!.IDs.ShouldNotBeNull();
            response!.Movie!.IDs!.Trakt.ShouldBe(28U);
            response!.Movie!.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-2014");
            response!.Movie!.IDs!.IMDB.ShouldBe("tt2015381");
            response!.Movie!.IDs!.TMDB.ShouldBe(118340U);
        }
    }
}
