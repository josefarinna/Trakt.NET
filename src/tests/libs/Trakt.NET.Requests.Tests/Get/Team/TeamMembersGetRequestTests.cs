#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Team
{
    public sealed class TeamMembersGetRequestTests
    {
        private const string URIPath = "team";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestTeamMembersGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var request = new TeamMembersGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTeamMembersGetRequestHasValidOAuthRequirement()
        {
            var request = new TeamMembersGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestTeamMembersGetRequestIsGetRequest()
        {
            var request = new TeamMembersGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTeamMembersGetRequestHasCorrectRequestObjectType()
        {
            var request = new TeamMembersGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
