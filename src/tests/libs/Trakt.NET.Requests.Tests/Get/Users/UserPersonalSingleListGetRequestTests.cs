#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPersonalSingleListGetRequestTests
    {
        private const string URIPath = "users/123/lists/123";

        [Fact]
        public void TestUserPersonalSingleListGetRequestHasValidURIPath()
        {
            var userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest
            {
                Id = "123",
                ListId = "123"
            };

            userPersonalSingleListGetRequest.BuildUri();
            userPersonalSingleListGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalSingleListGetRequestHasValidOAuthRequirement()
        {
            var userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = default!, ListId = default! };
            userPersonalSingleListGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserPersonalSingleListGetRequestIsGetRequest()
        {
            var userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = default!, ListId = default! };
            userPersonalSingleListGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserPersonalSingleListGetRequestHasCorrectRequestObjectType()
        {
            var userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = default!, ListId = default! };
            userPersonalSingleListGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.User);
        }

        [Fact]
        public void TestUserPersonalSingleListGetRequestValidate()
        {
            var userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = string.Empty, ListId = default! };
            Action act = () => userPersonalSingleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = "  ", ListId = default! };
            act = () => userPersonalSingleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = "id with spaces", ListId = default! };
            act = () => userPersonalSingleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = "id", ListId = string.Empty };
            act = () => userPersonalSingleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = "id", ListId = "  " };
            act = () => userPersonalSingleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalSingleListGetRequest = new UserPersonalSingleListGetRequest { Id = "id", ListId = "id with spaces" };
            act = () => userPersonalSingleListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
