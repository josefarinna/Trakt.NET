using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdatePlexSettingsTests
    {
        private const string UpdatePlexSettingsUri = "users/settings/plex";

        [Fact]
        public async Task TestUpdatePlexSettings()
        {
            var updatePayload = new TraktPlexSettingsUpdate
            {
                Webhook = new TraktPlexWebhookUpdate
                {
                    HomeUsers = "user1"
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePlexSettingsUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UpdatePlexSettingsAsync(updatePayload, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUpdatePlexSettingsThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePlexSettingsUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.UpdatePlexSettingsAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUpdatePlexSettingsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var updatePayload = new TraktPlexSettingsUpdate();
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdatePlexSettingsUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UpdatePlexSettingsAsync(updatePayload, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
