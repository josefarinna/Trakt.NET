namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieIDsTests
    {
        [Fact]
        public void TestTraktMovieIDsConstructor()
        {
            var movieIDs = new TraktMovieIDs();

            movieIDs.Trakt.Should().BeNull();
            movieIDs.Slug.Should().BeNull();
            movieIDs.IMDB.Should().BeNull();
            movieIDs.TMDB.Should().BeNull();

            movieIDs.HasAnyID.Should().BeFalse();
            movieIDs.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktMovieIDsFromJson()
        {
            TraktMovieIDs? movieIDs = await TestUtility.DeserializeJsonAsync<TraktMovieIDs>("Movies\\movieids.json");

            movieIDs.Should().NotBeNull();

            movieIDs!.Trakt.Should().Be(293990U);
            movieIDs!.Slug.Should().Be("guardians-of-the-galaxy-volume-3-2023");
            movieIDs!.IMDB.Should().Be("tt6791350");
            movieIDs!.TMDB.Should().Be(447365U);

            movieIDs!.HasAnyID.Should().BeTrue();
            movieIDs!.BestID.Should().Be("guardians-of-the-galaxy-volume-3-2023");
        }
    }
}
