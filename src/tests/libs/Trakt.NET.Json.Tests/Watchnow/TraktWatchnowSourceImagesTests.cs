namespace TraktNET.Json.Watchnow
{
    public sealed class TraktWatchnowSourceImagesTests
    {
        [Fact]
        public void TestTraktWatchnowSourceImagesConstructor()
        {
            var watchnowSourceImages = new TraktWatchnowSourceImages();

            watchnowSourceImages.Logo.ShouldBeNull();
            watchnowSourceImages.Channel.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchnowSourceImagesFromJson()
        {
            TraktWatchnowSourceImages? watchnowSourceImages = await TestUtility.DeserializeJsonAsync<TraktWatchnowSourceImages>("Watchnow\\watchnowsourceimages.json");

            watchnowSourceImages.ShouldNotBeNull();
            watchnowSourceImages.Logo.ShouldBe("https://images.trakt.tv/logo.png");
            watchnowSourceImages.Channel.ShouldBe("https://images.trakt.tv/channel.png");
        }
    }
}
