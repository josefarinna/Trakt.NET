#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchedMoviesGetRequestTests
    {
        private const string URIPath = "users/123/watched/movies";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserWatchedMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userWatchedMoviesGetRequest = new UserWatchedMoviesGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
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
