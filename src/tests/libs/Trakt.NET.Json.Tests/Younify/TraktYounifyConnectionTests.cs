using Shouldly;
using Xunit;

namespace TraktNET.Json.Younify
{
    public sealed class TraktYounifyConnectionTests
    {
        [Fact]
        public void TestTraktYounifyConnectionDefaultConstructor()
        {
            var connection = new TraktYounifyConnection();

            connection.Id.ShouldBeNull();
            connection.Name.ShouldBeNull();
            connection.Vip.ShouldBeNull();
            connection.Color.ShouldBeNull();
            connection.Images.ShouldBeNull();
            connection.Connectable.ShouldBeNull();
            connection.Connected.ShouldBeNull();
            connection.Active.ShouldBeNull();
            connection.Profile.ShouldBeNull();
            connection.LastSyncedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktYounifyConnectionFromJson()
        {
            IReadOnlyList<TraktYounifyConnection>? connections =
                await TestUtility.DeserializeJsonAsync<IReadOnlyList<TraktYounifyConnection>>("Younify\\connections.json");

            connections.ShouldNotBeNull();
            connections.Count.ShouldBe(1);

            TraktYounifyConnection connection = connections[0];
            connection.Id.ShouldBe("netflix");
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
    }
}
