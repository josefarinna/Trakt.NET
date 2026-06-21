#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserCollectionShowsGetRequestTests
    {
        private const string URIPath = "users/123/collection/shows";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserCollectionShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userCollectionShowsGetRequest = new UserCollectionShowsGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            userCollectionShowsGetRequest.BuildUri();
            userCollectionShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserCollectionShowsGetRequestHasValidOAuthRequirement()
        {
            var userCollectionShowsGetRequest = new UserCollectionShowsGetRequest { Id = default! };
            userCollectionShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserCollectionShowsGetRequestIsGetRequest()
        {
            var userCollectionShowsGetRequest = new UserCollectionShowsGetRequest { Id = default! };
            userCollectionShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserCollectionShowsGetRequestHasCorrectRequestObjectType()
        {
            var userCollectionShowsGetRequest = new UserCollectionShowsGetRequest { Id = default! };
            userCollectionShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserCollectionShowsGetRequestValidate()
        {
            var userCollectionShowsGetRequest = new UserCollectionShowsGetRequest { Id = string.Empty };
            Action act = () => userCollectionShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userCollectionShowsGetRequest = new UserCollectionShowsGetRequest { Id = "  " };
            act = () => userCollectionShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userCollectionShowsGetRequest = new UserCollectionShowsGetRequest { Id = "id with spaces" };
            act = () => userCollectionShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
