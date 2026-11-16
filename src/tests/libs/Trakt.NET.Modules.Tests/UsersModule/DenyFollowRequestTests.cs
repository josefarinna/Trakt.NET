using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class DenyFollowRequestTests
    {
        private readonly string DenyFollowRequestUri = $"users/requests/{RequestID}";
        private const uint RequestID = 3U;

        [Fact]
        public async Task TestDenyFollowRequest()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DenyFollowRequestUri, HttpStatusCode.NoContent);
            
            TraktResponse response = await client.Users.DenyFollowRequestAsync(RequestID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestDenyFollowRequestThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DenyFollowRequestUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.DenyFollowRequestAsync(RequestID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
