using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class RemoveAvatarTests
    {
        private const string RemoveAvatarUri = "users/avatar";

        [Fact]
        public async Task TestRemoveAvatar()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveAvatarUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.RemoveAvatarAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestRemoveAvatarThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveAvatarUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.RemoveAvatarAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
