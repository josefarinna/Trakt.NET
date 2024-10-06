using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieReleasesTests
    {
        private const string GetMovieReleasesUriPrefix = "movies";
        private const string GetMovieReleasesUriSuffix = "releases";
        private const string GetMovieReleasesUri = GetMovieReleasesUriPrefix + "/293990/" + GetMovieReleasesUriSuffix;
        private const string GetMovieReleasesUriWithSlug = GetMovieReleasesUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieReleasesUriSuffix;

        [Theory]
        [InlineData(null, GetMovieReleasesUri, "Movies\\moviereleases.json")]
        [InlineData("", GetMovieReleasesUri, "Movies\\moviereleases.json")]
        [InlineData("fr", $"{GetMovieReleasesUri}/fr", "Movies\\moviereleases.json")]
        public async Task TestGetMovieReleasesWithID(string? country, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.MovieID, country);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);

            IReadOnlyList<TraktMovieRelease> movieReleases = response.Content!;

            TraktMovieRelease movieRelease = movieReleases[0];

            movieRelease.Country.Should().Be("fr");
            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);

            movieRelease = movieReleases[1];

            movieRelease.Country.Should().Be("us");
            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
        }

        [Theory]
        [InlineData(null, GetMovieReleasesUriWithSlug, "Movies\\moviereleases.json")]
        [InlineData("", GetMovieReleasesUriWithSlug, "Movies\\moviereleases.json")]
        [InlineData("fr", $"{GetMovieReleasesUriWithSlug}/fr", "Movies\\moviereleases.json")]
        public async Task TestGetMovieReleasesWithSlug(string? country, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.MovieSlug, country);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);

            IReadOnlyList<TraktMovieRelease> movieReleases = response.Content!;

            TraktMovieRelease movieRelease = movieReleases[0];

            movieRelease.Country.Should().Be("fr");
            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);

            movieRelease = movieReleases[1];

            movieRelease.Country.Should().Be("us");
            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
        }

        [Theory]
        [InlineData(null, GetMovieReleasesUriWithSlug, "Movies\\moviereleases.json")]
        [InlineData("", GetMovieReleasesUriWithSlug, "Movies\\moviereleases.json")]
        [InlineData("fr", $"{GetMovieReleasesUriWithSlug}/fr", "Movies\\moviereleases.json")]
        public async Task TestGetMovieReleasesWithIDs(string? country, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.MovieIDs, country);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
            response.Count.Should().Be(2);

            IReadOnlyList<TraktMovieRelease> movieReleases = response.Content!;

            TraktMovieRelease movieRelease = movieReleases[0];

            movieRelease.Country.Should().Be("fr");
            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);

            movieRelease = movieReleases[1];

            movieRelease.Country.Should().Be("us");
            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
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
        public async Task TestGetMovieReleasesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieReleasesUri, statusCode);

            try
            {
                await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.MovieID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
        public async Task TestGetMovieReleasesWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieReleasesUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.MovieSlug);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
        public async Task TestGetMovieReleasesWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieReleasesUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.MovieIDs);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task TestGetMovieReleasesWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviereleases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieReleasesUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(default(TraktMovieIDs));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.Should().ThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieReleasesAsync(movieIDs);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
