#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPlexServerAccountsGetRequestTests
    {
        [Fact]
        public void TestUserPlexServerAccountsGetRequestHasValidURIPath()
        {
            var request = new UserPlexServerAccountsGetRequest
            {
                ServerId = "server123"
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("users/settings/plex/servers/server123", UriKind.Relative));
        }

        [Fact]
        public void TestUserPlexServerAccountsGetRequestHasValidOAuthRequirement()
        {
            var request = new UserPlexServerAccountsGetRequest { ServerId = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPlexServerAccountsGetRequestIsGetRequest()
        {
            var request = new UserPlexServerAccountsGetRequest { ServerId = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserPlexServerAccountsGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserPlexServerAccountsGetRequest { ServerId = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPlexServerAccountsGetRequestValidate()
        {
            var request = new UserPlexServerAccountsGetRequest { ServerId = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserPlexServerAccountsGetRequest { ServerId = string.Empty };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserPlexServerAccountsGetRequest { ServerId = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new UserPlexServerAccountsGetRequest { ServerId = "server id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
