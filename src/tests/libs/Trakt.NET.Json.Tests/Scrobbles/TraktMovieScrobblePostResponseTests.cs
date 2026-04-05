namespace TraktNET.Scrobbles
{
    public sealed class TraktMovieScrobblePostResponseTests
    {
        [Fact]
        public void TestTraktMovieScrobblePostResponseDefaultConstructor()
        {
            var movieScrobbleResponse = new TraktMovieScrobblePostResponse();

            movieScrobbleResponse.ID.ShouldBe(0UL);
            movieScrobbleResponse.Action.ShouldBeNull();
            movieScrobbleResponse.Progress.ShouldBeNull();
            movieScrobbleResponse.Sharing.ShouldBeNull();
            movieScrobbleResponse.Movie.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMovieScrobblePostResponseFromJson()
        {
            TraktMovieScrobblePostResponse? movieScrobbleResponse = await TestUtility.DeserializeJsonAsync<TraktMovieScrobblePostResponse>("Scrobbles\\moviescrobblepostresponse.json");

            movieScrobbleResponse.ShouldNotBeNull();
            movieScrobbleResponse.ID.ShouldBe(3373536623UL);
            movieScrobbleResponse.Action.ShouldBe(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.ShouldBe(85.9f);
            movieScrobbleResponse.Sharing.ShouldNotBeNull();
            movieScrobbleResponse.Sharing.Twitter.ShouldBe(true);
            movieScrobbleResponse.Sharing.Tumblr.ShouldBe(true);
            movieScrobbleResponse.Movie.ShouldNotBeNull();
            movieScrobbleResponse.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.ShouldBe(2015U);
            movieScrobbleResponse.Movie.IDs.ShouldNotBeNull();
            movieScrobbleResponse.Movie.IDs!.Trakt.ShouldBe(94024U);
            movieScrobbleResponse.Movie.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.IDs!.IMDB.ShouldBe("tt2488496");
            movieScrobbleResponse.Movie.IDs!.TMDB.ShouldBe(140607U);
        }
    }
}
