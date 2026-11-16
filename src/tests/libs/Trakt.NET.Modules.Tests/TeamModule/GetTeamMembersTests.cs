using System.Net;

namespace TraktNET.TeamModule
{
    public sealed class GetTeamMembersTests
    {
        private const string GET_TEAM_MEMBERS_URI = "team";

        [Fact]
        public async Task TestGetTeamMembers()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Team\\teammembers.json");

            TraktClient client = ModuleTestUtility.GetClient(GET_TEAM_MEMBERS_URI, responseContent);

            TraktListResponse<TraktTeamMember> response = await client.Team.GetTeamMembersAsync(
                cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);

            TraktTeamMember member = response.Content[0];
            member.ShouldNotBeNull();
            member.User.ShouldNotBeNull();
            member.User.Username.ShouldBe("sean");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetTeamMembersThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GET_TEAM_MEMBERS_URI, statusCode);

            Func<Task<TraktListResponse<TraktTeamMember>>> act = () => client.Team.GetTeamMembersAsync(
                cancellationToken: TestContext.Current.CancellationToken);

            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
