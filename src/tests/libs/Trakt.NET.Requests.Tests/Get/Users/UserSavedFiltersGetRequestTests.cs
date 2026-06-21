#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSavedFiltersGetRequestTests
    {
        private const string URIPath = "users/saved_filters";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktNET.TraktFilterSection.Unspecified, null, null, URIPath)]
        [InlineData(TraktNET.TraktFilterSection.Unspecified, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktNET.TraktFilterSection.Unspecified, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktNET.TraktFilterSection.Unspecified, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktNET.TraktFilterSection.Movies, null, null, $"{URIPath}?section=movies")]
        [InlineData(TraktNET.TraktFilterSection.Movies, 10, null, $"{URIPath}?section=movies&page=10")]
        [InlineData(TraktNET.TraktFilterSection.Movies, null, 20, $"{URIPath}?section=movies&limit=20")]
        [InlineData(TraktNET.TraktFilterSection.Movies, 10, 20, $"{URIPath}?section=movies&page=10&limit=20")]
        public void TestUserSavedFiltersGetRequestHasValidURIPath(TraktNET.TraktFilterSection? section, int? page, int? limit, string expectedURIPath)
        {
            var userSavedFiltersGetRequest = new UserSavedFiltersGetRequest
            {
                Section = section,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userSavedFiltersGetRequest.BuildUri();
            userSavedFiltersGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSavedFiltersGetRequestHasValidOAuthRequirement()
        {
            var userSavedFiltersGetRequest = new UserSavedFiltersGetRequest();
            userSavedFiltersGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSavedFiltersGetRequestIsGetRequest()
        {
            var userSavedFiltersGetRequest = new UserSavedFiltersGetRequest();
            userSavedFiltersGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSavedFiltersGetRequestHasCorrectRequestObjectType()
        {
            var userSavedFiltersGetRequest = new UserSavedFiltersGetRequest();
            userSavedFiltersGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
