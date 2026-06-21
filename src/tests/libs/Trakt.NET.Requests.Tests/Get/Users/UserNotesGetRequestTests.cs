#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserNotesGetRequestTests
    {
        private const string URIPath = "users/123/notes";

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
        [InlineData(TraktNotesObjectType.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktNotesObjectType.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktNotesObjectType.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktNotesObjectType.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktNotesObjectType.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktNotesObjectType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktNotesObjectType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktNotesObjectType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktNotesObjectType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktNotesObjectType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktNotesObjectType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktNotesObjectType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktNotesObjectType.All, null, null, null, $"{URIPath}/all")]
        [InlineData(TraktNotesObjectType.All, null, 10, null, $"{URIPath}/all?page=10")]
        [InlineData(TraktNotesObjectType.All, null, null, 20, $"{URIPath}/all?limit=20")]
        [InlineData(TraktNotesObjectType.All, null, 10, 20, $"{URIPath}/all?page=10&limit=20")]
        [InlineData(TraktNotesObjectType.All, TraktExtendedInfo.None, null, null, $"{URIPath}/all")]
        [InlineData(TraktNotesObjectType.All, TraktExtendedInfo.None, 10, null, $"{URIPath}/all?page=10")]
        [InlineData(TraktNotesObjectType.All, TraktExtendedInfo.None, null, 20, $"{URIPath}/all?limit=20")]
        [InlineData(TraktNotesObjectType.All, TraktExtendedInfo.None, 10, 20, $"{URIPath}/all?page=10&limit=20")]
        [InlineData(TraktNotesObjectType.All, TraktExtendedInfo.Full, null, null, $"{URIPath}/all?extended=full")]
        [InlineData(TraktNotesObjectType.All, TraktExtendedInfo.Full, 10, null, $"{URIPath}/all?extended=full&page=10")]
        [InlineData(TraktNotesObjectType.All, TraktExtendedInfo.Full, null, 20, $"{URIPath}/all?extended=full&limit=20")]
        [InlineData(TraktNotesObjectType.All, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/all?extended=full&page=10&limit=20")]
        public void TestUserNotesGetRequestHasValidURIPath(TraktNotesObjectType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userNotesGetRequest = new UserNotesGetRequest
            {
                Id = "123",
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userNotesGetRequest.BuildUri();
            userNotesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserNotesGetRequestHasValidOAuthRequirement()
        {
            var userNotesGetRequest = new UserNotesGetRequest { Id = default! };
            userNotesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserNotesGetRequestIsGetRequest()
        {
            var userNotesGetRequest = new UserNotesGetRequest { Id = default! };
            userNotesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserNotesGetRequestHasCorrectRequestObjectType()
        {
            var userNotesGetRequest = new UserNotesGetRequest { Id = default! };
            userNotesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserNotesGetRequestValidate()
        {
            var userNotesGetRequest = new UserNotesGetRequest { Id = string.Empty };
            Action act = () => userNotesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userNotesGetRequest = new UserNotesGetRequest { Id = "  " };
            act = () => userNotesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userNotesGetRequest = new UserNotesGetRequest { Id = "id with spaces" };
            act = () => userNotesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
