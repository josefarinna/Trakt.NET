namespace TraktNET.Json.Watchnow
{
    public sealed class TraktWatchnowWebosParamsTests
    {
        [Fact]
        public void TestTraktWatchnowWebosParamsConstructor()
        {
            var watchnowWebosParams = new TraktWatchnowWebosParams();

            watchnowWebosParams.ContentTarget.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchnowWebosParamsFromJson()
        {
            TraktWatchnowWebosParams? watchnowWebosParams = await TestUtility.DeserializeJsonAsync<TraktWatchnowWebosParams>("Watchnow\\watchnowwebosparams.json");

            watchnowWebosParams.ShouldNotBeNull();
            watchnowWebosParams.ContentTarget.ShouldBe("netflix://watch/12345");
        }
    }
}
