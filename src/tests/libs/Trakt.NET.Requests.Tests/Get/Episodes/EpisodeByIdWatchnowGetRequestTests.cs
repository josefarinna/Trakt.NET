#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeByIdWatchnowGetRequestTests
    {
        private const string EpisodeID = "456";
        private const string Country = "us";
        private const string URIPath = $"episodes/{EpisodeID}/watchnow/{Country}";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(true, null, $"{URIPath}?links=true")]
        [InlineData(false, null, $"{URIPath}?links=false")]
        [InlineData(null, TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        [InlineData(true, TraktExtendedInfo.Full, $"{URIPath}?links=true&extended=full")]
        public void TestEpisodeByIdWatchnowGetRequestHasValidURIPath(bool? links, TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var request = new EpisodeByIdWatchnowGetRequest
            {
                Id = EpisodeID,
                Country = Country,
                Links = links,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeByIdWatchnowGetRequestHasValidOAuthRequirement()
        {
            var request = new EpisodeByIdWatchnowGetRequest { Id = EpisodeID, Country = Country };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeByIdWatchnowGetRequestIsGetRequest()
        {
            var request = new EpisodeByIdWatchnowGetRequest { Id = EpisodeID, Country = Country };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeByIdWatchnowGetRequestHasCorrectRequestObjectType()
        {
            var request = new EpisodeByIdWatchnowGetRequest { Id = EpisodeID, Country = Country };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeByIdWatchnowGetRequestValidate()
        {
            var request = new EpisodeByIdWatchnowGetRequest { Id = string.Empty, Country = Country };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeByIdWatchnowGetRequest { Id = "  ", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeByIdWatchnowGetRequest { Id = "id with spaces", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeByIdWatchnowGetRequest { Id = EpisodeID, Country = string.Empty };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeByIdWatchnowGetRequest { Id = EpisodeID, Country = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeByIdWatchnowGetRequest { Id = EpisodeID, Country = "country with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
