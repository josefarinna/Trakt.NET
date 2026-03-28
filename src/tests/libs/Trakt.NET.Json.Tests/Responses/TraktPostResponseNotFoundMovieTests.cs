namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundMovieTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundMovieDefaultConstructor()
        {
            var postResponseNotFoundMovie = new TraktPostResponseNotFoundMovie();

            postResponseNotFoundMovie.IDs.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPostResponseNotFoundMovieFromJson()
        {
            TraktPostResponseNotFoundMovie? postResponseNotFoundMovie = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundMovie>("Responses\\traktpostresponsenotfoundmovie.json");

            postResponseNotFoundMovie.ShouldNotBeNull();
            postResponseNotFoundMovie.IDs.ShouldNotBeNull();
            postResponseNotFoundMovie.IDs.Trakt.ShouldBe(94024U);
            postResponseNotFoundMovie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            postResponseNotFoundMovie.IDs.IMDB.ShouldBe("tt2488496");
            postResponseNotFoundMovie.IDs.TMDB.ShouldBe(140607U);
        }
    }
}
