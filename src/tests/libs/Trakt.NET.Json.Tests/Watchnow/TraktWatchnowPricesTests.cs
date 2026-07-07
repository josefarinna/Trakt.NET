namespace TraktNET.Json.Watchnow
{
    public sealed class TraktWatchnowPricesTests
    {
        [Fact]
        public void TestTraktWatchnowPricesConstructor()
        {
            var watchnowPrices = new TraktWatchnowPrices();

            watchnowPrices.Rent.ShouldBeNull();
            watchnowPrices.Purchase.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchnowPricesFromJson()
        {
            TraktWatchnowPrices? watchnowPrices = await TestUtility.DeserializeJsonAsync<TraktWatchnowPrices>("Watchnow\\watchnowprices.json");

            watchnowPrices.ShouldNotBeNull();
            watchnowPrices.Rent.ShouldBe("1.99");
            watchnowPrices.Purchase.ShouldBe("9.99");
        }
    }
}
