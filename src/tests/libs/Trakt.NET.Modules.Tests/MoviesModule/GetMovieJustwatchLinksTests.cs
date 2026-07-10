using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieJustwatchLinksTests
    {
        private const string Country = "us";
        private static readonly string GetMovieJustwatchLinksUri = $"movies/{TestConstants.Movies.TraktMovieID}/watchnow/justwatch_links/{Country}";
        private static readonly string GetMovieJustwatchLinksUriWithSlug = $"movies/{TestConstants.Movies.MovieSlug}/watchnow/justwatch_links/{Country}";

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
        public async Task TestGetMovieJustwatchLinksThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieJustwatchLinksUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Movies.GetMovieJustwatchLinksAsync(TestConstants.Movies.TraktMovieID, Country, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMovieJustwatchLinksThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieJustwatchLinksUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Movies.GetMovieJustwatchLinksAsync(default(TraktMovieIDs)!, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Movies.GetMovieJustwatchLinksAsync(new TraktMovieIDs(), Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieJustwatchLinksAsync(string.Empty, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Movies.GetMovieJustwatchLinksAsync("   ", Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Movies.GetMovieJustwatchLinksAsync(TestConstants.Movies.MovieSlug, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Movies.GetMovieJustwatchLinksAsync(TestConstants.Movies.MovieSlug, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
