#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserCollectionMoviesGetRequestTests
    {
        private const string URIPath = "users/123/collection/movies";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserCollectionMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userCollectionMoviesGetRequest = new UserCollectionMoviesGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            userCollectionMoviesGetRequest.BuildUri();
            userCollectionMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserCollectionMoviesGetRequestHasValidOAuthRequirement()
        {
            var userCollectionMoviesGetRequest = new UserCollectionMoviesGetRequest { Id = default! };
            userCollectionMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserCollectionMoviesGetRequestIsGetRequest()
        {
            var userCollectionMoviesGetRequest = new UserCollectionMoviesGetRequest { Id = default! };
            userCollectionMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserCollectionMoviesGetRequestHasCorrectRequestObjectType()
        {
            var userCollectionMoviesGetRequest = new UserCollectionMoviesGetRequest { Id = default! };
            userCollectionMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserCollectionMoviesGetRequestValidate()
        {
            var userCollectionMoviesGetRequest = new UserCollectionMoviesGetRequest { Id = string.Empty };
            Action act = () => userCollectionMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userCollectionMoviesGetRequest = new UserCollectionMoviesGetRequest { Id = "  " };
            act = () => userCollectionMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userCollectionMoviesGetRequest = new UserCollectionMoviesGetRequest { Id = "id with spaces" };
            act = () => userCollectionMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
