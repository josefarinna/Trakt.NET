using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSyncDetailsTests
    {
        private const ulong SyncId = 12345UL;
        private const string GetSyncDetailsUri = "users/syncs/12345";

        [Fact]
        public async Task TestGetSyncDetails()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_details.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncDetailsUri, responseContent);

            TraktResponse<TraktUserSync> response = await client.Users.GetSyncDetailsAsync(
                SyncId, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ID.ShouldBe(SyncId);
            response.Content.Kind.ShouldBe(TraktUserSyncType.Plex);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetSyncDetailsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncDetailsUri, statusCode);

            Func<Task<TraktResponse<TraktUserSync>>> act = () => client.Users.GetSyncDetailsAsync(
                SyncId, cancellationToken: TestContext.Current.CancellationToken);

            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSyncDetailsThrowsRequestValidationException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncDetailsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktUserSync>>> act = () => client.Users.GetSyncDetailsAsync(
                0UL, cancellationToken: TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
