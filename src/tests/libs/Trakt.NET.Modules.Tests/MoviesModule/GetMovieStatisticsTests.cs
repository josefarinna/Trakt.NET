using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieStatisticsTests
    {
        private const string GetMovieStatisticsUriPrefix = "movies";
        private const string GetMovieStatisticsUriSuffix = "stats";
        private static readonly string GetMovieStatisticsUri = $"{GetMovieStatisticsUriPrefix}/{TestConstants.Movies.MovieID}/{GetMovieStatisticsUriSuffix}";
        private static readonly string GetMovieStatisticsUriWithSlug = $"{GetMovieStatisticsUriPrefix}/{TestConstants.Movies.MovieSlug}/{GetMovieStatisticsUriSuffix}";

        [Fact]
        public async Task TestGetMovieStatisticsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUri, responseContent);

            TraktResponse<TraktMovieStatistics> response = await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.MovieID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktMovieStatistics movieStatistics = response.Content!;

            movieStatistics.Watchers.Should().Be(164943U);
            movieStatistics.Plays.Should().Be(219925U);
        }

        [Fact]
        public async Task TestGetMovieStatisticsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktMovieStatistics> response = await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.MovieSlug);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktMovieStatistics movieStatistics = response.Content!;

            movieStatistics.Watchers.Should().Be(164943U);
            movieStatistics.Plays.Should().Be(219925U);
        }

        [Fact]
        public async Task TestGetMovieStatisticsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktMovieStatistics> response = await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.MovieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktMovieStatistics movieStatistics = response.Content!;

            movieStatistics.Watchers.Should().Be(164943U);
            movieStatistics.Plays.Should().Be(219925U);
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
        public async Task TestGetMovieStatisticsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUri, statusCode);

            try
            {
                await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.MovieID);
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
        public async Task TestGetMovieStatisticsWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.MovieSlug);
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
        public async Task TestGetMovieStatisticsWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.MovieIds);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task TestGetMovieStatisticsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktMovieStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(default(TraktMovieIds));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.Should().ThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIds();

            act = () => client.Movies.GetMovieStatisticsAsync(movieIDs);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
