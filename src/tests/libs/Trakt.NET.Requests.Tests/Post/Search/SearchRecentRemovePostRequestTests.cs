#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Search
{
    public sealed class SearchRecentRemovePostRequestTests
    {
        private const string URIPath = "search/recent/remove";

        [Fact]
        public void TestSearchRecentRemovePostRequestHasValidURIPath()
        {
            var request = new SearchRecentRemovePostRequest
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
        public void TestSearchRecentRemovePostRequestHasValidOAuthRequirement()
        {
            var request = new SearchRecentRemovePostRequest { TraktSearchRecentPost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSearchRecentRemovePostRequestIsPostRequest()
        {
            var request = new SearchRecentRemovePostRequest { TraktSearchRecentPost = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSearchRecentRemovePostRequestHasCorrectRequestObjectType()
        {
            var request = new SearchRecentRemovePostRequest { TraktSearchRecentPost = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSearchRecentRemovePostRequestValidate()
        {
            var request = new SearchRecentRemovePostRequest { TraktSearchRecentPost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SearchRecentRemovePostRequest
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

            request = new SearchRecentRemovePostRequest
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

            request = new SearchRecentRemovePostRequest
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

            request = new SearchRecentRemovePostRequest
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

            request = new SearchRecentRemovePostRequest
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
