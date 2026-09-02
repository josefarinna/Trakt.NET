#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowRatingsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/ratings";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.All, $"{URIPath}?extended=all")]
        public void TestShowRatingsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedUri)
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo,
            };

            showRatingsGetRequest.BuildUri();
            showRatingsGetRequest.RequestUri.ShouldBe(new Uri(expectedUri, UriKind.Relative));
        }

        [Fact]
        public void TestShowRatingsGetRequestHasValidOAuthRequirement()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = ShowID };
            showRatingsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowRatingsGetRequestIsGetRequest()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = ShowID };
            showRatingsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowRatingsGetRequestHasCorrectRequestObjectType()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = ShowID };
            showRatingsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowRatingsGetRequestValidate()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = string.Empty };
            Action act = () => showRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showRatingsGetRequest = new ShowRatingsGetRequest { Id = "  " };
            act = () => showRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showRatingsGetRequest = new ShowRatingsGetRequest { Id = "id with spaces" };
            act = () => showRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
