#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchedMinimalShowsGetRequestTests
    {
        private const string URIPath = "users/123/watched/shows";

        [Theory]
        [InlineData(null, null, null, null, null, URIPath)]
        [InlineData(true, null, null, null, null, $"{URIPath}?specials=true")]
        [InlineData(false, null, null, null, null, $"{URIPath}?specials=false")]
        [InlineData(null, true, null, null, null, $"{URIPath}?season_numbers=true")]
        [InlineData(null, false, null, null, null, $"{URIPath}?season_numbers=false")]
        [InlineData(null, null, TraktExtendedInfo.Min, null, null, $"{URIPath}?extended=min")]
        [InlineData(null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(true, true, TraktExtendedInfo.Min, 10, 20, $"{URIPath}?specials=true&season_numbers=true&extended=min&page=10&limit=20")]
        public void TestUserWatchedMinimalShowsGetRequestHasValidURIPath(bool? specials, bool? seasonNumbers, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userWatchedMinimalShowsGetRequest = new UserWatchedMinimalShowsGetRequest
            {
                Id = "123",
                Specials = specials,
                SeasonNumbers = seasonNumbers,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userWatchedMinimalShowsGetRequest.BuildUri();
            userWatchedMinimalShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchedMinimalShowsGetRequestHasValidOAuthRequirement()
        {
            var userWatchedMinimalShowsGetRequest = new UserWatchedMinimalShowsGetRequest { Id = default! };
            userWatchedMinimalShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchedMinimalShowsGetRequestIsGetRequest()
        {
            var userWatchedMinimalShowsGetRequest = new UserWatchedMinimalShowsGetRequest { Id = default! };
            userWatchedMinimalShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchedMinimalShowsGetRequestHasCorrectRequestObjectType()
        {
            var userWatchedMinimalShowsGetRequest = new UserWatchedMinimalShowsGetRequest { Id = default! };
            userWatchedMinimalShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchedMinimalShowsGetRequestValidate()
        {
            var userWatchedMinimalShowsGetRequest = new UserWatchedMinimalShowsGetRequest { Id = string.Empty };
            Action act = () => userWatchedMinimalShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedMinimalShowsGetRequest = new UserWatchedMinimalShowsGetRequest { Id = "  " };
            act = () => userWatchedMinimalShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedMinimalShowsGetRequest = new UserWatchedMinimalShowsGetRequest { Id = "id with spaces" };
            act = () => userWatchedMinimalShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
