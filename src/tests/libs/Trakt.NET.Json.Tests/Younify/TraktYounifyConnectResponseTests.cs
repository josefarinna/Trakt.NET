using Shouldly;
using Xunit;

namespace TraktNET.Json.Younify
{
    public sealed class TraktYounifyConnectResponseTests
    {
        [Fact]
        public void TestTraktYounifyConnectResponseDefaultConstructor()
        {
            var response = new TraktYounifyConnectResponse();
            response.Url.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktYounifyConnectResponseFromJson()
        {
            TraktYounifyConnectResponse? response =
                await TestUtility.DeserializeJsonAsync<TraktYounifyConnectResponse>("Younify\\connect.json");

            response.ShouldNotBeNull();
            response.Url.ShouldBe("https://younify.trakt.tv/connect/netflix?token=abcdef");
        }
    }
}
