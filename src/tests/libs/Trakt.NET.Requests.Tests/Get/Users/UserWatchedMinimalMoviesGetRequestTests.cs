#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchedMinimalMoviesGetRequestTests
    {
        private const string URIPath = "users/123/watched/movies";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Min, null, null, $"{URIPath}?extended=min")]
        [InlineData(TraktExtendedInfo.Min, 10, null, $"{URIPath}?extended=min&page=10")]
        [InlineData(TraktExtendedInfo.Min, null, 20, $"{URIPath}?extended=min&limit=20")]
        [InlineData(TraktExtendedInfo.Min, 10, 20, $"{URIPath}?extended=min&page=10&limit=20")]
        public void TestUserWatchedMinimalMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userWatchedMinimalMoviesGetRequest = new UserWatchedMinimalMoviesGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userWatchedMinimalMoviesGetRequest.BuildUri();
            userWatchedMinimalMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchedMinimalMoviesGetRequestHasValidOAuthRequirement()
        {
            var userWatchedMinimalMoviesGetRequest = new UserWatchedMinimalMoviesGetRequest { Id = default! };
            userWatchedMinimalMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchedMinimalMoviesGetRequestIsGetRequest()
        {
            var userWatchedMinimalMoviesGetRequest = new UserWatchedMinimalMoviesGetRequest { Id = default! };
            userWatchedMinimalMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchedMinimalMoviesGetRequestHasCorrectRequestObjectType()
        {
            var userWatchedMinimalMoviesGetRequest = new UserWatchedMinimalMoviesGetRequest { Id = default! };
            userWatchedMinimalMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchedMinimalMoviesGetRequestValidate()
        {
            var userWatchedMinimalMoviesGetRequest = new UserWatchedMinimalMoviesGetRequest { Id = string.Empty };
            Action act = () => userWatchedMinimalMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedMinimalMoviesGetRequest = new UserWatchedMinimalMoviesGetRequest { Id = "  " };
            act = () => userWatchedMinimalMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedMinimalMoviesGetRequest = new UserWatchedMinimalMoviesGetRequest { Id = "id with spaces" };
            act = () => userWatchedMinimalMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
