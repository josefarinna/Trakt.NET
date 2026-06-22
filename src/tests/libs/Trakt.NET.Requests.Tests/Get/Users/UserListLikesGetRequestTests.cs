#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserListLikesGetRequestTests
    {
        private const string URIPath = "users/123/lists/123/likes";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestUserListLikesGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var userListLikesGetRequest = new UserListLikesGetRequest
            {
                Id = "123",
                ListId = "123",
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userListLikesGetRequest.BuildUri();
            userListLikesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserListLikesGetRequestHasValidOAuthRequirement()
        {
            var userListLikesGetRequest = new UserListLikesGetRequest { Id = default!, ListId = default! };
            userListLikesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserListLikesGetRequestIsGetRequest()
        {
            var userListLikesGetRequest = new UserListLikesGetRequest { Id = default!, ListId = default! };
            userListLikesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserListLikesGetRequestHasCorrectRequestObjectType()
        {
            var userListLikesGetRequest = new UserListLikesGetRequest { Id = default!, ListId = default! };
            userListLikesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserListLikesGetRequestValidate()
        {
            var userListLikesGetRequest = new UserListLikesGetRequest { Id = string.Empty, ListId = default! };
            Action act = () => userListLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikesGetRequest = new UserListLikesGetRequest { Id = "  ", ListId = default! };
            act = () => userListLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikesGetRequest = new UserListLikesGetRequest { Id = "id with spaces", ListId = default! };
            act = () => userListLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikesGetRequest = new UserListLikesGetRequest { Id = "id", ListId = string.Empty };
            act = () => userListLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikesGetRequest = new UserListLikesGetRequest { Id = "id", ListId = "  " };
            act = () => userListLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikesGetRequest = new UserListLikesGetRequest { Id = "id", ListId = "id with spaces" };
            act = () => userListLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
