namespace TraktNET.Json.Checkin
{
    public sealed class TraktCheckinErrorResponseTests
    {
        [Fact]
        public void TestTraktCheckinErrorResponseConstructor()
        {
            var checkinErrorResponse = new TraktCheckinErrorResponse();

            checkinErrorResponse.ExpiresAt.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCheckinErrorResponseFromJson()
        {
            TraktCheckinErrorResponse? checkinErrorResponse = await TestUtility.DeserializeJsonAsync<TraktCheckinErrorResponse>("Checkin\\errorresponse.json");

            checkinErrorResponse.Should().NotBeNull();

            checkinErrorResponse!.ExpiresAt.Should().Be(TestUtility.ParseUTCDateTime("2024-08-04T22:21:29.000Z"));
        }
    }
}
