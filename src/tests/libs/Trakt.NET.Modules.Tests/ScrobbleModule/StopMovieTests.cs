using System.Net;

namespace TraktNET.ScrobbleModule
{
    public sealed class StopMovieTests
    {
        private readonly string ScrobbleStopUri = "scrobble/stop";
        private const float StopProgress = 85.0f;

        [Fact]
        public async Task TestStopMovie()
        {
            var content = new TraktMovieScrobblePost
            {
                Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } },
                Progress = StopProgress
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Scrobbles\\moviestopscrobbleresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStopUri, responseContent, null, null, null, null);
            TraktResponse<TraktMovieScrobblePostResponse> response = await client.Scrobble.StopMovieAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktMovieScrobblePostResponse responseValue = response.Content;

            responseValue.ID.ShouldBe(3373536622U);
            responseValue.Action.ShouldBe(TraktScrobbleActionType.Stop);
            responseValue.Progress.ShouldBe(StopProgress);
            responseValue.Sharing.ShouldNotBeNull();
            responseValue.Sharing.Twitter.ShouldBe(false);
            responseValue.Sharing.Tumblr.ShouldBe(false);
            responseValue.Movie.ShouldNotBeNull();
            responseValue.Movie.Title.ShouldBe("Guardians of the Galaxy");
            responseValue.Movie.Year.ShouldBe(2014U);
            responseValue.Movie.IDs.ShouldNotBeNull();
            responseValue.Movie.IDs!.Trakt.ShouldBe(28U);
            responseValue.Movie.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-2014");
            responseValue.Movie.IDs!.IMDB.ShouldBe("tt2015381");
            responseValue.Movie.IDs!.TMDB.ShouldBe(118340U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        public async Task TestStopMovieThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStopUri, statusCode);

            var content = new TraktMovieScrobblePost
            {
                Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } },
                Progress = StopProgress
            };

            Func<Task<TraktResponse<TraktMovieScrobblePostResponse>>> act = () => client.Scrobble.StopMovieAsync(content, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestStopMovieThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStopUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktMovieScrobblePostResponse>>> act = () => client.Scrobble.StopMovieAsync(default!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var content = new TraktMovieScrobblePost { Progress = StopProgress };
            act = () => client.Scrobble.StopMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movie = new TraktMovie();
            act = () => client.Scrobble.StopMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movie.IDs = new TraktMovieIDs();
            act = () => client.Scrobble.StopMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
