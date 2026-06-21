#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserLikesGetRequestTests
    {
        private const string URIPath = "users/123/likes";

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
        [InlineData(TraktUserLikeType.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktUserLikeType.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktUserLikeType.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktUserLikeType.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktUserLikeType.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktUserLikeType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktUserLikeType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktUserLikeType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktUserLikeType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktUserLikeType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktUserLikeType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktUserLikeType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktUserLikeType.Comment, null, null, null, $"{URIPath}/comments")]
        [InlineData(TraktUserLikeType.Comment, null, 10, null, $"{URIPath}/comments?page=10")]
        [InlineData(TraktUserLikeType.Comment, null, null, 20, $"{URIPath}/comments?limit=20")]
        [InlineData(TraktUserLikeType.Comment, null, 10, 20, $"{URIPath}/comments?page=10&limit=20")]
        [InlineData(TraktUserLikeType.Comment, TraktExtendedInfo.None, null, null, $"{URIPath}/comments")]
        [InlineData(TraktUserLikeType.Comment, TraktExtendedInfo.None, 10, null, $"{URIPath}/comments?page=10")]
        [InlineData(TraktUserLikeType.Comment, TraktExtendedInfo.None, null, 20, $"{URIPath}/comments?limit=20")]
        [InlineData(TraktUserLikeType.Comment, TraktExtendedInfo.None, 10, 20, $"{URIPath}/comments?page=10&limit=20")]
        [InlineData(TraktUserLikeType.Comment, TraktExtendedInfo.Full, null, null, $"{URIPath}/comments?extended=full")]
        [InlineData(TraktUserLikeType.Comment, TraktExtendedInfo.Full, 10, null, $"{URIPath}/comments?extended=full&page=10")]
        [InlineData(TraktUserLikeType.Comment, TraktExtendedInfo.Full, null, 20, $"{URIPath}/comments?extended=full&limit=20")]
        [InlineData(TraktUserLikeType.Comment, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/comments?extended=full&page=10&limit=20")]
        public void TestUserLikesGetRequestHasValidURIPath(TraktUserLikeType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userLikesGetRequest = new UserLikesGetRequest
            {
                Id = "123",
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userLikesGetRequest.BuildUri();
            userLikesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserLikesGetRequestHasValidOAuthRequirement()
        {
            var userLikesGetRequest = new UserLikesGetRequest { Id = default! };
            userLikesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserLikesGetRequestIsGetRequest()
        {
            var userLikesGetRequest = new UserLikesGetRequest { Id = default! };
            userLikesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserLikesGetRequestHasCorrectRequestObjectType()
        {
            var userLikesGetRequest = new UserLikesGetRequest { Id = default! };
            userLikesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserLikesGetRequestValidate()
        {
            var userLikesGetRequest = new UserLikesGetRequest { Id = string.Empty };
            Action act = () => userLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userLikesGetRequest = new UserLikesGetRequest { Id = "  " };
            act = () => userLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userLikesGetRequest = new UserLikesGetRequest { Id = "id with spaces" };
            act = () => userLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
