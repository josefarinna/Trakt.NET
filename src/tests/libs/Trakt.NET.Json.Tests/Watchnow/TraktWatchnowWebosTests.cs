namespace TraktNET.Json.Watchnow
{
    public sealed class TraktWatchnowWebosTests
    {
        [Fact]
        public void TestTraktWatchnowWebosConstructor()
        {
            var watchnowWebos = new TraktWatchnowWebos();

            watchnowWebos.ID.ShouldBeNull();
            watchnowWebos.Params.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchnowWebosFromJson()
        {
            TraktWatchnowWebos? watchnowWebos = await TestUtility.DeserializeJsonAsync<TraktWatchnowWebos>("Watchnow\\watchnowwebos.json");

            watchnowWebos.ShouldNotBeNull();
            watchnowWebos.ID.ShouldBe("com.netflix.webos");
            watchnowWebos.Params.ShouldNotBeNull();
            watchnowWebos.Params.ContentTarget.ShouldBe("netflix://watch/12345");
        }
    }
}
