using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UndoSyncTests
    {
        private const ulong SyncId = 12345UL;
        private const string UndoSyncUri = "users/syncs/12345";

        [Fact]
        public async Task TestUndoSync()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoSyncUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.UndoSyncAsync(
                SyncId, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUndoSyncThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoSyncUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UndoSyncAsync(
                SyncId, cancellationToken: TestContext.Current.CancellationToken);

            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUndoSyncThrowsRequestValidationException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoSyncUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.UndoSyncAsync(
                0UL, cancellationToken: TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
