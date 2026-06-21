#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.People
{
    public sealed class PersonMovieCreditsGetRequestTests
    {
        private const string URIPath = "people/123/movies";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestPersonMovieCreditsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var personMovieCreditsGetRequest = new PersonMovieCreditsGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            personMovieCreditsGetRequest.BuildUri();
            personMovieCreditsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPersonMovieCreditsGetRequestHasValidOAuthRequirement()
        {
            var personMovieCreditsGetRequest = new PersonMovieCreditsGetRequest { Id = default! };
            personMovieCreditsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPersonMovieCreditsGetRequestIsGetRequest()
        {
            var personMovieCreditsGetRequest = new PersonMovieCreditsGetRequest { Id = default! };
            personMovieCreditsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestPersonMovieCreditsGetRequestHasCorrectRequestObjectType()
        {
            var personMovieCreditsGetRequest = new PersonMovieCreditsGetRequest { Id = default! };
            personMovieCreditsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }

        [Fact]
        public void TestPersonMovieCreditsGetRequestValidate()
        {
            var personMovieCreditsGetRequest = new PersonMovieCreditsGetRequest { Id = string.Empty };
            Action act = () => personMovieCreditsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personMovieCreditsGetRequest = new PersonMovieCreditsGetRequest { Id = "  " };
            act = () => personMovieCreditsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personMovieCreditsGetRequest = new PersonMovieCreditsGetRequest { Id = "id with spaces" };
            act = () => personMovieCreditsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
