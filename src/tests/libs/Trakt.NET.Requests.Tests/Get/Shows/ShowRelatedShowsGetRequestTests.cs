#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowRelatedShowsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/related";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestShowRelatedShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var showRelatedShowsGetRequest = new ShowRelatedShowsGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            showRelatedShowsGetRequest.BuildUri();
            showRelatedShowsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowRelatedShowsGetRequestHasValidOAuthRequirement()
        {
            var showRelatedShowsGetRequest = new ShowRelatedShowsGetRequest { Id = ShowID };
            showRelatedShowsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowRelatedShowsGetRequestIsGetRequest()
        {
            var showRelatedShowsGetRequest = new ShowRelatedShowsGetRequest { Id = ShowID };
            showRelatedShowsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowRelatedShowsGetRequestHasCorrectRequestObjectType()
        {
            var showRelatedShowsGetRequest = new ShowRelatedShowsGetRequest { Id = ShowID };
            showRelatedShowsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowRelatedShowsGetRequestValidate()
        {
            var showRelatedShowsGetRequest = new ShowRelatedShowsGetRequest { Id = string.Empty };

            Action act = () => showRelatedShowsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showRelatedShowsGetRequest = new ShowRelatedShowsGetRequest { Id = "  " };

            act = () => showRelatedShowsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showRelatedShowsGetRequest = new ShowRelatedShowsGetRequest { Id = "id with spaces" };

            act = () => showRelatedShowsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
