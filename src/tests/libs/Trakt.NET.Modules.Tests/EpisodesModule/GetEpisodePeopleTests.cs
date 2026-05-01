using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodePeopleTests
    {
        private readonly string GetEpisodePeopleUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people";
        private readonly string ShowID = $"{TestConstants.Shows.ShowID}";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetEpisodePeople()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");
            
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodePeopleUri, responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCastAndCrew responseValue = response.Content;

            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast.Count.ShouldBe(3);
            responseValue.Crew.ShouldNotBeNull();
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production.Count.ShouldBe(2);
            responseValue.Crew.Art.ShouldNotBeNull();
            responseValue.Crew.Art.Count.ShouldBe(1);
            responseValue.Crew.Crew.ShouldNotBeNull();
            responseValue.Crew.Crew.Count.ShouldBe(1);
            responseValue.Crew.CostumeAndMakeUp.ShouldBeNull();
            responseValue.Crew.Directing.ShouldBeNull();
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing.Count.ShouldBe(3);
            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound.Count.ShouldBe(1);
            responseValue.Crew.Camera.ShouldBeNull();
            responseValue.Crew.Lighting.ShouldBeNull();
            responseValue.Crew.VisualEffects.ShouldBeNull();
            responseValue.Crew.Editing.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people",
                responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(TestConstants.Shows.ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithShowIdsTraktID()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people",
                responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithShowIdsSlug()
        {
            var showIds = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people",
                responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithShowIds()
        {
            var showIds = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID,
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people",
                responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(showIds, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithShow()
        {
            var show = new TraktShow
            {
                IDs = new TraktShowIDs
                {
                    Trakt = TestConstants.Shows.ShowID,
                    Slug = TestConstants.Shows.ShowSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/people",
                responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodepeople.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetEpisodePeopleUri}?extended={ExtendedInfo.ToURI()}",
                responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(ShowID, SeasonNr, EpisodeNr, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCastAndCrew responseValue = response.Content;

            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast.Count.ShouldBe(3);
            responseValue.Crew.ShouldNotBeNull();
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production.Count.ShouldBe(2);
            responseValue.Crew.Art.ShouldNotBeNull();
            responseValue.Crew.Art.Count.ShouldBe(1);
            responseValue.Crew.Crew.ShouldNotBeNull();
            responseValue.Crew.Crew.Count.ShouldBe(1);
            responseValue.Crew.CostumeAndMakeUp.ShouldBeNull();
            responseValue.Crew.Directing.ShouldBeNull();
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing.Count.ShouldBe(3);
            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound.Count.ShouldBe(1);
            responseValue.Crew.Camera.ShouldBeNull();
            responseValue.Crew.Lighting.ShouldBeNull();
            responseValue.Crew.VisualEffects.ShouldBeNull();
            responseValue.Crew.Editing.ShouldBeNull();
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
        public async Task TestGetEpisodePeopleThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodePeopleUri, statusCode);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(ShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodePeopleThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodePeopleUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(default(TraktShow)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(0, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
