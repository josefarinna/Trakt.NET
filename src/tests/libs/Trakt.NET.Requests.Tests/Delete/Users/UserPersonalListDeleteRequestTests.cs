#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserPersonalListDeleteRequestTests
    {
        private const string URIPath = "users/123/lists/123";

        [Fact]
        public void TestUserPersonalListDeleteRequestHasValidURIPath()
        {
            var userPersonalListDeleteRequest = new UserPersonalListDeleteRequest
            {
                Id = "123",
                ListId = "123"
            };

            userPersonalListDeleteRequest.BuildUri();
            userPersonalListDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListDeleteRequestHasValidOAuthRequirement()
        {
            var userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = default!, ListId = default! };
            userPersonalListDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListDeleteRequestIsDeleteRequest()
        {
            var userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = default!, ListId = default! };
            userPersonalListDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserPersonalListDeleteRequestHasCorrectRequestObjectType()
        {
            var userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = default!, ListId = default! };
            userPersonalListDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserPersonalListDeleteRequestValidate()
        {
            var userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = string.Empty, ListId = default! };
            Action act = () => userPersonalListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = "  ", ListId = default! };
            act = () => userPersonalListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = "id with spaces", ListId = default! };
            act = () => userPersonalListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = default!, ListId = string.Empty };
            act = () => userPersonalListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = default!, ListId = "  " };
            act = () => userPersonalListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListDeleteRequest = new UserPersonalListDeleteRequest { Id = default!, ListId = "id with spaces" };
            act = () => userPersonalListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
