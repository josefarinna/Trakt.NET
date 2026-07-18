#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserSmartListAddPostRequestTests
    {
        private const string URIPath = "users/123/smart-lists";

        [Fact]
        public void TestUserSmartListAddPostRequestHasValidURIPath()
        {
            var userSmartListAddPostRequest = new UserSmartListAddPostRequest
            {
                Id = "123",
                TraktSmartListPost = new TraktSmartListPost()
            };

            userSmartListAddPostRequest.BuildUri();
            userSmartListAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSmartListAddPostRequestHasValidOAuthRequirement()
        {
            var userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = default!, TraktSmartListPost = default! };
            userSmartListAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSmartListAddPostRequestIsPostRequest()
        {
            var userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = default!, TraktSmartListPost = default! };
            userSmartListAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserSmartListAddPostRequestHasCorrectRequestObjectType()
        {
            var userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = default!, TraktSmartListPost = default! };
            userSmartListAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserSmartListAddPostRequestValidate()
        {
            var userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = string.Empty, TraktSmartListPost = default! };
            Action act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = "  ", TraktSmartListPost = default! };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = "id with spaces", TraktSmartListPost = default! };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = "id", TraktSmartListPost = default! };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = "id", TraktSmartListPost = new TraktSmartListPost() };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<ArgumentException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest { Id = "id", TraktSmartListPost = new TraktSmartListPost { Name = "  " } };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<ArgumentException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest
            {
                Id = "id",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Unspecified
                }
            };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest
            {
                Id = "id",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Popular,
                    MediaType = TraktSmartListMediaType.Unspecified
                }
            };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest
            {
                Id = "id",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Popular,
                    MediaType = TraktSmartListMediaType.Movies,
                    Privacy = TraktListPrivacy.Unspecified
                }
            };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userSmartListAddPostRequest = new UserSmartListAddPostRequest
            {
                Id = "id",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Popular,
                    MediaType = TraktSmartListMediaType.Movies,
                    Privacy = TraktListPrivacy.Private
                }
            };
            act = () => userSmartListAddPostRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
