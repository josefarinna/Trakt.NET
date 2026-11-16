using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdateAvatarTests
    {
        private const string UpdateAvatarUri = "users/avatar";

        [Fact]
        public async Task TestUpdateAvatar()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateAvatarUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.UpdateAvatarAsync("base64imagecontent", TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUpdateAvatarThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateAvatarUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UpdateAvatarAsync("base64", TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateAvatarArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateAvatarUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.UpdateAvatarAsync(default!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdateAvatarAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdateAvatarAsync("   ", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
