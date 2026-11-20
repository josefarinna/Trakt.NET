namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundShowTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundShowDefaultConstructor()
        {
            var postResponseNotFoundShow = new TraktPostResponseNotFoundShow();

            postResponseNotFoundShow.Title.ShouldBeNull();
            postResponseNotFoundShow.Year.ShouldBeNull();
            postResponseNotFoundShow.IDs.ShouldBeNull();
            postResponseNotFoundShow.Seasons.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPostResponseNotFoundShowFromJson()
        {
            TraktPostResponseNotFoundShow? postResponseNotFoundShow = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundShow>("Responses\\traktpostresponsenotfoundshow.json");

            postResponseNotFoundShow.ShouldNotBeNull();
            postResponseNotFoundShow.IDs.ShouldNotBeNull();
            postResponseNotFoundShow.IDs.Trakt.ShouldBe(1390U);
            postResponseNotFoundShow.IDs.Slug.ShouldBe("game-of-thrones");
            postResponseNotFoundShow.IDs.TVDB.ShouldBe(121361U);
            postResponseNotFoundShow.IDs.IMDB.ShouldBe("tt0944947");
            postResponseNotFoundShow.IDs.TMDB.ShouldBe(1399U);
        }

        [Fact]
        public async Task TestTraktPostResponseNotFoundShowFromJsonShowShaped()
        {
            TraktPostResponseNotFoundShow? postResponseNotFoundShow = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundShow>("Responses\\traktpostresponsenotfoundshowshaped.json");

            postResponseNotFoundShow.ShouldNotBeNull();
            postResponseNotFoundShow.Title.ShouldBe("Breaking Bad");
            postResponseNotFoundShow.Year.ShouldBe(2008U);
            postResponseNotFoundShow.IDs.ShouldNotBeNull();
            postResponseNotFoundShow.IDs.Trakt.ShouldBe(1388U);
            postResponseNotFoundShow.Seasons.ShouldNotBeNull();
            postResponseNotFoundShow.Seasons.Count.ShouldBe(1);
            postResponseNotFoundShow.Seasons[0].Number.ShouldBe(99U);
            postResponseNotFoundShow.Seasons[0].Episodes.ShouldNotBeNull();
            postResponseNotFoundShow.Seasons[0].Episodes!.Count.ShouldBe(1);
            postResponseNotFoundShow.Seasons[0].Episodes![0].Number.ShouldBe(42U);
        }
    }
}
