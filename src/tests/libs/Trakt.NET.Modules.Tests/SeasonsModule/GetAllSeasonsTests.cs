using System.Globalization;
using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetAllSeasonTests
    {
        private const string GetAllSeasonsUri = "shows/1390/seasons";
        private readonly string ShowID = TestConstants.Shows.ShowID.ToString(CultureInfo.InvariantCulture);
        private const string TranslationLanguageCode = "en";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetAllSeasons()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient(GetAllSeasonsUri, responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(ShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowID}/seasons", responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithShowIDsTraktID()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowID}/seasons", responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithShowIDsSlug()
        {
            var showIDs = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons", responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithShowIDs()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID,
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons", responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithShow()
        {
            var show = new TraktShow
            {
                IDs = new TraktShowIDs
                {
                    Trakt = TestConstants.Shows.ShowID,
                    Slug = TestConstants.Shows.ShowSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons", responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(show, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetAllSeasonsUri}?extended={ExtendedInfo.ToURI()}",
                                                           responseContent);

            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(ShowID, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithTranslations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetAllSeasonsUri}?translations={TranslationLanguageCode}",
                                                           responseContent);

            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(ShowID, null, TranslationLanguageCode, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithExtendedInfoAndTranslations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetAllSeasonsUri}?extended={ExtendedInfo.ToURI()}&translations={TranslationLanguageCode}",
                                                           responseContent);

            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(ShowID, ExtendedInfo, TranslationLanguageCode, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithAllTranslations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetAllSeasonsUri}?translations=all",
                                                           responseContent);

            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(ShowID, null, "all", TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithExtendedInfoAndAllTranslations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetAllSeasonsUri}?extended={ExtendedInfo.ToURI()}&translations=all",
                                                           responseContent);

            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(ShowID, ExtendedInfo, "all", TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
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
        public async Task TestGetAllSeasonWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetAllSeasonsUri, statusCode);

            Func<Task<TraktListResponse<TraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllSeasonWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetAllSeasonsUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktSeason>>> act =
                () => client.Seasons.GetAllSeasonsAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetAllSeasonsAsync(default(TraktShow)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetAllSeasonsAsync(new TraktShowIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetAllSeasonsAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
