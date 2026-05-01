using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeTranslationsTests
    {
        private readonly string GetEpisodeTranslationsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/translations";
        private readonly string ShowID = $"{TestConstants.Shows.ShowID}";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Fact]
        public async Task TestGetEpisodeTranslations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeTranslationsUri, responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeTranslationsUri, responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithShowIdsTraktID()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeTranslationsUri, responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithShowIdsSlug()
        {
            var showIds = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/translations",
                responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithShowIds()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID,
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/translations", responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithShow()
        {
            var show = new TraktShow
            {
                IDs = new TraktShowIDs
                {
                    Trakt = TestConstants.Shows.ShowID,
                    Slug = TestConstants.Shows.ShowSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/translations", responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetEpisodeTranslationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeTranslationsUri, statusCode);

            Func<Task<TraktListResponse<TraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeTranslationsUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(default(TraktShow)!, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(new TraktShowIDs(), SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(0, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
