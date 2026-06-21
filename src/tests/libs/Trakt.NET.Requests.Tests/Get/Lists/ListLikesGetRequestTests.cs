#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Lists
{
    public sealed class ListLikesGetRequestTests
    {
        private const string URIPath = "lists/123/likes";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestListLikesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var listLikesGetRequest = new ListLikesGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            listLikesGetRequest.BuildUri();
            listLikesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestListLikesGetRequestHasValidOAuthRequirement()
        {
            var listLikesGetRequest = new ListLikesGetRequest { Id = default! };
            listLikesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestListLikesGetRequestIsGetRequest()
        {
            var listLikesGetRequest = new ListLikesGetRequest { Id = default! };
            listLikesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestListLikesGetRequestHasCorrectRequestObjectType()
        {
            var listLikesGetRequest = new ListLikesGetRequest { Id = default! };
            listLikesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestListLikesGetRequestValidate()
        {
            var listLikesGetRequest = new ListLikesGetRequest { Id = string.Empty };
            Action act = () => listLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listLikesGetRequest = new ListLikesGetRequest { Id = "  " };
            act = () => listLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listLikesGetRequest = new ListLikesGetRequest { Id = "id with spaces" };
            act = () => listLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
