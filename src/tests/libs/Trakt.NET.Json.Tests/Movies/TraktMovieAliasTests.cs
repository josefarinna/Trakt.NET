namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieAliasTests
    {
        [Fact]
        public void TestTraktMovieAliasConstructor()
        {
            var movieAlias = new TraktMovieAlias();

            movieAlias.Title.Should().BeNull();
            movieAlias.Country.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktMovieAliasFromJson()
        {
            TraktMovieAlias? movieAlias = await TestUtility.DeserializeJsonAsync<TraktMovieAlias>("Movies\\moviealias.json");

            movieAlias.Should().NotBeNull();

            movieAlias!.Title.Should().Be("Les Gardiens de la Galaxie 3");
            movieAlias!.Country.Should().Be("fr");
        }

        [Fact]
        public async Task TestTraktMovieAliasesFromJson()
        {
            IReadOnlyList<TraktMovieAlias>? movieAliases = await TestUtility.DeserializeJsonListAsync<TraktMovieAlias>("Movies\\moviealiases.json");

            movieAliases.Should().NotBeNull().And.HaveCount(2);

            TraktMovieAlias movieAlias = movieAliases![0];

            movieAlias.Should().NotBeNull();

            movieAlias.Title.Should().Be("Les Gardiens de la Galaxie 3");
            movieAlias.Country.Should().Be("fr");

            // --------------------------------------------------------------------------------------------

            movieAlias = movieAliases![1];

            movieAlias.Should().NotBeNull();

            movieAlias.Title.Should().Be("Guardians of the Galaxy Vol. 3");
            movieAlias.Country.Should().Be("us");
        }
    }
}
