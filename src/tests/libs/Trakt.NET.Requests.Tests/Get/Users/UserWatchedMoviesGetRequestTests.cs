#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchedMoviesGetRequestTests
    {
        private const string URIPath = "users/123/watched/movies";

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
        public void TestUserWatchedMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userWatchedMoviesGetRequest = new UserWatchedMoviesGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userWatchedMoviesGetRequest.BuildUri();
            userWatchedMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchedMoviesGetRequestHasValidOAuthRequirement()
        {
            var userWatchedMoviesGetRequest = new UserWatchedMoviesGetRequest { Id = default! };
            userWatchedMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchedMoviesGetRequestIsGetRequest()
        {
            var userWatchedMoviesGetRequest = new UserWatchedMoviesGetRequest { Id = default! };
            userWatchedMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchedMoviesGetRequestHasCorrectRequestObjectType()
        {
            var userWatchedMoviesGetRequest = new UserWatchedMoviesGetRequest { Id = default! };
            userWatchedMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchedMoviesGetRequestValidate()
        {
            var userWatchedMoviesGetRequest = new UserWatchedMoviesGetRequest { Id = string.Empty };
            Action act = () => userWatchedMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedMoviesGetRequest = new UserWatchedMoviesGetRequest { Id = "  " };
            act = () => userWatchedMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedMoviesGetRequest = new UserWatchedMoviesGetRequest { Id = "id with spaces" };
            act = () => userWatchedMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
