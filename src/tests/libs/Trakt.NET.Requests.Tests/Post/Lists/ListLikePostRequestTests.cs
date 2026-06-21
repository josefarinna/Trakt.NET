#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Lists
{
    public sealed class ListLikePostRequestTests
    {
        private const string URIPath = "lists/123/like";

        [Fact]
        public void TestListLikePostRequestHasValidURIPath()
        {
            var listLikePostRequest = new ListLikePostRequest
            {
                Id = "123"
            };

            listLikePostRequest.BuildUri();
            listLikePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestListLikePostRequestHasValidOAuthRequirement()
        {
            var listLikePostRequest = new ListLikePostRequest { Id = default! };
            listLikePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestListLikePostRequestIsPostRequest()
        {
            var listLikePostRequest = new ListLikePostRequest { Id = default! };
            listLikePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestListLikePostRequestHasCorrectRequestObjectType()
        {
            var listLikePostRequest = new ListLikePostRequest { Id = default! };
            listLikePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestListLikePostRequestValidate()
        {
            var listLikePostRequest = new ListLikePostRequest { Id = string.Empty };
            Action act = () => listLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listLikePostRequest = new ListLikePostRequest { Id = "  " };
            act = () => listLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listLikePostRequest = new ListLikePostRequest { Id = "id with spaces" };
            act = () => listLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
