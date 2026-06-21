#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Lists
{
    public sealed class SingleListGetRequestTests
    {
        private const string URIPath = "lists/123";

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
        public void TestSingleListGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var singleListGetRequest = new SingleListGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            singleListGetRequest.BuildUri();
            singleListGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSingleListGetRequestHasValidOAuthRequirement()
        {
            var singleListGetRequest = new SingleListGetRequest { Id = default! };
            singleListGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSingleListGetRequestIsGetRequest()
        {
            var singleListGetRequest = new SingleListGetRequest { Id = default! };
            singleListGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSingleListGetRequestHasCorrectRequestObjectType()
        {
            var singleListGetRequest = new SingleListGetRequest { Id = default! };
            singleListGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestSingleListGetRequestValidate()
        {
            
            var singleListGetRequest = new SingleListGetRequest { Id = string.Empty };
            Action act = () => singleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            
            singleListGetRequest = new SingleListGetRequest { Id = "  " };
            act = () => singleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            
            singleListGetRequest = new SingleListGetRequest { Id = "id with spaces" };
            act = () => singleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
