using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class SyncPlexTests
    {
        private const string SyncPlexUri = "users/settings/plex/sync";

        [Fact]
        public async Task TestSyncPlex()
        {
            var syncPost = new TraktPlexSyncPost
            {
                ServerID = "server1",
                AllData = true
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(SyncPlexUri, HttpStatusCode.Created);
            TraktResponse response = await client.Users.SyncPlexAsync(syncPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestSyncPlexThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(SyncPlexUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Users.SyncPlexAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestSyncPlexThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var syncPost = new TraktPlexSyncPost();
            TraktClient client = ModuleTestUtility.GetOAuthClient(SyncPlexUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.SyncPlexAsync(syncPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
