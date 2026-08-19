using System.Net;

namespace TraktNET.CheckinModule
{
    public sealed class CheckIntoMovieTests
    {
        private const string CheckinUri = "checkin";

        [Fact]
        public async Task TestCheckIntoMovie()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Checkin\\checkinmovie_response.json");
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, responseContent);

            var movieCheckin = new TraktMovieCheckin
            {
                Movie = new TraktMovie
                {
                    Title = "Guardians of the Galaxy",
                    Year = 2014U,
                    IDs = new TraktMovieIDs
                    {
                        Trakt = 28U,
                        Slug = "guardians-of-the-galaxy-2014",
                        IMDB = "tt2015381",
                        TMDB = 118340U
                    }
                },
                Message = "Guardians of the Galaxy FTW!",
                Sharing = new TraktConnections { Twitter = true, Tumblr = false }
            };

            TraktResponse<TraktMovieCheckinResponse> response = await client.Checkins.CheckIntoMovieAsync(movieCheckin, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            TraktMovieCheckinResponse responseData = response.Content!;
            responseData.ID.ShouldBe(3373536619UL);
            responseData.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-06T01:11:37.000Z"));

            responseData.Movie.ShouldNotBeNull();
            responseData.Movie!.Title.ShouldBe("Guardians of the Galaxy");
            responseData.Movie!.Year.ShouldBe(2014U);
            responseData.Movie!.IDs!.Trakt.ShouldBe(28U);

            responseData.Sharing.ShouldNotBeNull();
            responseData.Sharing!.Twitter.ShouldBe(true);
            responseData.Sharing!.Tumblr.ShouldBe(false);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiCheckinException))]
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
        public async Task TestCheckIntoMovieThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, statusCode);
            var movieCheckin = new TraktMovieCheckin { Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 28U } } };

            try
            {
                await client.Checkins.CheckIntoMovieAsync(movieCheckin, cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestCheckIntoMovieThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, "{}");

            Func<Task<TraktResponse<TraktMovieCheckinResponse>>> act = () => client.Checkins.CheckIntoMovieAsync(null!);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            var movieCheckin = new TraktMovieCheckin { Movie = null! };
            act = () => client.Checkins.CheckIntoMovieAsync(movieCheckin);
            await act.ShouldThrowAsync<ArgumentException>();

            movieCheckin = new TraktMovieCheckin { Movie = new TraktMovie { IDs = null! } };
            act = () => client.Checkins.CheckIntoMovieAsync(movieCheckin);
            await act.ShouldThrowAsync<ArgumentException>();

            movieCheckin = new TraktMovieCheckin { Movie = new TraktMovie { IDs = new TraktMovieIDs() } };
            act = () => client.Checkins.CheckIntoMovieAsync(movieCheckin);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
