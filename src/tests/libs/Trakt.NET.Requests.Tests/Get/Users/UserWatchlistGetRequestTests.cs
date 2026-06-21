#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchlistGetRequestTests
    {
        private const string URIPath = "users/123/watchlist";

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
        [InlineData(TraktSortHow.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktSortHow.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktSortHow.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSortHow.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, null, null, null, $"{URIPath}/asc")]
        [InlineData(TraktSortHow.Ascending, null, 10, null, $"{URIPath}/asc?page=10")]
        [InlineData(TraktSortHow.Ascending, null, null, 20, $"{URIPath}/asc?limit=20")]
        [InlineData(TraktSortHow.Ascending, null, 10, 20, $"{URIPath}/asc?page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, null, null, $"{URIPath}/asc")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, 10, null, $"{URIPath}/asc?page=10")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, null, 20, $"{URIPath}/asc?limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, 10, 20, $"{URIPath}/asc?page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, null, null, $"{URIPath}/asc?extended=full")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, null, $"{URIPath}/asc?extended=full&page=10")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, null, 20, $"{URIPath}/asc?extended=full&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/asc?extended=full&page=10&limit=20")]
        public void TestUserWatchlistGetRequestHasValidURIPath(TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userWatchlistGetRequest = new UserWatchlistGetRequest
            {
                Id = "123",
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userWatchlistGetRequest.BuildUri();
            userWatchlistGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchlistGetRequestHasValidOAuthRequirement()
        {
            var userWatchlistGetRequest = new UserWatchlistGetRequest { Id = default! };
            userWatchlistGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchlistGetRequestIsGetRequest()
        {
            var userWatchlistGetRequest = new UserWatchlistGetRequest { Id = default! };
            userWatchlistGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchlistGetRequestHasCorrectRequestObjectType()
        {
            var userWatchlistGetRequest = new UserWatchlistGetRequest { Id = default! };
            userWatchlistGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchlistGetRequestValidate()
        {
            var userWatchlistGetRequest = new UserWatchlistGetRequest { Id = string.Empty };
            Action act = () => userWatchlistGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchlistGetRequest = new UserWatchlistGetRequest { Id = "  " };
            act = () => userWatchlistGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchlistGetRequest = new UserWatchlistGetRequest { Id = "id with spaces" };
            act = () => userWatchlistGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
