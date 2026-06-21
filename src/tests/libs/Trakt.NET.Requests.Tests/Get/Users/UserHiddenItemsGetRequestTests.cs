#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserHiddenItemsGetRequestTests
    {
        private const string URIPath = "users/hidden/calendar";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktHiddenItemType.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktHiddenItemType.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktHiddenItemType.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktHiddenItemType.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktHiddenItemType.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktHiddenItemType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktHiddenItemType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktHiddenItemType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktHiddenItemType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktHiddenItemType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktHiddenItemType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktHiddenItemType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktHiddenItemType.Movie, null, null, null, $"{URIPath}?type=movie")]
        [InlineData(TraktHiddenItemType.Movie, null, 10, null, $"{URIPath}?type=movie&page=10")]
        [InlineData(TraktHiddenItemType.Movie, null, null, 20, $"{URIPath}?type=movie&limit=20")]
        [InlineData(TraktHiddenItemType.Movie, null, 10, 20, $"{URIPath}?type=movie&page=10&limit=20")]
        [InlineData(TraktHiddenItemType.Movie, TraktExtendedInfo.None, null, null, $"{URIPath}?type=movie")]
        [InlineData(TraktHiddenItemType.Movie, TraktExtendedInfo.None, 10, null, $"{URIPath}?type=movie&page=10")]
        [InlineData(TraktHiddenItemType.Movie, TraktExtendedInfo.None, null, 20, $"{URIPath}?type=movie&limit=20")]
        [InlineData(TraktHiddenItemType.Movie, TraktExtendedInfo.None, 10, 20, $"{URIPath}?type=movie&page=10&limit=20")]
        [InlineData(TraktHiddenItemType.Movie, TraktExtendedInfo.Full, null, null, $"{URIPath}?type=movie&extended=full")]
        [InlineData(TraktHiddenItemType.Movie, TraktExtendedInfo.Full, 10, null, $"{URIPath}?type=movie&extended=full&page=10")]
        [InlineData(TraktHiddenItemType.Movie, TraktExtendedInfo.Full, null, 20, $"{URIPath}?type=movie&extended=full&limit=20")]
        [InlineData(TraktHiddenItemType.Movie, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?type=movie&extended=full&page=10&limit=20")]
        public void TestUserHiddenItemsGetRequestHasValidURIPath(TraktHiddenItemType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userHiddenItemsGetRequest = new UserHiddenItemsGetRequest
            {
                Section = (TraktNET.TraktHiddenItemsSection)1,
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userHiddenItemsGetRequest.BuildUri();
            userHiddenItemsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserHiddenItemsGetRequestHasValidOAuthRequirement()
        {
            var userHiddenItemsGetRequest = new UserHiddenItemsGetRequest();
            userHiddenItemsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserHiddenItemsGetRequestIsGetRequest()
        {
            var userHiddenItemsGetRequest = new UserHiddenItemsGetRequest();
            userHiddenItemsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserHiddenItemsGetRequestHasCorrectRequestObjectType()
        {
            var userHiddenItemsGetRequest = new UserHiddenItemsGetRequest();
            userHiddenItemsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserHiddenItemsGetRequestValidate()
        {
            var userHiddenItemsGetRequest = new UserHiddenItemsGetRequest();
            Action act = () => userHiddenItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
