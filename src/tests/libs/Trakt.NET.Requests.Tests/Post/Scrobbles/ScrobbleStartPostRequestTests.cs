#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Scrobbles
{
    public sealed class ScrobbleStartPostRequestTests
    {
        private const string URIPath = "scrobble/start";

        [Fact]
        public void TestScrobbleStartPostRequestHasValidURIPath()
        {
            var scrobbleStartPostRequest = new ScrobbleStartPostRequest
            {
                TraktScrobblePost = new TraktScrobblePost { Progress = default! }
            };

            scrobbleStartPostRequest.BuildUri();
            scrobbleStartPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestScrobbleStartPostRequestHasValidOAuthRequirement()
        {
            var scrobbleStartPostRequest = new ScrobbleStartPostRequest { TraktScrobblePost = default! };
            scrobbleStartPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestScrobbleStartPostRequestIsPostRequest()
        {
            var scrobbleStartPostRequest = new ScrobbleStartPostRequest { TraktScrobblePost = default! };
            scrobbleStartPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestScrobbleStartPostRequestHasCorrectRequestObjectType()
        {
            var scrobbleStartPostRequest = new ScrobbleStartPostRequest { TraktScrobblePost = default! };
            scrobbleStartPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestScrobbleStartPostRequestValidate()
        {
            var scrobbleStartPostRequest = new ScrobbleStartPostRequest { TraktScrobblePost = default! };
            Action act = () => scrobbleStartPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
