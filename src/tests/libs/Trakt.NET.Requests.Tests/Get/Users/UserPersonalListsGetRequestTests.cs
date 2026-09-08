#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPersonalListsGetRequestTests
    {
        private const string URIPath = "users/123/lists";

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
        public void TestUserPersonalListsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userPersonalListsGetRequest = new UserPersonalListsGetRequest
            {
                Id = "123",
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
