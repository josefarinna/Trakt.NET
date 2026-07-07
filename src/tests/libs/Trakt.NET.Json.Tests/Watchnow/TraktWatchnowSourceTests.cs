namespace TraktNET.Json.Watchnow
{
    public sealed class TraktWatchnowSourceTests
    {
        [Fact]
        public void TestTraktWatchnowSourceConstructor()
        {
            var watchnowSource = new TraktWatchnowSource();

            watchnowSource.Source.ShouldBeNull();
            watchnowSource.Name.ShouldBeNull();
            watchnowSource.Free.ShouldBeFalse();
            watchnowSource.Cinema.ShouldBeFalse();
            watchnowSource.Amazon.ShouldBeFalse();
            watchnowSource.Color.ShouldBeNull();
            watchnowSource.LinkCount.ShouldBe(0);
            watchnowSource.Images.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchnowSourceFromJson()
        {
            TraktWatchnowSource? watchnowSource = await TestUtility.DeserializeJsonAsync<TraktWatchnowSource>("Watchnow\\watchnowsource.json");

            watchnowSource.ShouldNotBeNull();
            watchnowSource.Source.ShouldBe("netflix");
            watchnowSource.Name.ShouldBe("Netflix");
            watchnowSource.Free.ShouldBeFalse();
            watchnowSource.Cinema.ShouldBeFalse();
            watchnowSource.Amazon.ShouldBeFalse();
            watchnowSource.Color.ShouldBe("#E50914");
            watchnowSource.LinkCount.ShouldBe(12);

            watchnowSource.Images.ShouldNotBeNull();
            watchnowSource.Images.Logo.ShouldBe("https://images.trakt.tv/logo.png");
            watchnowSource.Images.Channel.ShouldBe("https://images.trakt.tv/channel.png");
        }

        [Fact]
        public async Task TestTraktWatchnowSourcesFromJson()
        {
            IReadOnlyList<TraktWatchnowSource>? watchnowSources = await TestUtility.DeserializeJsonListAsync<TraktWatchnowSource>("Watchnow\\watchnowsource_list.json");

            watchnowSources.ShouldNotBeNull();
            watchnowSources!.Count.ShouldBe(2);

            TraktWatchnowSource watchnowSource = watchnowSources![0];
            watchnowSource.ShouldNotBeNull();
            watchnowSource.Source.ShouldBe("netflix");
            watchnowSource.Name.ShouldBe("Netflix");
            watchnowSource.Free.ShouldBeFalse();
            watchnowSource.Cinema.ShouldBeFalse();
            watchnowSource.Amazon.ShouldBeFalse();
            watchnowSource.Color.ShouldBe("#E50914");
            watchnowSource.LinkCount.ShouldBe(12);
            watchnowSource.Images.ShouldNotBeNull();
            watchnowSource.Images.Logo.ShouldBe("https://images.trakt.tv/logo.png");
            watchnowSource.Images.Channel.ShouldBe("https://images.trakt.tv/channel.png");

            // --------------------------------------------------------------------------------------------

            watchnowSource = watchnowSources![1];
            watchnowSource.ShouldNotBeNull();
            watchnowSource.Source.ShouldBe("hulu");
            watchnowSource.Name.ShouldBe("Hulu");
            watchnowSource.Free.ShouldBeTrue();
            watchnowSource.Cinema.ShouldBeTrue();
            watchnowSource.Amazon.ShouldBeTrue();
            watchnowSource.Color.ShouldBe("#1CE783");
            watchnowSource.LinkCount.ShouldBe(5);
            watchnowSource.Images.ShouldBeNull();
        }
    }
}
