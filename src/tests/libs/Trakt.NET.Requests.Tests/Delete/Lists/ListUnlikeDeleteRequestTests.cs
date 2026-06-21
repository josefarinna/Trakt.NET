#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Lists
{
    public sealed class ListUnlikeDeleteRequestTests
    {
        private const string URIPath = "lists/123/like";

        [Fact]
        public void TestListUnlikeDeleteRequestHasValidURIPath()
        {
            var listUnlikeDeleteRequest = new ListUnlikeDeleteRequest
            {
                Id = "123"
            };

            listUnlikeDeleteRequest.BuildUri();
            listUnlikeDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestListUnlikeDeleteRequestHasValidOAuthRequirement()
        {
            var listUnlikeDeleteRequest = new ListUnlikeDeleteRequest { Id = default! };
            listUnlikeDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestListUnlikeDeleteRequestIsDeleteRequest()
        {
            var listUnlikeDeleteRequest = new ListUnlikeDeleteRequest { Id = default! };
            listUnlikeDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestListUnlikeDeleteRequestHasCorrectRequestObjectType()
        {
            var listUnlikeDeleteRequest = new ListUnlikeDeleteRequest { Id = default! };
            listUnlikeDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestListUnlikeDeleteRequestValidate()
        {
            var listUnlikeDeleteRequest = new ListUnlikeDeleteRequest { Id = string.Empty };
            Action act = () => listUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listUnlikeDeleteRequest = new ListUnlikeDeleteRequest { Id = "  " };
            act = () => listUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listUnlikeDeleteRequest = new ListUnlikeDeleteRequest { Id = "id with spaces" };
            act = () => listUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
