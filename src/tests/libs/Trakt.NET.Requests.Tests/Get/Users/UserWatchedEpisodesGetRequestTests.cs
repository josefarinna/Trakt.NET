#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchedEpisodesGetRequestTests
    {
        private const string URIPath = "users/123/watched/episodes";

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
        public void TestUserWatchedEpisodesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userWatchedEpisodesGetRequest = new UserWatchedEpisodesGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userWatchedEpisodesGetRequest.BuildUri();
            userWatchedEpisodesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchedEpisodesGetRequestHasValidOAuthRequirement()
        {
            var userWatchedEpisodesGetRequest = new UserWatchedEpisodesGetRequest { Id = default! };
            userWatchedEpisodesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchedEpisodesGetRequestIsGetRequest()
        {
            var userWatchedEpisodesGetRequest = new UserWatchedEpisodesGetRequest { Id = default! };
            userWatchedEpisodesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchedEpisodesGetRequestHasCorrectRequestObjectType()
        {
            var userWatchedEpisodesGetRequest = new UserWatchedEpisodesGetRequest { Id = default! };
            userWatchedEpisodesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchedEpisodesGetRequestValidate()
        {
            var userWatchedEpisodesGetRequest = new UserWatchedEpisodesGetRequest { Id = string.Empty };
            Action act = () => userWatchedEpisodesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedEpisodesGetRequest = new UserWatchedEpisodesGetRequest { Id = "  " };
            act = () => userWatchedEpisodesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedEpisodesGetRequest = new UserWatchedEpisodesGetRequest { Id = "id with spaces" };
            act = () => userWatchedEpisodesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
