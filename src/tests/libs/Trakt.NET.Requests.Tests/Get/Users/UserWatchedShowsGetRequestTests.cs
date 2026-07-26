#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchedShowsGetRequestTests
    {
        private const string URIPath = "users/123/watched/shows";

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
        public void TestUserWatchedShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userWatchedShowsGetRequest.BuildUri();
            userWatchedShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchedShowsGetRequestHasValidOAuthRequirement()
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = default! };
            userWatchedShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchedShowsGetRequestIsGetRequest()
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = default! };
            userWatchedShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchedShowsGetRequestHasCorrectRequestObjectType()
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = default! };
            userWatchedShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchedShowsGetRequestValidate()
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = string.Empty };
            Action act = () => userWatchedShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = "  " };
            act = () => userWatchedShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = "id with spaces" };
            act = () => userWatchedShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
