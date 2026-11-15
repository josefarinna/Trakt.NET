using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class UpdateFavoriteItemTests
    {
        private readonly string UpdateFavoriteItemUri = $"sync/favorites/{FavoriteItemId}";
        private const uint FavoriteItemId = 123U;
        private const string Notes = "This is a great movie!";

        [Fact]
        public async Task TestUpdateFavoriteItem()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateFavoriteItemUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Sync.UpdateFavoriteItemAsync(FavoriteItemId, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUpdateFavoriteItemThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateFavoriteItemUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Sync.UpdateFavoriteItemAsync(FavoriteItemId, Notes, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
