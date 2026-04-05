using System.Globalization;
using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class HideUserMovieRecommendationTests
    {
        private readonly string HideMovieRecommendationUri = $"recommendations/movies/{TestConstants.Movies.MovieID}";

        [Fact]
        public async Task TestHideMovieRecommendation()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideMovieRecommendationUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(TestConstants.Movies.MovieID.ToString(CultureInfo.InvariantCulture), TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideMovieRecommendationRatingsWithTraktID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideMovieRecommendationUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(TestConstants.Movies.MovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideMovieRecommendationRatingsWithMovieIdsTraktID()
        {
            var movieIds = new TraktMovieIDs
            {
                Trakt = TestConstants.Movies.MovieID
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(HideMovieRecommendationUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(movieIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideMovieRecommendationRatingsWithMovieIdsSlug()
        {
            var movieIds = new TraktMovieIDs
            {
                Slug = TestConstants.Movies.MovieSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/movies/{TestConstants.Movies.MovieSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(movieIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideMovieRecommendationRatingsWithMovieIds()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/movies/{TestConstants.Movies.MovieSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideMovieRecommendationRatingsWithMovie()
        {
            var movie = new TraktMovie
            {
                IDs = TestConstants.Movies.MovieIDs
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/movies/{TestConstants.Movies.MovieSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(movie, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
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
        public async Task TestGetShowRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideMovieRecommendationUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Recommendations.HideMovieRecommendationAsync(TestConstants.Movies.MovieID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMovieRatingsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideMovieRecommendationUri, HttpStatusCode.NoContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse>> act = () => client.Recommendations.HideMovieRecommendationAsync(default(TraktMovieIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

#pragma warning disable CS8625
            act = () => client.Recommendations.HideMovieRecommendationAsync(default(TraktMovie), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(new TraktMovieIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
