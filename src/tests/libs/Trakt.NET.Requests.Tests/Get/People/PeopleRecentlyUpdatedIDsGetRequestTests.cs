#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.People
{
    public sealed class PeopleRecentlyUpdatedIDsGetRequestTests
    {
        private const string URIPath = "people/updates/id";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestPeopleRecentlyUpdatedIDsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var peopleRecentlyUpdatedIDsGetRequest = new PeopleRecentlyUpdatedIDsGetRequest
            {
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            peopleRecentlyUpdatedIDsGetRequest.BuildUri();
            peopleRecentlyUpdatedIDsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPeopleRecentlyUpdatedIDsGetRequestHasValidOAuthRequirement()
        {
            var peopleRecentlyUpdatedIDsGetRequest = new PeopleRecentlyUpdatedIDsGetRequest();
            peopleRecentlyUpdatedIDsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPeopleRecentlyUpdatedIDsGetRequestIsGetRequest()
        {
            var peopleRecentlyUpdatedIDsGetRequest = new PeopleRecentlyUpdatedIDsGetRequest();
            peopleRecentlyUpdatedIDsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestPeopleRecentlyUpdatedIDsGetRequestHasCorrectRequestObjectType()
        {
            var peopleRecentlyUpdatedIDsGetRequest = new PeopleRecentlyUpdatedIDsGetRequest();
            peopleRecentlyUpdatedIDsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }
    }
}
