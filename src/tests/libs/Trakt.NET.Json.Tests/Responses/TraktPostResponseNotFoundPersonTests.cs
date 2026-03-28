namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundPersonTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundPersonDefaultConstructor()
        {
            var postResponseNotFoundPerson = new TraktPostResponseNotFoundPerson();

            postResponseNotFoundPerson.IDs.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPostResponseNotFoundPersonFromJson()
        {
            TraktPostResponseNotFoundPerson? postResponseNotFoundPerson = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundPerson>("Responses\\traktpostresponsenotfoundperson.json");

            postResponseNotFoundPerson.ShouldNotBeNull();
            postResponseNotFoundPerson.IDs.ShouldNotBeNull();
            postResponseNotFoundPerson.IDs.Trakt.ShouldBe(297737U);
            postResponseNotFoundPerson.IDs.Slug.ShouldBe("bryan-cranston");
            postResponseNotFoundPerson.IDs.IMDB.ShouldBe("nm0186505");
            postResponseNotFoundPerson.IDs.TMDB.ShouldBe(17419U);
        }
    }
}
