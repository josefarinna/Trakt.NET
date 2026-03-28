namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundShowTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundShowDefaultConstructor()
        {
            var postResponseNotFoundShow = new TraktPostResponseNotFoundShow();

            postResponseNotFoundShow.IDs.ShouldBeNull();
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
    }
}
