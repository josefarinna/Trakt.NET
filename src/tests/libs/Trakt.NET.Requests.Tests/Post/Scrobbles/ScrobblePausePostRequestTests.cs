#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Scrobbles
{
    public sealed class ScrobblePausePostRequestTests
    {
        private const string URIPath = "scrobble/pause";

        [Fact]
        public void TestScrobblePausePostRequestHasValidURIPath()
        {
            var scrobblePausePostRequest = new ScrobblePausePostRequest
            {
                TraktScrobblePost = new TraktScrobblePost { Progress = default! }
            };

            scrobblePausePostRequest.BuildUri();
            scrobblePausePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestScrobblePausePostRequestHasValidOAuthRequirement()
        {
            var scrobblePausePostRequest = new ScrobblePausePostRequest { TraktScrobblePost = default! };
            scrobblePausePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestScrobblePausePostRequestIsPostRequest()
        {
            var scrobblePausePostRequest = new ScrobblePausePostRequest { TraktScrobblePost = default! };
            scrobblePausePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestScrobblePausePostRequestHasCorrectRequestObjectType()
        {
            var scrobblePausePostRequest = new ScrobblePausePostRequest { TraktScrobblePost = default! };
            scrobblePausePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestScrobblePausePostRequestValidate()
        {
            var scrobblePausePostRequest = new ScrobblePausePostRequest { TraktScrobblePost = default! };
            Action act = () => scrobblePausePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
