namespace TraktNET.Json.Users
{
    public sealed class TraktWatchedMinimalTests
    {
        [Fact]
        public async Task TestDeserializeMinimalWatchedMovies()
        {
            Dictionary<string, List<string>>? movies =
                await TestUtility.DeserializeJsonAsync<Dictionary<string, List<string>>>("Users\\getwatchedmoviesminimal.json");

            movies.ShouldNotBeNull();
            movies.Count.ShouldBe(1);
            movies.ShouldContainKey("94024");
            movies["94024"].ShouldNotBeNull();
            movies["94024"].Count.ShouldBe(1);
            movies["94024"][0].ShouldBe("2014-10-11T17:00:54.000Z");
        }

        [Fact]
        public async Task TestDeserializeMinimalWatchedShows()
        {
            Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>? shows =
                await TestUtility.DeserializeJsonAsync<Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>>("Users\\getwatchedshowsminimal.json");

            shows.ShouldNotBeNull();
            shows.Count.ShouldBe(1);
            shows.ShouldContainKey("1390");
            shows["1390"].ShouldNotBeNull();
            shows["1390"].ShouldContainKey("1");
            shows["1390"]["1"].ShouldNotBeNull();
            shows["1390"]["1"].ShouldContainKey("1");
            shows["1390"]["1"]["1"].Count.ShouldBe(2);
            shows["1390"]["1"]["1"][0].ShouldBe("2014-10-11T17:00:54.000Z");
            shows["1390"]["1"]["1"][1].ShouldBe("2015-01-01T12:00:00.000Z");
            shows["1390"]["1"].ShouldContainKey("2");
            shows["1390"]["1"]["2"].Count.ShouldBe(1);
            shows["1390"]["1"]["2"][0].ShouldBe("2014-10-11T17:00:54.000Z");
        }
    }
}
