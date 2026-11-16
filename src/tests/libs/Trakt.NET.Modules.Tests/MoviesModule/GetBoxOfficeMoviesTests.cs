using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetBoxOfficeMoviesTests
    {
        private const string GetBoxOfficeMoviesUri = "movies/boxoffice";

        [Theory]
        [InlineData(null, GetBoxOfficeMoviesUri, "Movies\\boxofficemovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, GetBoxOfficeMoviesUri, "Movies\\boxofficemovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetBoxOfficeMoviesUri}?extended=full", "Movies\\boxofficemovies.json")]
        public async Task TestGetBoxOfficeMovies(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktBoxOfficeMovie> response = await client.Movies.GetBoxOfficeMoviesAsync(extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktBoxOfficeMovie> boxOfficeMovies = response.Content;

            TraktBoxOfficeMovie boxOfficeMovie = boxOfficeMovies[0];

            boxOfficeMovie.Title.ShouldBe("Beetlejuice Beetlejuice");
            boxOfficeMovie.Year.ShouldBe(2024U);
            boxOfficeMovie.IDs!.Slug.ShouldBe("beetlejuice-beetlejuice-2024");

            boxOfficeMovie = boxOfficeMovies[1];

            boxOfficeMovie.Title.ShouldBe("Speak No Evil");
            boxOfficeMovie.Year.ShouldBe(2024U);
            boxOfficeMovie.IDs!.Slug.ShouldBe("speak-no-evil-2024");
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetBoxOfficeMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetBoxOfficeMoviesUri, statusCode);

            Func<Task<TraktListResponse<TraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }
    }
}
