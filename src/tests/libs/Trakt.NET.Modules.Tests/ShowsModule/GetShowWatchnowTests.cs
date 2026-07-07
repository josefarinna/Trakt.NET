using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowWatchnowTests
    {
        private const string Country = "us";
        private static readonly string GetShowWatchnowUri = $"shows/{TestConstants.Shows.TraktShowID}/watchnow/{Country}";
        private static readonly string GetShowWatchnowUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/watchnow/{Country}";
        private static readonly string GetShowJustwatchLinksUri = $"shows/{TestConstants.Shows.TraktShowID}/watchnow/justwatch_links/{Country}";
        private static readonly string GetShowJustwatchLinksUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/watchnow/justwatch_links/{Country}";

        [Fact]
        public async Task TestGetShowWatchnowWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchnowUri, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Shows.GetShowWatchnowAsync(TestConstants.Shows.TraktShowID, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ContainsKey("us").ShouldBeTrue();
            response.Content["us"].Subscription.ShouldNotBeNull();
            response.Content["us"].Subscription!.Count.ShouldBe(1);
            response.Content["us"].Subscription![0].Source.ShouldBe("netflix");
        }

        [Fact]
        public async Task TestGetShowWatchnowWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchnowUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Shows.GetShowWatchnowAsync(TestConstants.Shows.ShowSlug, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowWatchnowWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchnowUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Shows.GetShowWatchnowAsync(TestConstants.Shows.ShowIDs, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowJustwatchLinksWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowJustwatchLinksUri, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.TraktShowID, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ContainsKey("netflix").ShouldBeTrue();
            response.Content["netflix"].ShouldBe("https://justwatch.com/netflix");
        }

        [Fact]
        public async Task TestGetShowJustwatchLinksWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.ShowSlug, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowJustwatchLinksWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.ShowIDs, Country, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetShowWatchnowThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchnowUri, statusCode);

            try
            {
                await client.Shows.GetShowWatchnowAsync(TestConstants.Shows.TraktShowID, Country, cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetShowWatchnowThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowWatchnowUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>>> act = () => client.Shows.GetShowWatchnowAsync(default(TraktShowIDs)!, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Shows.GetShowWatchnowAsync(new TraktShowIDs(), Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowWatchnowAsync(0, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowWatchnowAsync(string.Empty, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowWatchnowAsync("   ", Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowWatchnowAsync(TestConstants.Shows.ShowSlug, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowWatchnowAsync(TestConstants.Shows.ShowSlug, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
