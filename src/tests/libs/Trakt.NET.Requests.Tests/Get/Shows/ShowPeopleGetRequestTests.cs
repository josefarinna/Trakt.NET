#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowPeopleGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/people";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestShowPeopleGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var showPeopleGetRequest = new ShowPeopleGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo
            };

            showPeopleGetRequest.BuildUri();
            showPeopleGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowPeopleGetRequestHasValidOAuthRequirement()
        {
            var showPeopleGetRequest = new ShowPeopleGetRequest { Id = ShowID };
            showPeopleGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowPeopleGetRequestIsGetRequest()
        {
            var showPeopleGetRequest = new ShowPeopleGetRequest { Id = ShowID };
            showPeopleGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowPeopleGetRequestHasCorrectRequestObjectType()
        {
            var showPeopleGetRequest = new ShowPeopleGetRequest { Id = ShowID };
            showPeopleGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowPeopleGetRequestValidate()
        {
            var showPeopleGetRequest = new ShowPeopleGetRequest { Id = string.Empty };

            Action act = () => showPeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showPeopleGetRequest = new ShowPeopleGetRequest { Id = "  " };

            act = () => showPeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showPeopleGetRequest = new ShowPeopleGetRequest { Id = "id with spaces" };

            act = () => showPeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
