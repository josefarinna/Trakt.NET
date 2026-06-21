#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Lists
{
    public sealed class ListCommentsGetRequestTests
    {
        [Theory]
        [InlineData(null, null, null, null, "lists/123/comments")]
        [InlineData(null, null, 10, null, "lists/123/comments?page=10")]
        [InlineData(null, null, null, 20, "lists/123/comments?limit=20")]
        [InlineData(null, null, 10, 20, "lists/123/comments?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, "lists/123/comments")]
        [InlineData(null, TraktExtendedInfo.None, 10, null, "lists/123/comments?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, "lists/123/comments?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, "lists/123/comments?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, "lists/123/comments?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, "lists/123/comments?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, "lists/123/comments?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, "lists/123/comments?extended=full&page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, "lists/123/comments")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 10, null, "lists/123/comments?page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20, "lists/123/comments?limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 10, 20, "lists/123/comments?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, "lists/123/comments")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 10, null, "lists/123/comments?page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20, "lists/123/comments?limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 10, 20, "lists/123/comments?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, "lists/123/comments?extended=full")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 10, null, "lists/123/comments?extended=full&page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20, "lists/123/comments?extended=full&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 10, 20, "lists/123/comments?extended=full&page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, null, "lists/123/comments/newest")]
        [InlineData(TraktCommentSortOrder.Newest, null, 10, null, "lists/123/comments/newest?page=10")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, 20, "lists/123/comments/newest?limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, null, 10, 20, "lists/123/comments/newest?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, null, null, "lists/123/comments/newest")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, 10, null, "lists/123/comments/newest?page=10")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, null, 20, "lists/123/comments/newest?limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, 10, 20, "lists/123/comments/newest?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.Full, null, null, "lists/123/comments/newest?extended=full")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.Full, 10, null, "lists/123/comments/newest?extended=full&page=10")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.Full, null, 20, "lists/123/comments/newest?extended=full&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.Full, 10, 20, "lists/123/comments/newest?extended=full&page=10&limit=20")]
        public void TestListCommentsGetRequestHasValidURIPath(TraktCommentSortOrder? sort, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var listCommentsGetRequest = new ListCommentsGetRequest
            {
                Id = "123",
                Sort = sort,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            listCommentsGetRequest.BuildUri();
            listCommentsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestListCommentsGetRequestHasValidOAuthRequirement()
        {
            var listCommentsGetRequest = new ListCommentsGetRequest { Id = default! };
            listCommentsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Optional);
        }

        [Fact]
        public void TestListCommentsGetRequestIsGetRequest()
        {
            var listCommentsGetRequest = new ListCommentsGetRequest { Id = default! };
            listCommentsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestListCommentsGetRequestHasCorrectRequestObjectType()
        {
            var listCommentsGetRequest = new ListCommentsGetRequest { Id = default! };
            listCommentsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestListCommentsGetRequestValidate()
        {
            var listCommentsGetRequest = new ListCommentsGetRequest { Id = string.Empty };
            Action act = () => listCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listCommentsGetRequest = new ListCommentsGetRequest { Id = "  " };
            act = () => listCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listCommentsGetRequest = new ListCommentsGetRequest { Id = "id with spaces" };
            act = () => listCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
