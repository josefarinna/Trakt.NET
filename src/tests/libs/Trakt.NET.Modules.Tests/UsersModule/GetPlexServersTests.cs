using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetPlexServersTests
    {
        private const string GetPlexServersUri = "users/settings/plex/servers";

        [Fact]
        public async Task TestGetPlexServers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\plexservers.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexServersUri, responseContent);
            TraktResponse<TraktPlexServersResponse> response = await client.Users.GetPlexServersAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Servers.ShouldNotBeNull();
            response.Content.Servers.Count.ShouldBe(1);
            response.Content.Servers[0].ID.ShouldBe("server1");
            response.Content.Servers[0].Name.ShouldBe("My Server");
            response.Content.Servers[0].Owned.ShouldBeTrue();
            response.Content.Servers[0].Url.ShouldBe("http://127.0.0.1:32400");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetPlexServersThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexServersUri, statusCode);

            Func<Task<TraktResponse<TraktPlexServersResponse>>> act = () => client.Users.GetPlexServersAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
