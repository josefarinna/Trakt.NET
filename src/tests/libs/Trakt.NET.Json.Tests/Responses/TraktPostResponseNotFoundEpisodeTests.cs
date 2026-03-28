namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundEpisodeTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundEpisodeDefaultConstructor()
        {
            var postResponseNotFoundEpisode = new TraktPostResponseNotFoundEpisode();

            postResponseNotFoundEpisode.IDs.ShouldBeNull();
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
    }
}
