#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Comments
{
    public sealed class CommentUpdatePutRequestTests
    {
        private const string URIPath = "comments/123";

        [Fact]
        public void TestCommentUpdatePutRequestHasValidURIPath()
        {
            var commentUpdatePutRequest = new CommentUpdatePutRequest
            {
                TraktCommentUpdatePost = new TraktCommentUpdatePost { Comment = default! },
                Id = "123"
            };

            commentUpdatePutRequest.BuildUri();
            commentUpdatePutRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentUpdatePutRequestHasValidOAuthRequirement()
        {
            var commentUpdatePutRequest = new CommentUpdatePutRequest { TraktCommentUpdatePost = default!, Id = default! };
            commentUpdatePutRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentUpdatePutRequestIsPutRequest()
        {
            var commentUpdatePutRequest = new CommentUpdatePutRequest { TraktCommentUpdatePost = default!, Id = default! };
            commentUpdatePutRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestCommentUpdatePutRequestHasCorrectRequestObjectType()
        {
            var commentUpdatePutRequest = new CommentUpdatePutRequest { TraktCommentUpdatePost = default!, Id = default! };
            commentUpdatePutRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentUpdatePutRequestValidate()
        {
            var commentUpdatePutRequest = new CommentUpdatePutRequest { TraktCommentUpdatePost = default!, Id = string.Empty };
            Action act = () => commentUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentUpdatePutRequest = new CommentUpdatePutRequest { TraktCommentUpdatePost = default!, Id = "  " };
            act = () => commentUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentUpdatePutRequest = new CommentUpdatePutRequest { TraktCommentUpdatePost = default!, Id = "id with spaces" };
            act = () => commentUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentUpdatePutRequest = new CommentUpdatePutRequest { TraktCommentUpdatePost = default!, Id = default! };
            act = () => commentUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
