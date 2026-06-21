#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestShowGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var showGetRequest = new ShowGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo
            };

            showGetRequest.BuildUri();
            showGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowGetRequestHasValidOAuthRequirement()
        {
            var showGetRequest = new ShowGetRequest { Id = ShowID };
            showGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowGetRequestIsGetRequest()
        {
            var showGetRequest = new ShowGetRequest { Id = ShowID };
            showGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowGetRequestHasCorrectRequestObjectType()
        {
            var showGetRequest = new ShowGetRequest { Id = ShowID };
            showGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowGetRequestValidate()
        {
            var showGetRequest = new ShowGetRequest { Id = string.Empty };
            Action act = () => showGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showGetRequest = new ShowGetRequest { Id = "  " };
            act = () => showGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showGetRequest = new ShowGetRequest { Id = "id with spaces" };
            act = () => showGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
