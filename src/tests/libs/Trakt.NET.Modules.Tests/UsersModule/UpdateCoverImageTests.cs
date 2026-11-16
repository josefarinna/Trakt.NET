using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdateCoverImageTests
    {
        private const string UpdateCoverUri = "users/set_cover";

        [Fact]
        public async Task TestUpdateCover()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCoverUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.UpdateCoverImageAsync(TraktCoverType.Movie, 123U, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUpdateCoverThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCoverUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UpdateCoverImageAsync(TraktCoverType.Movie, 123U, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateCoverArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCoverUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.UpdateCoverImageAsync(TraktCoverType.Unspecified, 123U, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Users.UpdateCoverImageAsync(TraktCoverType.Movie, 0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
