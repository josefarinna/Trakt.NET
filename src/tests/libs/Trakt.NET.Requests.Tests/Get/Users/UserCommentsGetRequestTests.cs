#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserCommentsGetRequestTests
    {
        private const string URIPath = "users/123/comments";

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
        [InlineData(TraktIncludeReplies.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktIncludeReplies.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktIncludeReplies.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktIncludeReplies.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktIncludeReplies.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktIncludeReplies.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktIncludeReplies.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktIncludeReplies.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktIncludeReplies.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktIncludeReplies.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktIncludeReplies.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktIncludeReplies.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktIncludeReplies.True, null, null, null, $"{URIPath}?include_replies=true")]
        [InlineData(TraktIncludeReplies.True, null, 10, null, $"{URIPath}?include_replies=true&page=10")]
        [InlineData(TraktIncludeReplies.True, null, null, 20, $"{URIPath}?include_replies=true&limit=20")]
        [InlineData(TraktIncludeReplies.True, null, 10, 20, $"{URIPath}?include_replies=true&page=10&limit=20")]
        [InlineData(TraktIncludeReplies.True, TraktExtendedInfo.None, null, null, $"{URIPath}?include_replies=true")]
        [InlineData(TraktIncludeReplies.True, TraktExtendedInfo.None, 10, null, $"{URIPath}?include_replies=true&page=10")]
        [InlineData(TraktIncludeReplies.True, TraktExtendedInfo.None, null, 20, $"{URIPath}?include_replies=true&limit=20")]
        [InlineData(TraktIncludeReplies.True, TraktExtendedInfo.None, 10, 20, $"{URIPath}?include_replies=true&page=10&limit=20")]
        [InlineData(TraktIncludeReplies.True, TraktExtendedInfo.Full, null, null, $"{URIPath}?include_replies=true&extended=full")]
        [InlineData(TraktIncludeReplies.True, TraktExtendedInfo.Full, 10, null, $"{URIPath}?include_replies=true&extended=full&page=10")]
        [InlineData(TraktIncludeReplies.True, TraktExtendedInfo.Full, null, 20, $"{URIPath}?include_replies=true&extended=full&limit=20")]
        [InlineData(TraktIncludeReplies.True, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?include_replies=true&extended=full&page=10&limit=20")]
        public void TestUserCommentsGetRequestHasValidURIPath(TraktIncludeReplies? includeReplies, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userCommentsGetRequest = new UserCommentsGetRequest
            {
                Id = "123",
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userCommentsGetRequest.BuildUri();
            userCommentsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserCommentsGetRequestHasValidOAuthRequirement()
        {
            var userCommentsGetRequest = new UserCommentsGetRequest { Id = default! };
            userCommentsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserCommentsGetRequestIsGetRequest()
        {
            var userCommentsGetRequest = new UserCommentsGetRequest { Id = default! };
            userCommentsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserCommentsGetRequestHasCorrectRequestObjectType()
        {
            var userCommentsGetRequest = new UserCommentsGetRequest { Id = default! };
            userCommentsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserCommentsGetRequestValidate()
        {
            var userCommentsGetRequest = new UserCommentsGetRequest { Id = string.Empty };
            Action act = () => userCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userCommentsGetRequest = new UserCommentsGetRequest { Id = "  " };
            act = () => userCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userCommentsGetRequest = new UserCommentsGetRequest { Id = "id with spaces" };
            act = () => userCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
