using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieTests
    {
        private const string GetMovieUri = "movies";
        private const string GetMovieUriWithSlug = GetMovieUri + "/" + TestConstants.Movies.MovieSlug;

        [Theory]
        [InlineData(null, $"{GetMovieUri}/293990", "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetMovieUri}/293990", "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMovieUri}/293990?extended=full", "Movies\\movie.json")]
        public async Task TestGetMovieWithId(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktMovie> response = await client.Movies.GetMovieAsync(TestConstants.Movies.MovieID, extendedInfo);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktMovie movie = response.Content!;

            movie.Title.Should().Be("Guardians of the Galaxy Volume 3");
            movie.Year.Should().Be(2023U);
            movie.Ids!.Slug.Should().Be("guardians-of-the-galaxy-volume-3-2023");
        }

        [Theory]
        [InlineData(null, GetMovieUriWithSlug, "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.None, GetMovieUriWithSlug, "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMovieUriWithSlug}?extended=full", "Movies\\movie.json")]
        public async Task TestGetMovieWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktMovie> response = await client.Movies.GetMovieAsync(TestConstants.Movies.MovieSlug, extendedInfo);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktMovie movie = response.Content!;

            movie.Title.Should().Be("Guardians of the Galaxy Volume 3");
            movie.Year.Should().Be(2023U);
            movie.Ids!.Slug.Should().Be("guardians-of-the-galaxy-volume-3-2023");
        }

        [Theory]
        [InlineData(null, GetMovieUriWithSlug, "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.None, GetMovieUriWithSlug, "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMovieUriWithSlug}?extended=full", "Movies\\movie.json")]
        public async Task TestGetMovieWithIds(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktMovie> response = await client.Movies.GetMovieAsync(TestConstants.Movies.MovieIds, extendedInfo);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktMovie movie = response.Content!;

            movie.Title.Should().Be("Guardians of the Galaxy Volume 3");
            movie.Year.Should().Be(2023U);
            movie.Ids!.Slug.Should().Be("guardians-of-the-galaxy-volume-3-2023");
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
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetMovieWithIdThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieUri}/293990", statusCode);

            try
            {
                await client.Movies.GetMovieAsync(TestConstants.Movies.MovieID);
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
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetMovieWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieAsync(TestConstants.Movies.MovieSlug);
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
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetMovieWithIdsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieAsync(TestConstants.Movies.MovieIds);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task TestGetMovieWithIdsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movie_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieUriWithSlug, responseContent);

            var movieIds = new TraktMovieIds();

            Func<Task<TraktResponse<TraktMovie>>> act = () => client.Movies.GetMovieAsync(movieIds);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
