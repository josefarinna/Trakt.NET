using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieSentimentsTests
    {
        private const string GetMovieSentimentsUriPrefix = "movies";
        private const string GetMovieSentimentsUriSuffix = "sentiments";
        private static readonly string GetMovieSentimentsUri = $"{GetMovieSentimentsUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieSentimentsUriSuffix}";
        private static readonly string GetMovieSentimentsUriWithSlug = $"{GetMovieSentimentsUriPrefix}/{TestConstants.Movies.MovieSlug}/{GetMovieSentimentsUriSuffix}";

        [Fact]
        public async Task TestGetMovieSentimentsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviesentiments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieSentimentsUri, responseContent);

            TraktResponse<TraktSentiments> response = await client.Movies.GetMovieSentimentsAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktSentiments movieSentiments = response.Content!;

            movieSentiments.Good.ShouldNotBeNull();
            movieSentiments.Good!.Count.ShouldBe(1);
            movieSentiments.Good![0].Sentiment.ShouldBe("funny");
            movieSentiments.Bad.ShouldNotBeNull();
            movieSentiments.Bad!.Count.ShouldBe(1);
            movieSentiments.Bad![0].Sentiment.ShouldBe("boring");
            movieSentiments.CommentCount.ShouldBe(100U);
        }

        [Fact]
        public async Task TestGetMovieSentimentsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviesentiments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieSentimentsUriWithSlug, responseContent);

            TraktResponse<TraktSentiments> response = await client.Movies.GetMovieSentimentsAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktSentiments movieSentiments = response.Content!;

            movieSentiments.Good.ShouldNotBeNull();
            movieSentiments.Good!.Count.ShouldBe(1);
            movieSentiments.Good![0].Sentiment.ShouldBe("funny");
            movieSentiments.Bad.ShouldNotBeNull();
            movieSentiments.Bad!.Count.ShouldBe(1);
            movieSentiments.Bad![0].Sentiment.ShouldBe("boring");
            movieSentiments.CommentCount.ShouldBe(100U);
        }

        [Fact]
        public async Task TestGetMovieSentimentsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviesentiments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieSentimentsUriWithSlug, responseContent);

            TraktResponse<TraktSentiments> response = await client.Movies.GetMovieSentimentsAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktSentiments movieSentiments = response.Content!;

            movieSentiments.Good.ShouldNotBeNull();
            movieSentiments.Good!.Count.ShouldBe(1);
            movieSentiments.Good![0].Sentiment.ShouldBe("funny");
            movieSentiments.Bad.ShouldNotBeNull();
            movieSentiments.Bad!.Count.ShouldBe(1);
            movieSentiments.Bad![0].Sentiment.ShouldBe("boring");
            movieSentiments.CommentCount.ShouldBe(100U);
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
        public async Task TestGetMovieSentimentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieSentimentsUriWithSlug, statusCode);

            Func<Task<TraktResponse<TraktSentiments>>> act = () => client.Movies.GetMovieSentimentsAsync(TestConstants.Movies.MovieIDs, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMovieSentimentsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieSentimentsUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSentiments>>> act = () => client.Movies.GetMovieSentimentsAsync(default(TraktMovieIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieSentimentsAsync(movieIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
