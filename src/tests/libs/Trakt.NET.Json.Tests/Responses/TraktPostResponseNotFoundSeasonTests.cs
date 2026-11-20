namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundSeasonTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundSeasonDefaultConstructor()
        {
            var postResponseNotFoundSeason = new TraktPostResponseNotFoundSeason();

            postResponseNotFoundSeason.Title.ShouldBeNull();
            postResponseNotFoundSeason.Year.ShouldBeNull();
            postResponseNotFoundSeason.IDs.ShouldBeNull();
            postResponseNotFoundSeason.Seasons.ShouldBeNull();
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

        [Fact]
        public async Task TestTraktPostResponseNotFoundSeasonFromJsonShowShaped()
        {
            TraktPostResponseNotFoundSeason? postResponseNotFoundSeason = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundSeason>("Responses\\traktpostresponsenotfoundshowshaped.json");

            postResponseNotFoundSeason.ShouldNotBeNull();
            postResponseNotFoundSeason.Title.ShouldBe("Breaking Bad");
            postResponseNotFoundSeason.Year.ShouldBe(2008U);
            postResponseNotFoundSeason.IDs.ShouldNotBeNull();
            postResponseNotFoundSeason.IDs.Trakt.ShouldBe(1388U);
            postResponseNotFoundSeason.Seasons.ShouldNotBeNull();
            postResponseNotFoundSeason.Seasons.Count.ShouldBe(1);
            postResponseNotFoundSeason.Seasons[0].Number.ShouldBe(99U);
            postResponseNotFoundSeason.Seasons[0].Episodes.ShouldNotBeNull();
            postResponseNotFoundSeason.Seasons[0].Episodes!.Count.ShouldBe(1);
            postResponseNotFoundSeason.Seasons[0].Episodes![0].Number.ShouldBe(42U);
        }
    }
}
