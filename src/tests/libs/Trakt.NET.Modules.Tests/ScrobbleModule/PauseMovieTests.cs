using System.Net;

namespace TraktNET.ScrobbleModule
{
    public sealed class PauseMovieTests
    {
        private readonly string ScrobblePauseUri = "scrobble/pause";
        private const float PauseProgress = 75.0f;

        [Fact]
        public async Task TestPauseMovie()
        {
            var content = new TraktMovieScrobblePost
            {
                Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } },
                Progress = PauseProgress
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Scrobbles\\moviepausescrobbleresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobblePauseUri, responseContent, null, null, null, null);
            TraktResponse<TraktMovieScrobblePostResponse> response = await client.Scrobble.PauseMovieAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktMovieScrobblePostResponse responseValue = response.Content;

            responseValue.ID.ShouldBe(0U);
            responseValue.Action.ShouldBe(TraktScrobbleActionType.Pause);
            responseValue.Progress.ShouldBe(PauseProgress);
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
        public async Task TestPauseMovieThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobblePauseUri, statusCode);

            var content = new TraktMovieScrobblePost
            {
                Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } },
                Progress = PauseProgress
            };

            Func<Task<TraktResponse<TraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(content, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestPauseMovieThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobblePauseUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(default, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            var content = new TraktMovieScrobblePost { Progress = PauseProgress };
            act = () => client.Scrobble.PauseMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movie = new TraktMovie();
            act = () => client.Scrobble.PauseMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movie.IDs = new TraktMovieIDs();
            act = () => client.Scrobble.PauseMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
