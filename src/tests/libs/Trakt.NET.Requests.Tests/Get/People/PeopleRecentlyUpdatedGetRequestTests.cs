#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.People
{
    public sealed class PeopleRecentlyUpdatedGetRequestTests
    {
        private const string URIPath = "people/updates";

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
        public void TestPeopleRecentlyUpdatedGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var peopleRecentlyUpdatedGetRequest = new PeopleRecentlyUpdatedGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            peopleRecentlyUpdatedGetRequest.BuildUri();
            peopleRecentlyUpdatedGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPeopleRecentlyUpdatedGetRequestHasValidOAuthRequirement()
        {
            var peopleRecentlyUpdatedGetRequest = new PeopleRecentlyUpdatedGetRequest();
            peopleRecentlyUpdatedGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPeopleRecentlyUpdatedGetRequestIsGetRequest()
        {
            var peopleRecentlyUpdatedGetRequest = new PeopleRecentlyUpdatedGetRequest();
            peopleRecentlyUpdatedGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestPeopleRecentlyUpdatedGetRequestHasCorrectRequestObjectType()
        {
            var peopleRecentlyUpdatedGetRequest = new PeopleRecentlyUpdatedGetRequest();
            peopleRecentlyUpdatedGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }
    }
}
