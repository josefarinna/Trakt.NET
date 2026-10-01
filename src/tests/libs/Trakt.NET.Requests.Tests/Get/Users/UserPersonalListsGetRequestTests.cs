#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPersonalListsGetRequestTests
    {
        private const string URIPath = "users/123/lists";

        [Theory]
        [InlineData(null, null, null, null, null, URIPath)]
        [InlineData(TraktSortBy.Rank, null, null, null, null, $"{URIPath}?sort_by=rank")]
        [InlineData(null, TraktSortHow.Ascending, null, null, null, $"{URIPath}?sort_how=asc")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, null, null, null, $"{URIPath}?sort_by=rank&sort_how=asc")]
        [InlineData(null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?sort_by=rank&sort_how=asc&extended=full&page=10&limit=20")]
        public void TestUserPersonalListsGetRequestHasValidURIPath(TraktSortBy? sortBy, TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userPersonalListsGetRequest = new UserPersonalListsGetRequest
            {
                Id = "123",
                SortBy = sortBy,
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userPersonalListsGetRequest.BuildUri();
            userPersonalListsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListsGetRequestHasValidOAuthRequirement()
        {
            var userPersonalListsGetRequest = new UserPersonalListsGetRequest { Id = default! };
            userPersonalListsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserPersonalListsGetRequestIsGetRequest()
        {
            var userPersonalListsGetRequest = new UserPersonalListsGetRequest { Id = default! };
            userPersonalListsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserPersonalListsGetRequestHasCorrectRequestObjectType()
        {
            var userPersonalListsGetRequest = new UserPersonalListsGetRequest { Id = default! };
            userPersonalListsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPersonalListsGetRequestValidate()
        {
            var userPersonalListsGetRequest = new UserPersonalListsGetRequest { Id = string.Empty };
            Action act = () => userPersonalListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListsGetRequest = new UserPersonalListsGetRequest { Id = "  " };
            act = () => userPersonalListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListsGetRequest = new UserPersonalListsGetRequest { Id = "id with spaces" };
            act = () => userPersonalListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
