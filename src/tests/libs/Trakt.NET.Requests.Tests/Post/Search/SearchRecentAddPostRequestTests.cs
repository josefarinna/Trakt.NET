#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Search
{
    public sealed class SearchRecentAddPostRequestTests
    {
        private const string URIPath = "search/recent";

        [Fact]
        public void TestSearchRecentAddPostRequestHasValidURIPath()
        {
            var request = new SearchRecentAddPostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = "batman",
                    Id = 99U,
                    Type = TraktSearchRecentType.Movie
                }
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSearchRecentAddPostRequestHasValidOAuthRequirement()
        {
            var request = new SearchRecentAddPostRequest { TraktSearchRecentPost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSearchRecentAddPostRequestIsPostRequest()
        {
            var request = new SearchRecentAddPostRequest { TraktSearchRecentPost = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSearchRecentAddPostRequestHasCorrectRequestObjectType()
        {
            var request = new SearchRecentAddPostRequest { TraktSearchRecentPost = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSearchRecentAddPostRequestValidate()
        {
            var request = new SearchRecentAddPostRequest { TraktSearchRecentPost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SearchRecentAddPostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = null,
                    Id = 99U,
                    Type = TraktSearchRecentType.Movie
                }
            };
            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            request = new SearchRecentAddPostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = string.Empty,
                    Id = 99U,
                    Type = TraktSearchRecentType.Movie
                }
            };
            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            request = new SearchRecentAddPostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = "  ",
                    Id = 99U,
                    Type = TraktSearchRecentType.Movie
                }
            };
            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            request = new SearchRecentAddPostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = "batman",
                    Id = 0U,
                    Type = TraktSearchRecentType.Movie
                }
            };
            act = () => request.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            request = new SearchRecentAddPostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = "batman",
                    Id = 99U,
                    Type = null
                }
            };
            act = () => request.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            request = new SearchRecentAddPostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = "batman",
                    Id = 99U,
                    Type = TraktSearchRecentType.Unspecified
                }
            };
            act = () => request.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
