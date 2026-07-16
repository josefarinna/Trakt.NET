#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPersonalListAddPostRequestTests
    {
        private const string URIPath = "users/123/lists";

        [Fact]
        public void TestUserPersonalListAddPostRequestHasValidURIPath()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest
            {
                Id = "123",
                TraktUserPersonalListPost = new TraktUserPersonalListPost()
            };

            userPersonalListAddPostRequest.BuildUri();
            userPersonalListAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListAddPostRequestHasValidOAuthRequirement()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = default!, TraktUserPersonalListPost = default! };
            userPersonalListAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListAddPostRequestIsPostRequest()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = default!, TraktUserPersonalListPost = default! };
            userPersonalListAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPersonalListAddPostRequestHasCorrectRequestObjectType()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = default!, TraktUserPersonalListPost = default! };
            userPersonalListAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPersonalListAddPostRequestValidate()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = string.Empty, TraktUserPersonalListPost = default! };
            Action act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = "  ", TraktUserPersonalListPost = default! };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = "id with spaces", TraktUserPersonalListPost = default! };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = "id", TraktUserPersonalListPost = default! };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = "id", TraktUserPersonalListPost = new TraktUserPersonalListPost() };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<ArgumentException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = "id", TraktUserPersonalListPost = new TraktUserPersonalListPost { Name = "  " } };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<ArgumentException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest
            {
                Id = "id",
                TraktUserPersonalListPost = new TraktUserPersonalListPost
                {
                    Name = "listname",
                    Privacy = TraktListPrivacy.Unspecified
                }
            };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest
            {
                Id = "id",
                TraktUserPersonalListPost = new TraktUserPersonalListPost
                {
                    Name = "listname",
                    Privacy = TraktListPrivacy.Private
                }
            };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
