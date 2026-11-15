using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ConnectPlexTests
    {
        private const string ConnectPlexUri = "users/settings/plex/connect";

        [Fact]
        public async Task TestConnectPlex()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\plexconnect.json");

            var connectPost = new TraktPlexConnectPost
            {
                ReturnUrl = "https://trakt.tv/plex"
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectPlexUri, responseContent);
            TraktResponse<TraktPlexConnectResponse> response = await client.Users.ConnectPlexAsync(connectPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Url.ShouldBe("https://plex.tv/auth");
        }

        [Fact]
        public async Task TestConnectPlexThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectPlexUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktPlexConnectResponse>>> act = () => client.Users.ConnectPlexAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestConnectPlexThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var connectPost = new TraktPlexConnectPost { ReturnUrl = "https://trakt.tv/plex" };
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectPlexUri, statusCode);

            Func<Task<TraktResponse<TraktPlexConnectResponse>>> act = () => client.Users.ConnectPlexAsync(connectPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
