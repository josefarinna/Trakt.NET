#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Users
{
    public sealed class UserCoverPutRequestTests
    {
        private const string URIPath = "users/set_cover";

        [Fact]
        public async Task TestUserCoverPutRequestHasValidURIPath()
        {
            var request = new UserCoverPutRequest
            {
                TraktUserCoverPost = new TraktUserCoverPost { CoverType = TraktCoverType.Movie, CoverId = 123U }
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public async Task TestUserCoverPutRequestHasValidOAuthRequirement()
        {
            var request = new UserCoverPutRequest { TraktUserCoverPost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public async Task TestUserCoverPutRequestIsPutRequest()
        {
            var request = new UserCoverPutRequest { TraktUserCoverPost = default! };
            request.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestUserCoverPutRequestValidate()
        {
            var request = new UserCoverPutRequest { TraktUserCoverPost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
