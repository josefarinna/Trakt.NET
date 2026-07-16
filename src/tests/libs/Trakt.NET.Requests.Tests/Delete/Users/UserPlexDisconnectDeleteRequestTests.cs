using System;
using System.Net.Http;
using Shouldly;
using Xunit;

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserPlexDisconnectDeleteRequestTests
    {
        [Fact]
        public void TestUserPlexDisconnectDeleteRequestHasValidURIPath()
        {
            var request = new UserPlexDisconnectDeleteRequest();
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("users/settings/plex/disconnect", UriKind.Relative));
        }

        [Fact]
        public void TestUserPlexDisconnectDeleteRequestHasValidOAuthRequirement()
        {
            var request = new UserPlexDisconnectDeleteRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPlexDisconnectDeleteRequestIsDeleteRequest()
        {
            var request = new UserPlexDisconnectDeleteRequest();
            request.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserPlexDisconnectDeleteRequestHasCorrectRequestObjectType()
        {
            var request = new UserPlexDisconnectDeleteRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
