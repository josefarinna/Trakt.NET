#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Comments
{
    public sealed class CommentPostRequestTests
    {
        private const string URIPath = "comments";

        [Fact]
        public void TestCommentPostRequestHasValidURIPath()
        {
            var commentPostRequest = new CommentPostRequest
            {
                TraktCommentPost = new TraktNET.TraktCommentPost { Comment = default! }
            };

            commentPostRequest.BuildUri();
            commentPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentPostRequestHasValidOAuthRequirement()
        {
            var commentPostRequest = new CommentPostRequest { TraktCommentPost = default! };
            commentPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentPostRequestIsPostRequest()
        {
            var commentPostRequest = new CommentPostRequest { TraktCommentPost = default! };
            commentPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestCommentPostRequestHasCorrectRequestObjectType()
        {
            var commentPostRequest = new CommentPostRequest { TraktCommentPost = default! };
            commentPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentPostRequestValidate()
        {
            var commentPostRequest = new CommentPostRequest { TraktCommentPost = default! };
            Action act = () => commentPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
