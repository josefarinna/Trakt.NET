using System.Net;

namespace TraktNET.WatchnowModule
{
    public sealed class WatchnowModuleTests
    {
        private const string SourcesUri = "watchnow/sources";
        private const string Country = "us";
        private static readonly string SourcesCountryUri = $"watchnow/sources/{Country}";

        [Fact]
        public async Task TestGetWatchnowSources()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow_sources.json");
            TraktClient client = ModuleTestUtility.GetClient(SourcesUri, responseContent);

            TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>> response =
                await client.Watchnow.GetWatchnowSourcesAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
            response.Content[0].ContainsKey("us").ShouldBeTrue();
            response.Content[0]["us"][0].Source.ShouldBe("netflix");
            response.Content[0]["us"][0].Name.ShouldBe("Netflix");
        }

        [Fact]
        public async Task TestGetWatchnowSourcesWithCountry()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow_sources.json");
            TraktClient client = ModuleTestUtility.GetClient(SourcesCountryUri, responseContent);

            TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>> response =
                await client.Watchnow.GetWatchnowSourcesAsync(Country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
            response.Content[0].ContainsKey("us").ShouldBeTrue();
            response.Content[0]["us"][0].Source.ShouldBe("netflix");
            response.Content[0]["us"][0].Name.ShouldBe("Netflix");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        public async Task TestGetWatchnowSourcesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(SourcesUri, statusCode);

            try
            {
                await client.Watchnow.GetWatchnowSourcesAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetWatchnowSourcesThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(SourcesCountryUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>>> act = () => client.Watchnow.GetWatchnowSourcesAsync(string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Watchnow.GetWatchnowSourcesAsync("   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
