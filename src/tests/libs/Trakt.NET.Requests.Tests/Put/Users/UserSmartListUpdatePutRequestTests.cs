#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Users
{
    public sealed class UserSmartListUpdatePutRequestTests
    {
        private const string URIPath = "users/123/smart-lists/456";

        [Fact]
        public void TestUserSmartListUpdatePutRequestHasValidURIPath()
        {
            var userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest
            {
                Id = "123",
                ListId = "456",
                TraktSmartListPost = new TraktSmartListPost()
            };

            userSmartListUpdatePutRequest.BuildUri();
            userSmartListUpdatePutRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSmartListUpdatePutRequestHasValidOAuthRequirement()
        {
            var userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = default!, ListId = default! };
            userSmartListUpdatePutRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSmartListUpdatePutRequestIsPutRequest()
        {
            var userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = default!, ListId = default! };
            userSmartListUpdatePutRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestUserSmartListUpdatePutRequestHasCorrectRequestObjectType()
        {
            var userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = default!, ListId = default! };
            userSmartListUpdatePutRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserSmartListUpdatePutRequestValidate()
        {
            var userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = string.Empty, ListId = default! };
            Action act = () => userSmartListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = "  ", ListId = default! };
            act = () => userSmartListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = "id with spaces", ListId = default! };
            act = () => userSmartListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = "id", ListId = string.Empty };
            act = () => userSmartListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = "id", ListId = "  " };
            act = () => userSmartListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = "id", ListId = "id with spaces" };
            act = () => userSmartListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            // Post payload is optional, but if present, it is validated
            userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest { Id = "id", ListId = "listid", TraktSmartListPost = new TraktSmartListPost() };
            act = () => userSmartListUpdatePutRequest.Validate();
            act.ShouldThrow<ArgumentException>();

            userSmartListUpdatePutRequest = new UserSmartListUpdatePutRequest
            {
                Id = "id",
                ListId = "listid",
                TraktSmartListPost = new TraktSmartListPost
                {
                    Name = "smartlist",
                    Source = TraktSmartListSource.Popular,
                    MediaType = TraktSmartListMediaType.Movies,
                    Privacy = TraktListPrivacy.Private
                }
            };
            act = () => userSmartListUpdatePutRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
