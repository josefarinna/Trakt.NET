using System.Net;

#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

using System.Text;

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
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktMovieCheckinResponse responseData = response.Content;
            responseData.ID.ShouldBe(3373536619UL);
            responseData.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-06T01:11:37.000Z"));

            responseData.Movie.ShouldNotBeNull();
            responseData.Movie.Title.ShouldBe("Guardians of the Galaxy");
            responseData.Movie.Year.ShouldBe(2014U);
            responseData.Movie!.IDs!.Trakt.ShouldBe(28U);

            responseData.Sharing.ShouldNotBeNull();
            responseData.Sharing.Twitter.ShouldBe(true);
            responseData.Sharing.Tumblr.ShouldBe(false);
        }

        [Fact]
        public async Task TestCheckIntoMovieCreated()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Checkin\\checkinmovie_response.json");
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, _ => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
            });

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
            response.IsSuccess.ShouldBeTrue();
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktMovieCheckinResponse responseData = response.Content;
            responseData.ID.ShouldBe(3373536619UL);
            responseData.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-06T01:11:37.000Z"));

            responseData.Movie.ShouldNotBeNull();
            responseData.Movie.Title.ShouldBe("Guardians of the Galaxy");
            responseData.Movie.Year.ShouldBe(2014U);
            responseData.Movie!.IDs!.Trakt.ShouldBe(28U);

            responseData.Sharing.ShouldNotBeNull();
            responseData.Sharing.Twitter.ShouldBe(true);
            responseData.Sharing.Tumblr.ShouldBe(false);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiCheckinException))]
        public async Task TestCheckIntoMovieThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(CheckinUri, statusCode);
            var movieCheckin = new TraktMovieCheckin { Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 28U } } };

            Func<Task<TraktResponse<TraktMovieCheckinResponse>>> act = () => client.Checkins.CheckIntoMovieAsync(movieCheckin, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
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
