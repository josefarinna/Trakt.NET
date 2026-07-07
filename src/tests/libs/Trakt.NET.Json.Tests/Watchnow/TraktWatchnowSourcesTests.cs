namespace TraktNET.Json.Watchnow
{
    public sealed class TraktWatchnowSourcesTests
    {
        [Fact]
        public void TestTraktWatchnowSourcesConstructor()
        {
            var watchnowSources = new TraktWatchnowSources();

            watchnowSources.Cable.ShouldBeNull();
            watchnowSources.Free.ShouldBeNull();
            watchnowSources.Cinema.ShouldBeNull();
            watchnowSources.Subscription.ShouldBeNull();
            watchnowSources.Purchase.ShouldBeNull();
            watchnowSources.StreamingRanks.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchnowSourcesFromJson()
        {
            TraktWatchnowSources? watchnowSources = await TestUtility.DeserializeJsonAsync<TraktWatchnowSources>("Watchnow\\watchnowsources.json");

            watchnowSources.ShouldNotBeNull();

            watchnowSources.Cable.ShouldNotBeNull();
            watchnowSources.Cable.Count.ShouldBe(1);
            watchnowSources.Cable[0].Source.ShouldBe("netflix");
            watchnowSources.Cable[0].Link.ShouldBe("https://netflix.com");

            watchnowSources.Free.ShouldNotBeNull();
            watchnowSources.Free.Count.ShouldBe(1);
            watchnowSources.Free[0].Source.ShouldBe("hulu");
            watchnowSources.Free[0].Link.ShouldBe("https://hulu.com");

            watchnowSources.Cinema.ShouldNotBeNull();
            watchnowSources.Cinema.Count.ShouldBe(1);
            watchnowSources.Cinema[0].Source.ShouldBe("disney");
            watchnowSources.Cinema[0].Link.ShouldBe("https://disney.com");

            watchnowSources.Subscription.ShouldNotBeNull();
            watchnowSources.Subscription.Count.ShouldBe(1);
            watchnowSources.Subscription[0].Source.ShouldBe("apple");
            watchnowSources.Subscription[0].Link.ShouldBe("https://apple.com");

            watchnowSources.Purchase.ShouldNotBeNull();
            watchnowSources.Purchase.Count.ShouldBe(1);
            watchnowSources.Purchase[0].Source.ShouldBe("amazon");
            watchnowSources.Purchase[0].Link.ShouldBe("https://amazon.com");

            watchnowSources.StreamingRanks.ShouldNotBeNull();
            watchnowSources.StreamingRanks.Rank.ShouldBe(5);
            watchnowSources.StreamingRanks.Delta.ShouldBe(2);
            watchnowSources.StreamingRanks.Link.ShouldBe("https://trakt.tv/shows/trending/rank");
        }
    }
}
