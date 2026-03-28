namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundSeasonTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundSeasonDefaultConstructor()
        {
            var postResponseNotFoundSeason = new TraktPostResponseNotFoundSeason();

            postResponseNotFoundSeason.IDs.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPostResponseNotFoundSeasonFromJson()
        {
            TraktPostResponseNotFoundSeason? postResponseNotFoundSeason = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundSeason>("Responses\\traktpostresponsenotfoundseason.json");

            postResponseNotFoundSeason.ShouldNotBeNull();
            postResponseNotFoundSeason.IDs.ShouldNotBeNull();
            postResponseNotFoundSeason.IDs.Trakt.ShouldBe(61430U);
            postResponseNotFoundSeason.IDs.TVDB.ShouldBe(279121U);
            postResponseNotFoundSeason.IDs.TMDB.ShouldBe(60523U);
        }
    }
}
