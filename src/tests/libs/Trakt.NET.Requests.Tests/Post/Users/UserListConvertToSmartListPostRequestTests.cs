#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserListConvertToSmartListPostRequestTests
    {
        private const string URIPath = "users/sean/lists/123/smart-list-draft/convert";

        [Fact]
        public void TestUserListConvertToSmartListPostRequestHasValidURIPath()
        {
            var userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest
            {
                Id = "sean",
                ListId = "123",
                TraktSmartListPost = new TraktSmartListPost()
            };

            userListConvertToSmartListPostRequest.BuildUri();
            userListConvertToSmartListPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserListConvertToSmartListPostRequestHasValidOAuthRequirement()
        {
            var userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = default!, ListId = default!, TraktSmartListPost = default! };
            userListConvertToSmartListPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserListConvertToSmartListPostRequestIsPostRequest()
        {
            var userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = default!, ListId = default!, TraktSmartListPost = default! };
            userListConvertToSmartListPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserListConvertToSmartListPostRequestHasCorrectRequestObjectType()
        {
            var userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = default!, ListId = default!, TraktSmartListPost = default! };
            userListConvertToSmartListPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserListConvertToSmartListPostRequestValidate()
        {
            var userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = string.Empty, ListId = "123", TraktSmartListPost = default! };
            Action act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = "  ", ListId = "123", TraktSmartListPost = default! };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = "id with spaces", ListId = "123", TraktSmartListPost = default! };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = "sean", ListId = string.Empty, TraktSmartListPost = default! };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = "sean", ListId = "  ", TraktSmartListPost = default! };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = "sean", ListId = "list id with spaces", TraktSmartListPost = default! };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = "sean", ListId = "123", TraktSmartListPost = default! };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = "sean", ListId = "123", TraktSmartListPost = new TraktSmartListPost() };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<ArgumentException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest { Id = "sean", ListId = "123", TraktSmartListPost = new TraktSmartListPost { Name = "  " } };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<ArgumentException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest
            {
                Id = "sean",
                ListId = "123",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Unspecified
                }
            };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest
            {
                Id = "sean",
                ListId = "123",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Popular,
                    MediaType = TraktSmartListMediaType.Unspecified
                }
            };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest
            {
                Id = "sean",
                ListId = "123",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Popular,
                    MediaType = TraktSmartListMediaType.Movies,
                    Privacy = TraktListPrivacy.Unspecified
                }
            };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userListConvertToSmartListPostRequest = new UserListConvertToSmartListPostRequest
            {
                Id = "sean",
                ListId = "123",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Popular,
                    MediaType = TraktSmartListMediaType.Movies,
                    Privacy = TraktListPrivacy.Private
                }
            };
            act = () => userListConvertToSmartListPostRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
