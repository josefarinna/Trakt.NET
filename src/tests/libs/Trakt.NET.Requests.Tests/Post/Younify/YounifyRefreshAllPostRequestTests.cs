#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Younify
{
    public sealed class YounifyRefreshAllPostRequestTests
    {
        private const string ServiceId = "netflix";

        [Fact]
        public void TestYounifyRefreshAllPostRequestHasValidURIPath()
        {
            var request = new YounifyRefreshAllPostRequest { ServiceId = ServiceId };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"younify/users/refresh/{ServiceId}/true", UriKind.Relative));
            request.Content.ShouldBeNull();

            request = new YounifyRefreshAllPostRequest { ServiceId = ServiceId, AllData = false };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"younify/users/refresh/{ServiceId}/false", UriKind.Relative));
            request.Content.ShouldBeNull();

            request = new YounifyRefreshAllPostRequest
            {
                ServiceId = ServiceId,
                AllData = true,
                TraktYounifyRefreshPost = new TraktYounifyRefreshPost { SkipSync = true }
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"younify/users/refresh/{ServiceId}/true", UriKind.Relative));
            request.Content.ShouldNotBeNull();
        }

        [Fact]
        public void TestYounifyRefreshAllPostRequestHasValidOAuthRequirement()
        {
            var request = new YounifyRefreshAllPostRequest { ServiceId = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestYounifyRefreshAllPostRequestIsPostRequest()
        {
            var request = new YounifyRefreshAllPostRequest { ServiceId = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestYounifyRefreshAllPostRequestHasCorrectRequestObjectType()
        {
            var request = new YounifyRefreshAllPostRequest { ServiceId = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestYounifyRefreshAllPostRequestValidate()
        {
            var request = new YounifyRefreshAllPostRequest { ServiceId = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new YounifyRefreshAllPostRequest { ServiceId = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new YounifyRefreshAllPostRequest { ServiceId = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
