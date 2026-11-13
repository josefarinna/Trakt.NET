#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.People
{
    public sealed class PersonAwardsGetRequestTests
    {
        private const string PersonID = "harrison-ford";
        private const string URIPath = "people/harrison-ford/awards";

        [Fact]
        public void TestPersonAwardsGetRequestHasValidURIPath()
        {
            var request = new PersonAwardsGetRequest { Id = PersonID };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPersonAwardsGetRequestHasValidOAuthRequirement()
        {
            var request = new PersonAwardsGetRequest { Id = PersonID };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPersonAwardsGetRequestIsGetRequest()
        {
            var request = new PersonAwardsGetRequest { Id = PersonID };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestPersonAwardsGetRequestHasCorrectRequestObjectType()
        {
            var request = new PersonAwardsGetRequest { Id = PersonID };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }

        [Fact]
        public void TestPersonAwardsGetRequestValidate()
        {
            var request = new PersonAwardsGetRequest { Id = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new PersonAwardsGetRequest { Id = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new PersonAwardsGetRequest { Id = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
