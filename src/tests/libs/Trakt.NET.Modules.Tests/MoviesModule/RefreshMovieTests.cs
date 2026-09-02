using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class RefreshMovieTests
    {
        private const string RefreshMovieUriPrefix = "movies";
        private const string RefreshMovieUriSuffix = "refresh";
        private const string RefreshMovieUriWithSlug = RefreshMovieUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + RefreshMovieUriSuffix;
        private static readonly string RefreshMovieUri = $"{RefreshMovieUriPrefix}/{TestConstants.Movies.TraktMovieID}/{RefreshMovieUriSuffix}";

        [Fact]
        public async Task TestRefreshMovieWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{RefreshMovieUriPrefix}/293990/{RefreshMovieUriSuffix}", HttpStatusCode.Created);

            TraktResponse response = await client.Movies.RefreshMovieAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshMovieWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Movies.RefreshMovieAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshMovieWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Movies.RefreshMovieAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData(true, "?images=true")]
        [InlineData(false, "?images=false")]
        public async Task TestRefreshMovieWithImages(bool? images, string query)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{RefreshMovieUriWithSlug}{query}", HttpStatusCode.Created);

            TraktResponse response = await client.Movies.RefreshMovieAsync(TestConstants.Movies.MovieSlug, images, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
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
        public async Task TestRefreshMovieThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUri, statusCode);

            try
            {
                await client.Movies.RefreshMovieAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestRefreshMovieThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Movies.RefreshMovieAsync(default(TraktMovieIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.RefreshMovieAsync(new TraktMovieIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.RefreshMovieAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
