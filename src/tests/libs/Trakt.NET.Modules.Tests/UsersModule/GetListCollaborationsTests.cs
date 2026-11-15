using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetListCollaborationsTests
    {
        private const string GetListsCollaborationsUri = $"users/{Username}/lists/collaborations";
        private const string Username = "sean";

        [Fact]
        public async Task TestGetListCollaborations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\lists.json");

            TraktClient client = ModuleTestUtility.GetClient(GetListsCollaborationsUri, responseContent);
            
            TraktListResponse<TraktList> response = await client.Users.GetListCollaborationsAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetListCollaborationsWithOAuthEnfored()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\lists.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetListsCollaborationsUri, responseContent);
            client.IgnoreOAuthIfOptional = false;

            TraktListResponse<TraktList> response = await client.Users.GetListCollaborationsAsync(Username, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetListCollaborationsWithOAuthEnforedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\lists.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/lists/collaborations", responseContent);
            
            TraktListResponse<TraktList> response = await client.Users.GetListCollaborationsAsync("me", TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetListCollaborationsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListsCollaborationsUri, statusCode);

            Func<Task<TraktListResponse<TraktList>>> act = () => client.Users.GetListCollaborationsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
