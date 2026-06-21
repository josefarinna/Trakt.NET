#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPersonalListsGetRequestTests
    {
        private const string URIPath = "users/123/lists";

        [Fact]
        public void TestUserPersonalListsGetRequestHasValidURIPath()
        {
            var userPersonalListsGetRequest = new UserPersonalListsGetRequest
            {
                Id = "123"
            };

            userPersonalListsGetRequest.BuildUri();
            userPersonalListsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
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
