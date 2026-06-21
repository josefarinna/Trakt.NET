#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserRatingsGetRequestTests
    {
        private const string URIPath = "users/123/ratings";

        [Theory]
        [InlineData(null, null, null, null, $"{URIPath}/123")]
        [InlineData(null, null, 10, null, $"{URIPath}/123?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}/123?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}/123?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{URIPath}/123")]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}/123?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}/123?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}/123?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}/123?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}/123?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}/123?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/123?extended=full&page=10&limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, null, null, null, $"{URIPath}/123")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, null, 10, null, $"{URIPath}/123?page=10")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, null, null, 20, $"{URIPath}/123?limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, null, 10, 20, $"{URIPath}/123?page=10&limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, TraktExtendedInfo.None, null, null, $"{URIPath}/123")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}/123?page=10")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}/123?limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}/123?page=10&limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}/123?extended=full")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}/123?extended=full&page=10")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}/123?extended=full&limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/123?extended=full&page=10&limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, null, null, null, $"{URIPath}/movies/123")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, null, 10, null, $"{URIPath}/movies/123?page=10")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, null, null, 20, $"{URIPath}/movies/123?limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, null, 10, 20, $"{URIPath}/movies/123?page=10&limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, TraktExtendedInfo.None, null, null, $"{URIPath}/movies/123")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, TraktExtendedInfo.None, 10, null, $"{URIPath}/movies/123?page=10")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, TraktExtendedInfo.None, null, 20, $"{URIPath}/movies/123?limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, TraktExtendedInfo.None, 10, 20, $"{URIPath}/movies/123?page=10&limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, TraktExtendedInfo.Full, null, null, $"{URIPath}/movies/123?extended=full")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, TraktExtendedInfo.Full, 10, null, $"{URIPath}/movies/123?extended=full&page=10")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, TraktExtendedInfo.Full, null, 20, $"{URIPath}/movies/123?extended=full&limit=20")]
        [InlineData(TraktNET.TraktRatingsItemType.Movie, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/movies/123?extended=full&page=10&limit=20")]
        public void TestUserRatingsGetRequestHasValidURIPath(TraktNET.TraktRatingsItemType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userRatingsGetRequest = new UserRatingsGetRequest
            {
                RatingFilter = "123",
                Id = "123",
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userRatingsGetRequest.BuildUri();
            userRatingsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserRatingsGetRequestHasValidOAuthRequirement()
        {
            var userRatingsGetRequest = new UserRatingsGetRequest { Id = default! };
            userRatingsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserRatingsGetRequestIsGetRequest()
        {
            var userRatingsGetRequest = new UserRatingsGetRequest { Id = default! };
            userRatingsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserRatingsGetRequestHasCorrectRequestObjectType()
        {
            var userRatingsGetRequest = new UserRatingsGetRequest { Id = default! };
            userRatingsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserRatingsGetRequestValidate()
        {
            
            var userRatingsGetRequest = new UserRatingsGetRequest { Id = string.Empty };
            Action act = () => userRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            
            userRatingsGetRequest = new UserRatingsGetRequest { Id = "  " };
            act = () => userRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            
            userRatingsGetRequest = new UserRatingsGetRequest { Id = "id with spaces" };
            act = () => userRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
