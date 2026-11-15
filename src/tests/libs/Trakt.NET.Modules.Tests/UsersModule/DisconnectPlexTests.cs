using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class DisconnectPlexTests
    {
        private const string DisconnectPlexUri = "users/settings/plex/disconnect";

        [Fact]
        public async Task TestDisconnectPlex()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DisconnectPlexUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.DisconnectPlexAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestDisconnectPlexThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DisconnectPlexUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.DisconnectPlexAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
