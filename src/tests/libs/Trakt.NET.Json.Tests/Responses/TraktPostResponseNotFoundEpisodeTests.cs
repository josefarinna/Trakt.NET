namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundEpisodeTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundEpisodeDefaultConstructor()
        {
            var postResponseNotFoundEpisode = new TraktPostResponseNotFoundEpisode();

            postResponseNotFoundEpisode.Title.ShouldBeNull();
            postResponseNotFoundEpisode.Year.ShouldBeNull();
            postResponseNotFoundEpisode.IDs.ShouldBeNull();
            postResponseNotFoundEpisode.Seasons.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPostResponseNotFoundEpisodeFromJson()
        {
            TraktPostResponseNotFoundEpisode? postResponseNotFoundEpisode = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundEpisode>("Responses\\traktpostresponsenotfoundepisode.json");

            postResponseNotFoundEpisode.ShouldNotBeNull();
            postResponseNotFoundEpisode.IDs.ShouldNotBeNull();
            postResponseNotFoundEpisode.IDs.Trakt.ShouldBe(73640U);
            postResponseNotFoundEpisode.IDs.TVDB.ShouldBe(3254641U);
            postResponseNotFoundEpisode.IDs.IMDB.ShouldBe("tt1480055");
            postResponseNotFoundEpisode.IDs.TMDB.ShouldBe(63056U);
        }

        [Fact]
        public async Task TestTraktPostResponseNotFoundEpisodeFromJsonShowShaped()
        {
            TraktPostResponseNotFoundEpisode? postResponseNotFoundEpisode = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundEpisode>("Responses\\traktpostresponsenotfoundshowshaped.json");

            postResponseNotFoundEpisode.ShouldNotBeNull();
            postResponseNotFoundEpisode.Title.ShouldBe("Breaking Bad");
            postResponseNotFoundEpisode.Year.ShouldBe(2008U);
            postResponseNotFoundEpisode.IDs.ShouldNotBeNull();
            postResponseNotFoundEpisode.IDs.Trakt.ShouldBe(1388U);
            postResponseNotFoundEpisode.Seasons.ShouldNotBeNull();
            postResponseNotFoundEpisode.Seasons.Count.ShouldBe(1);
            postResponseNotFoundEpisode.Seasons[0].Number.ShouldBe(99U);
            postResponseNotFoundEpisode.Seasons[0].Episodes.ShouldNotBeNull();
            postResponseNotFoundEpisode.Seasons[0].Episodes!.Count.ShouldBe(1);
            postResponseNotFoundEpisode.Seasons[0].Episodes![0].Number.ShouldBe(42U);
        }
    }
}
