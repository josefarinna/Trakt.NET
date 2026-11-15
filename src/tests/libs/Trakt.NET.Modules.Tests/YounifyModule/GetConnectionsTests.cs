using System.Net;
using Shouldly;
using Xunit;

namespace TraktNET.YounifyModule
{
    public sealed class GetConnectionsTests
    {
        private const string ConnectionsUri = "younify/connections";

        [Fact]
        public async Task TestGetConnections()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Younify\\connections.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectionsUri, responseContent);

            TraktListResponse<TraktYounifyConnection> response =
                await client.Younify.GetConnectionsAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
            
            TraktYounifyConnection connection = response.Content[0];
            connection.ID.ShouldBe("netflix");
            connection.Name.ShouldBe("Netflix");
            connection.Vip.ShouldBe(false);
            connection.Color.ShouldBe("#e50914");
            connection.Images.ShouldNotBeNull();
            connection.Images.Logo.ShouldBe("https://walter.trakt.tv/images/younify/netflix.png");
            connection.Connectable.ShouldBe(true);
            connection.Connected.ShouldBe(true);
            connection.Active.ShouldBe(true);
            connection.Profile.ShouldBe("John Doe");
            connection.LastSyncedAt.ShouldBe("2026-07-18T12:00:00.000Z");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetConnectionsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectionsUri, statusCode);

            Func<Task<TraktListResponse<TraktYounifyConnection>>> act = () => client.Younify.GetConnectionsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
