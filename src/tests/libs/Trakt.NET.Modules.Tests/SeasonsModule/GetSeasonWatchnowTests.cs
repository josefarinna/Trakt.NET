using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonWatchnowTests
    {
        private const uint SeasonNumber = 1U;
        private const string Country = "us";
        private static readonly string SeasonJustwatchLinksUri = $"shows/{TestConstants.Shows.TraktShowID}/seasons/{SeasonNumber}/watchnow/justwatch_links/{Country}";
        private static readonly string SeasonJustwatchLinksUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNumber}/watchnow/justwatch_links/{Country}";

        [Fact]
        public async Task TestGetSeasonJustwatchLinksWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUri, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.TraktShowID, SeasonNumber, Country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ContainsKey("netflix").ShouldBeTrue();
            response.Content["netflix"].ShouldBe("https://justwatch.com/netflix");
        }

        [Fact]
        public async Task TestGetSeasonJustwatchLinksWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.ShowSlug, SeasonNumber, Country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonJustwatchLinksWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.ShowIDs, SeasonNumber, Country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
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
        public async Task TestGetSeasonJustwatchLinksThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUri, statusCode);

            try
            {
                await client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.TraktShowID, SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetSeasonJustwatchLinksThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Seasons.GetSeasonJustwatchLinksAsync(default(TraktShowIDs)!, SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(new TraktShowIDs(), SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(0, SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(string.Empty, SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync("   ", SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.ShowSlug, SeasonNumber, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.ShowSlug, SeasonNumber, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
