#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowWatchnowGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string Country = "us";
        private const string URIPath = $"shows/{ShowID}/watchnow/{Country}";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(true, null, $"{URIPath}?links=true")]
        [InlineData(false, null, $"{URIPath}?links=false")]
        [InlineData(null, TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        [InlineData(true, TraktExtendedInfo.Full, $"{URIPath}?links=true&extended=full")]
        public void TestShowWatchnowGetRequestHasValidURIPath(bool? links, TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var request = new ShowWatchnowGetRequest
            {
                Id = ShowID,
                Country = Country,
                Links = links,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowWatchnowGetRequestHasValidOAuthRequirement()
        {
            var request = new ShowWatchnowGetRequest { Id = ShowID, Country = Country };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowWatchnowGetRequestIsGetRequest()
        {
            var request = new ShowWatchnowGetRequest { Id = ShowID, Country = Country };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowWatchnowGetRequestHasCorrectRequestObjectType()
        {
            var request = new ShowWatchnowGetRequest { Id = ShowID, Country = Country };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowWatchnowGetRequestValidate()
        {
            var request = new ShowWatchnowGetRequest { Id = string.Empty, Country = Country };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowWatchnowGetRequest { Id = "  ", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowWatchnowGetRequest { Id = "id with spaces", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowWatchnowGetRequest { Id = ShowID, Country = string.Empty };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowWatchnowGetRequest { Id = ShowID, Country = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowWatchnowGetRequest { Id = ShowID, Country = "country with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
