using System.Net;

namespace TraktNET.ScrobbleModule
{
    public sealed class StartMovieTests
    {
        private readonly string ScrobbleStartUri = "scrobble/start";
        private const float StartProgress = 10.0f;

        [Fact]
        public async Task TestStartMovie()
        {
            var content = new TraktMovieScrobblePost
            {
                Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } },
                Progress = StartProgress
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Scrobbles\\moviestartscrobbleresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStartUri, responseContent, null, null, null, null);
            TraktResponse<TraktMovieScrobblePostResponse> response = await client.Scrobble.StartMovieAsync(content, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktMovieScrobblePostResponse responseValue = response.Content;

            responseValue.ID.ShouldBe(0U);
            responseValue.Action.ShouldBe(TraktScrobbleActionType.Start);
            responseValue.Progress.ShouldBe(StartProgress);
            responseValue.Sharing.ShouldNotBeNull();
            responseValue.Sharing.Twitter.ShouldBe(true);
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
        public async Task TestStartMovieThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStartUri, statusCode);

            var content = new TraktMovieScrobblePost
            {
                Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } },
                Progress = StartProgress
            };

            Func<Task<TraktResponse<TraktMovieScrobblePostResponse>>> act = () => client.Scrobble.StartMovieAsync(content, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestStartMovieThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ScrobbleStartUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktMovieScrobblePostResponse>>> act = () => client.Scrobble.StartMovieAsync(default, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            var content = new TraktMovieScrobblePost { Progress = StartProgress };
            act = () => client.Scrobble.StartMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movie = new TraktMovie();
            act = () => client.Scrobble.StartMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            content.Movie.IDs = new TraktMovieIDs();
            act = () => client.Scrobble.StartMovieAsync(content, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
