#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPersonalListItemsGetRequestTests
    {
        private const string URIPath = "users/123/lists/123/items";

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
        [InlineData(TraktListItemType.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktListItemType.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktListItemType.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktListItemType.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListItemType.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktListItemType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktListItemType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktListItemType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListItemType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktListItemType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktListItemType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktListItemType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktListItemType.Movie, null, null, null, $"{URIPath}/movie")]
        [InlineData(TraktListItemType.Movie, null, 10, null, $"{URIPath}/movie?page=10")]
        [InlineData(TraktListItemType.Movie, null, null, 20, $"{URIPath}/movie?limit=20")]
        [InlineData(TraktListItemType.Movie, null, 10, 20, $"{URIPath}/movie?page=10&limit=20")]
        [InlineData(TraktListItemType.Movie, TraktExtendedInfo.None, null, null, $"{URIPath}/movie")]
        [InlineData(TraktListItemType.Movie, TraktExtendedInfo.None, 10, null, $"{URIPath}/movie?page=10")]
        [InlineData(TraktListItemType.Movie, TraktExtendedInfo.None, null, 20, $"{URIPath}/movie?limit=20")]
        [InlineData(TraktListItemType.Movie, TraktExtendedInfo.None, 10, 20, $"{URIPath}/movie?page=10&limit=20")]
        [InlineData(TraktListItemType.Movie, TraktExtendedInfo.Full, null, null, $"{URIPath}/movie?extended=full")]
        [InlineData(TraktListItemType.Movie, TraktExtendedInfo.Full, 10, null, $"{URIPath}/movie?extended=full&page=10")]
        [InlineData(TraktListItemType.Movie, TraktExtendedInfo.Full, null, 20, $"{URIPath}/movie?extended=full&limit=20")]
        [InlineData(TraktListItemType.Movie, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/movie?extended=full&page=10&limit=20")]
        public void TestUserPersonalListItemsGetRequestHasValidURIPath(TraktListItemType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest
            {
                Id = "123",
                ListId = "123",
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userPersonalListItemsGetRequest.BuildUri();
            userPersonalListItemsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListItemsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "batman" };
            var request = new UserPersonalListItemsGetRequest
            {
                Id = "123",
                ListId = "123",
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?query=batman", UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListItemsGetRequestHasValidOAuthRequirement()
        {
            var userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = default!, ListId = default! };
            userPersonalListItemsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserPersonalListItemsGetRequestIsGetRequest()
        {
            var userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = default!, ListId = default! };
            userPersonalListItemsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserPersonalListItemsGetRequestHasCorrectRequestObjectType()
        {
            var userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = default!, ListId = default! };
            userPersonalListItemsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPersonalListItemsGetRequestValidate()
        {
            var userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = string.Empty, ListId = default! };
            Action act = () => userPersonalListItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = "  ", ListId = default! };
            act = () => userPersonalListItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = "id with spaces", ListId = default! };
            act = () => userPersonalListItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = "id", ListId = string.Empty };
            act = () => userPersonalListItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = "id", ListId = "  " };
            act = () => userPersonalListItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsGetRequest = new UserPersonalListItemsGetRequest { Id = "id", ListId = "id with spaces" };
            act = () => userPersonalListItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
