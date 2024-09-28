using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieRatingsTests
    {
        private const string GetMovieRatingsUriPrefix = "movies";
        private const string GetMovieRatingsUriSuffix = "ratings";
        private static readonly string GetMovieRatingsUri = $"{GetMovieRatingsUriPrefix}/{TestConstants.Movies.MovieID}/{GetMovieRatingsUriSuffix}";
        private static readonly string GetMovieRatingsUriWithSlug = $"{GetMovieRatingsUriPrefix}/{TestConstants.Movies.MovieSlug}/{GetMovieRatingsUriSuffix}";

        [Fact]
        public async Task TestGetMovieRatingsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movieratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUri, responseContent);

            TraktResponse<TraktRating> response = await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.MovieID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktRating movieRatings = response.Content!;

            movieRatings.Rating.Should().Be(7.96017f);
            movieRatings.Votes.Should().Be(18906U);
        }

        [Fact]
        public async Task TestGetMovieRatingsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movieratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUriWithSlug, responseContent);

            TraktResponse<TraktRating> response = await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.MovieSlug);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktRating movieRatings = response.Content!;

            movieRatings.Rating.Should().Be(7.96017f);
            movieRatings.Votes.Should().Be(18906U);
        }

        [Fact]
        public async Task TestGetMovieRatingsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movieratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUriWithSlug, responseContent);

            TraktResponse<TraktRating> response = await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.MovieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();

            TraktRating movieRatings = response.Content!;

            movieRatings.Rating.Should().Be(7.96017f);
            movieRatings.Votes.Should().Be(18906U);
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
        public async Task TestGetMovieRatingsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUri, statusCode);

            try
            {
                await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.MovieID);
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
        public async Task TestGetMovieRatingsWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.MovieSlug);
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
        public async Task TestGetMovieRatingsWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.MovieIds);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task TestGetMovieRatingsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movieratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(default(TraktMovieIds));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.Should().ThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIds();

            act = () => client.Movies.GetMovieRatingsAsync(movieIDs);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
