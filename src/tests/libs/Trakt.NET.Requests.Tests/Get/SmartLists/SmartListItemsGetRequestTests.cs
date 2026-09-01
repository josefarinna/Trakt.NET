#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.SmartLists
{
    public sealed class SmartListItemsGetRequestTests
    {
        private const string URIPath = "smart-lists/123/items";

        [Theory]
        [InlineData(null, null, null, null, $"{URIPath}")]
        [InlineData("us", null, null, null, $"{URIPath}?watchnow=us")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{URIPath}")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData("us", TraktExtendedInfo.Full, 10, 20, $"{URIPath}?watchnow=us&extended=full&page=10&limit=20")]
        public void TestSmartListItemsGetRequestHasValidURIPath(string? watchnow,
            TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new SmartListItemsGetRequest
            {
                ListId = "123",
                Watchnow = watchnow,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var request = new SmartListItemsGetRequest
            {
                ListId = "123",
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasValidOAuthRequirement()
        {
            var request = new SmartListItemsGetRequest { ListId = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestSmartListItemsGetRequestIsGetRequest()
        {
            var request = new SmartListItemsGetRequest { ListId = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasCorrectRequestObjectType()
        {
            var request = new SmartListItemsGetRequest { ListId = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestSmartListItemsGetRequestValidate()
        {
            var request = new SmartListItemsGetRequest { ListId = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id" };
            act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
