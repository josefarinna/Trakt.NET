namespace TraktNET.Json.Watchnow
{
    public sealed class TraktWatchnowOfferTests
    {
        [Fact]
        public void TestTraktWatchnowOfferConstructor()
        {
            var watchnowOffer = new TraktWatchnowOffer();

            watchnowOffer.Source.ShouldBeNull();
            watchnowOffer.Link.ShouldBeNull();
            watchnowOffer.Uhd.ShouldBeFalse();
            watchnowOffer.Currency.ShouldBeNull();
            watchnowOffer.Prices.ShouldBeNull();
            watchnowOffer.LinkTvos.ShouldBeNull();
            watchnowOffer.LinkDirect.ShouldBeNull();
            watchnowOffer.LinkAndroid.ShouldBeNull();
            watchnowOffer.LinkWebos.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchnowOfferFromJson()
        {
            TraktWatchnowOffer? watchnowOffer = await TestUtility.DeserializeJsonAsync<TraktWatchnowOffer>("Watchnow\\watchnowoffer.json");

            watchnowOffer.ShouldNotBeNull();
            watchnowOffer.Source.ShouldBe("netflix");
            watchnowOffer.Link.ShouldBe("https://netflix.com");
            watchnowOffer.Uhd.ShouldBeTrue();
            watchnowOffer.Currency.ShouldBe("USD");

            watchnowOffer.Prices.ShouldNotBeNull();
            watchnowOffer.Prices!.Rent.ShouldBe("1.99");
            watchnowOffer.Prices!.Purchase.ShouldBe("9.99");

            watchnowOffer.LinkTvos.ShouldBe("netflix-tvos://watch");
            watchnowOffer.LinkDirect.ShouldBe("https://netflix.com/direct");
            watchnowOffer.LinkAndroid.ShouldBe("netflix-android://watch");

            watchnowOffer.LinkWebos.ShouldNotBeNull();
            watchnowOffer.LinkWebos.Id.ShouldBe("com.netflix.webos");
            watchnowOffer.LinkWebos.Params.ShouldNotBeNull();
            watchnowOffer.LinkWebos.Params!.ContentTarget.ShouldBe("netflix://watch/12345");
        }

        [Fact]
        public async Task TestTraktWatchnowOffersFromJson()
        {
            IReadOnlyList<TraktWatchnowOffer>? watchnowOffers = await TestUtility.DeserializeJsonListAsync<TraktWatchnowOffer>("Watchnow\\watchnowoffers.json");

            watchnowOffers.ShouldNotBeNull();
            watchnowOffers!.Count.ShouldBe(2);

            TraktWatchnowOffer watchnowOffer = watchnowOffers![0];
            watchnowOffer.ShouldNotBeNull();
            watchnowOffer.Source.ShouldBe("netflix");
            watchnowOffer.Link.ShouldBe("https://netflix.com");
            watchnowOffer.Uhd.ShouldBeTrue();
            watchnowOffer.Currency.ShouldBe("USD");
            watchnowOffer.Prices.ShouldNotBeNull();
            watchnowOffer.Prices!.Rent.ShouldBe("1.99");
            watchnowOffer.Prices!.Purchase.ShouldBe("9.99");
            watchnowOffer.LinkTvos.ShouldBe("netflix-tvos://watch");
            watchnowOffer.LinkDirect.ShouldBe("https://netflix.com/direct");
            watchnowOffer.LinkAndroid.ShouldBe("netflix-android://watch");
            watchnowOffer.LinkWebos.ShouldNotBeNull();
            watchnowOffer.LinkWebos.Id.ShouldBe("com.netflix.webos");
            watchnowOffer.LinkWebos.Params.ShouldNotBeNull();
            watchnowOffer.LinkWebos.Params!.ContentTarget.ShouldBe("netflix://watch/12345");

            // --------------------------------------------------------------------------------------------

            watchnowOffer = watchnowOffers![1];
            watchnowOffer.ShouldNotBeNull();
            watchnowOffer.Source.ShouldBe("hulu");
            watchnowOffer.Link.ShouldBe("https://hulu.com");
            watchnowOffer.Uhd.ShouldBeFalse();
            watchnowOffer.Currency.ShouldBe("USD");
            watchnowOffer.Prices.ShouldBeNull();
            watchnowOffer.LinkTvos.ShouldBeNull();
            watchnowOffer.LinkDirect.ShouldBeNull();
            watchnowOffer.LinkAndroid.ShouldBeNull();
            watchnowOffer.LinkWebos.ShouldBeNull();
        }
    }
}
