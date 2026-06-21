#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Scrobbles
{
    public sealed class ScrobbleStopPostRequestTests
    {
        private const string URIPath = "scrobble/stop";

        [Fact]
        public void TestScrobbleStopPostRequestHasValidURIPath()
        {
            var scrobbleStopPostRequest = new ScrobbleStopPostRequest
            {
                TraktScrobblePost = new TraktScrobblePost { Progress = default! }
            };

            scrobbleStopPostRequest.BuildUri();
            scrobbleStopPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestScrobbleStopPostRequestHasValidOAuthRequirement()
        {
            var scrobbleStopPostRequest = new ScrobbleStopPostRequest { TraktScrobblePost = default! };
            scrobbleStopPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestScrobbleStopPostRequestIsPostRequest()
        {
            var scrobbleStopPostRequest = new ScrobbleStopPostRequest { TraktScrobblePost = default! };
            scrobbleStopPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestScrobbleStopPostRequestHasCorrectRequestObjectType()
        {
            var scrobbleStopPostRequest = new ScrobbleStopPostRequest { TraktScrobblePost = default! };
            scrobbleStopPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestScrobbleStopPostRequestValidate()
        {
            var scrobbleStopPostRequest = new ScrobbleStopPostRequest { TraktScrobblePost = default! };
            Action act = () => scrobbleStopPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
