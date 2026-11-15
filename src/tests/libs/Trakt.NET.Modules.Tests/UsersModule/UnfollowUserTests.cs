using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UnfollowUserTests
    {
        private const string UnfollowUserUri = $"users/{Username}/follow";
        private const string Username = "sean";

        [Fact]
        public async Task TestUnfollowUser()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnfollowUserUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UnfollowUserAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUnfollowUserThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnfollowUserUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UnfollowUserAsync(Username, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
