using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class RemovePlaybackItemTests
    {
        private const uint PlaybackId = 42U;
        private readonly string RemovePlaybackItemUri = $"sync/playback/{PlaybackId}";

        [Fact]
        public async Task TestRemovePlaybackItem()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemovePlaybackItemUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Sync.RemovePlaybackItemAsync(PlaybackId, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestRemovePlaybackItemThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemovePlaybackItemUri, statusCode);


            Func<Task<TraktResponse>> act = () => client.Sync.RemovePlaybackItemAsync(PlaybackId, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRemovePlaybackItemThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemovePlaybackItemUri, HttpStatusCode.OK);

            Func<Task<TraktResponse>> act = () => client.Sync.RemovePlaybackItemAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
