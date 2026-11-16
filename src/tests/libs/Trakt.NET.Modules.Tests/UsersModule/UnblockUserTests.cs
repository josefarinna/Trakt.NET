using System.Net;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TraktNET.UsersModule
{
    public sealed class UnblockUserTests
    {
        private const string UnblockUserUri = $"users/{Username}/block";
        private const string Username = "baduser";

        [Fact]
        public async Task TestUnblockUser()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnblockUserUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Users.UnblockUserAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUnblockUserThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnblockUserUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UnblockUserAsync(Username, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
