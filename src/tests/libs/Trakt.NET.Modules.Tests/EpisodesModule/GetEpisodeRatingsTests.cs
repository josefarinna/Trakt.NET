using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeRatingsTests
    {
        private readonly string GetEpisodeRatingsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/ratings";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Fact]
        public async Task TestGetEpisodeRatings()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeRatingsUri, responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktRating responseValue = response.Content;

            responseValue.Rating.ShouldBe(8.54044f);
            responseValue.Votes.ShouldBe(3919U);

            var distribution = new Dictionary<string, uint>()
            {
                { "1",  59 }, { "2", 11 }, { "3", 2 }, { "4", 14 }, { "5", 58 },
                { "6",  233 }, { "7", 492 }, { "8", 835 }, { "9", 635 }, { "10", 1580 }
            };

            responseValue.Distribution.ShouldNotBeNull();
            responseValue.Distribution.Count.ShouldBe(10);
            responseValue.Distribution.ShouldBeEquivalentTo(distribution);
        }

        [Fact]
        public async Task TestGetEpisodeRatingsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeRatingsUri, responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeRatingsWithShowIdsTraktID()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.TraktShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeRatingsUri, responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(showIds, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeRatingsWithShowIdsSlug()
        {
            var showIds = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/ratings", responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(showIds, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeRatingsWithShowIds()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/ratings", responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeRatingsWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episoderatings.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/ratings", responseContent);

            TraktResponse<TraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(show, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
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
        public async Task TestGetEpisodeRatingsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeRatingsUri, statusCode);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeRatingsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeRatingsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(default(TraktShow)!, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(0, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
