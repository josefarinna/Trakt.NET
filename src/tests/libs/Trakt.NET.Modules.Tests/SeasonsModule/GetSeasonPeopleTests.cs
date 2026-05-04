using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonPeopleTests
    {
        private const string GetSeasonPeopleUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/people";
        private const uint SeasonNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetSeasonPeople()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonPeopleUri, responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCastAndCrew responseValue = response.Content;

            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast.Count.ShouldBe(2);
            responseValue.Crew.ShouldNotBeNull();
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production.Count.ShouldBe(1);
            responseValue.Crew.Art.ShouldNotBeNull();
            responseValue.Crew.Art.Count.ShouldBe(1);
            responseValue.Crew.Crew.ShouldNotBeNull();
            responseValue.Crew.Crew.Count.ShouldBe(1);
            responseValue.Crew.CostumeAndMakeUp.ShouldNotBeNull();
            responseValue.Crew.CostumeAndMakeUp.Count.ShouldBe(1);
            responseValue.Crew.Directing.ShouldNotBeNull();
            responseValue.Crew.Directing.Count.ShouldBe(1);
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing.Count.ShouldBe(1);
            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound.Count.ShouldBe(1);
            responseValue.Crew.Camera.ShouldNotBeNull();
            responseValue.Crew.Camera.Count.ShouldBe(1);
            responseValue.Crew.Lighting.ShouldNotBeNull();
            responseValue.Crew.Lighting.Count.ShouldBe(1);
            responseValue.Crew.VisualEffects.ShouldNotBeNull();
            responseValue.Crew.VisualEffects.Count.ShouldBe(1);
            responseValue.Crew.Editing.ShouldNotBeNull();
            responseValue.Crew.Editing.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.TraktShowID}/seasons/{SeasonNr}/people", responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.TraktShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithShowIDsTraktID()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.TraktShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.TraktShowID}/seasons/{SeasonNr}/people", responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(showIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithShowIDsSlug()
        {
            var showIDs = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/people", responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(showIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithShowIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/people", responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/people", responseContent);
            
            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(show, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonpeople.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonPeopleUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowID, SeasonNr, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCastAndCrew responseValue = response.Content;

            responseValue.Cast.ShouldNotBeNull();
            responseValue.Cast.Count.ShouldBe(2);
            responseValue.Crew.ShouldNotBeNull();
            responseValue.Crew.Production.ShouldNotBeNull();
            responseValue.Crew.Production.Count.ShouldBe(1);
            responseValue.Crew.Art.ShouldNotBeNull();
            responseValue.Crew.Art.Count.ShouldBe(1);
            responseValue.Crew.Crew.ShouldNotBeNull();
            responseValue.Crew.Crew.Count.ShouldBe(1);
            responseValue.Crew.CostumeAndMakeUp.ShouldNotBeNull();
            responseValue.Crew.CostumeAndMakeUp.Count.ShouldBe(1);
            responseValue.Crew.Directing.ShouldNotBeNull();
            responseValue.Crew.Directing.Count.ShouldBe(1);
            responseValue.Crew.Writing.ShouldNotBeNull();
            responseValue.Crew.Writing.Count.ShouldBe(1);
            responseValue.Crew.Sound.ShouldNotBeNull();
            responseValue.Crew.Sound.Count.ShouldBe(1);
            responseValue.Crew.Camera.ShouldNotBeNull();
            responseValue.Crew.Camera.Count.ShouldBe(1);
            responseValue.Crew.Lighting.ShouldNotBeNull();
            responseValue.Crew.Lighting.Count.ShouldBe(1);
            responseValue.Crew.VisualEffects.ShouldNotBeNull();
            responseValue.Crew.VisualEffects.Count.ShouldBe(1);
            responseValue.Crew.Editing.ShouldNotBeNull();
            responseValue.Crew.Editing.Count.ShouldBe(1);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
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
        public async Task TestGetSeasonPeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonPeopleUri, statusCode);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Seasons.GetSeasonPeopleAsync(TestConstants.Shows.ShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonPeopleWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonPeopleUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Seasons.GetSeasonPeopleAsync(default(TraktShowIDs)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonPeopleAsync(default(TraktShow)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonPeopleAsync(new TraktShowIDs(), SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonPeopleAsync(0, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
