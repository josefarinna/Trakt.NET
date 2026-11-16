using System.Net;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TraktNET.UsersModule
{
    public sealed class BlockUserTests
    {
        private const string BlockUserUri = $"users/{Username}/block";
        private const string Username = "baduser";

        [Fact]
        public async Task TestBlockUser()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(BlockUserUri, HttpStatusCode.Created);
            TraktResponse response = await client.Users.BlockUserAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestBlockUserThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(BlockUserUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.BlockUserAsync(Username, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
