using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieWatchnowTests
    {
        private const string Country = "us";
        private static readonly string GetMovieWatchnowUri = $"movies/{TestConstants.Movies.TraktMovieID}/watchnow/{Country}";
        private static readonly string GetMovieWatchnowUriWithSlug = $"movies/{TestConstants.Movies.MovieSlug}/watchnow/{Country}";
        private static readonly string GetMovieJustwatchLinksUri = $"movies/{TestConstants.Movies.TraktMovieID}/watchnow/justwatch_links/{Country}";
        private static readonly string GetMovieJustwatchLinksUriWithSlug = $"movies/{TestConstants.Movies.MovieSlug}/watchnow/justwatch_links/{Country}";

        [Fact]
        public async Task TestGetMovieWatchnowWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieWatchnowUri, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Movies.GetMovieWatchnowAsync(TestConstants.Movies.TraktMovieID, Country, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMovieWatchnowWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieWatchnowUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Movies.GetMovieWatchnowAsync(TestConstants.Movies.MovieSlug, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMovieWatchnowWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieWatchnowUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, TraktWatchnowSources>> response =
                await client.Movies.GetMovieWatchnowAsync(TestConstants.Movies.MovieIDs, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMovieJustwatchLinksWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieJustwatchLinksUri, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Movies.GetMovieJustwatchLinksAsync(TestConstants.Movies.TraktMovieID, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ContainsKey("netflix").ShouldBeTrue();
            response.Content["netflix"].ShouldBe("https://justwatch.com/netflix");
        }

        [Fact]
        public async Task TestGetMovieJustwatchLinksWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Movies.GetMovieJustwatchLinksAsync(TestConstants.Movies.MovieSlug, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMovieJustwatchLinksWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Movies.GetMovieJustwatchLinksAsync(TestConstants.Movies.MovieIDs, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
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
        public async Task TestGetMovieWatchnowThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieWatchnowUri, statusCode);

            try
            {
                await client.Movies.GetMovieWatchnowAsync(TestConstants.Movies.TraktMovieID, Country, cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetMovieWatchnowThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieWatchnowUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>>> act = () => client.Movies.GetMovieWatchnowAsync(default(TraktMovieIDs)!, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Movies.GetMovieWatchnowAsync(new TraktMovieIDs(), Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieWatchnowAsync(0, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieWatchnowAsync(string.Empty, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieWatchnowAsync("   ", Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieWatchnowAsync(TestConstants.Movies.MovieSlug, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieWatchnowAsync(TestConstants.Movies.MovieSlug, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
