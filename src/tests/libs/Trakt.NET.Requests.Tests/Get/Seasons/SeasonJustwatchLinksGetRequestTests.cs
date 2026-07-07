#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonJustwatchLinksGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string Country = "us";
        private const string URIPath = $"shows/{ShowID}/seasons/1/watchnow/justwatch_links/{Country}";

        [Fact]
        public void TestSeasonJustwatchLinksGetRequestHasValidURIPath()
        {
            var request = new SeasonJustwatchLinksGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                Country = Country
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonJustwatchLinksGetRequestHasValidOAuthRequirement()
        {
            var request = new SeasonJustwatchLinksGetRequest { ShowId = ShowID, SeasonNumber = 1, Country = Country };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonJustwatchLinksGetRequestIsGetRequest()
        {
            var request = new SeasonJustwatchLinksGetRequest { ShowId = ShowID, SeasonNumber = 1, Country = Country };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonJustwatchLinksGetRequestHasCorrectRequestObjectType()
        {
            var request = new SeasonJustwatchLinksGetRequest { ShowId = ShowID, SeasonNumber = 1, Country = Country };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonJustwatchLinksGetRequestValidate()
        {
            var request = new SeasonJustwatchLinksGetRequest { ShowId = string.Empty, SeasonNumber = 1, Country = Country };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SeasonJustwatchLinksGetRequest { ShowId = "  ", SeasonNumber = 1, Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SeasonJustwatchLinksGetRequest { ShowId = "id with spaces", SeasonNumber = 1, Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SeasonJustwatchLinksGetRequest { ShowId = ShowID, SeasonNumber = 0, Country = Country };
            act = () => request.Validate();
            act.ShouldNotThrow();

            request = new SeasonJustwatchLinksGetRequest { ShowId = ShowID, SeasonNumber = 1, Country = string.Empty };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SeasonJustwatchLinksGetRequest { ShowId = ShowID, SeasonNumber = 1, Country = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SeasonJustwatchLinksGetRequest { ShowId = ShowID, SeasonNumber = 1, Country = "country with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
