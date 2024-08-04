namespace TraktNET.Json.General
{
    public partial class TraktRateLimitInfoTests
    {
        [Fact]
        public void TestTraktRateLimitInfoConstructor()
        {
            var rateLimitInfo = new TraktRateLimitInfo();

            rateLimitInfo.Name.Should().BeNull();
            rateLimitInfo.Period.Should().BeNull();
            rateLimitInfo.Limit.Should().BeNull();
            rateLimitInfo.Remaining.Should().BeNull();
            rateLimitInfo.Until.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktRateLimitInfoFromJson()
        {
            TraktRateLimitInfo? rateLimitInfo = await TestUtility.DeserializeJsonAsync<TraktRateLimitInfo>("General\\ratelimitinfo.json");

            rateLimitInfo.Should().NotBeNull();

            rateLimitInfo!.Name.Should().Be("UNAUTHED_API_GET_LIMIT");
            rateLimitInfo!.Period.Should().Be(300U);
            rateLimitInfo!.Limit.Should().Be(1000U);
            rateLimitInfo!.Remaining.Should().Be(500U);
            rateLimitInfo!.Until.Should().Be(TestUtility.ParseUTCDateTime("2024-08-04T00:24:00Z"));
        }
    }
}
