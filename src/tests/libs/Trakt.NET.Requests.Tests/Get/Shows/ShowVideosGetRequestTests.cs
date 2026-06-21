#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowVideosGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/videos";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestShowVideosGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var showVideosGetRequest = new ShowVideosGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo
            };

            showVideosGetRequest.BuildUri();
            showVideosGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowVideosGetRequestHasValidOAuthRequirement()
        {
            var showVideosGetRequest = new ShowVideosGetRequest { Id = default! };
            showVideosGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowVideosGetRequestIsGetRequest()
        {
            var showVideosGetRequest = new ShowVideosGetRequest { Id = default! };
            showVideosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowVideosGetRequestHasCorrectRequestObjectType()
        {
            var showVideosGetRequest = new ShowVideosGetRequest { Id = default! };
            showVideosGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowVideosGetRequestValidate()
        {
            var showVideosGetRequest = new ShowVideosGetRequest { Id = string.Empty };
            Action act = () => showVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showVideosGetRequest = new ShowVideosGetRequest { Id = "  " };
            act = () => showVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showVideosGetRequest = new ShowVideosGetRequest { Id = "id with spaces" };
            act = () => showVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
