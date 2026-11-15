using System.Net;

namespace TraktNET.GenresModule
{
    public sealed partial class GetMovieGenresTests
    {
        private const string MovieGenresUri = "genres/movies";

        [Theory]
        [InlineData(TraktExtendedInfo.Subgenres, $"{MovieGenresUri}?extended=subgenres", "Genres\\genresmovies_extended.json")]
        [InlineData(null, MovieGenresUri, "Genres\\genresmovies.json")]
        public async Task TestGetMovieGenres(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktGenre> response = await client.Genres.GetMovieGenresAsync(extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            List<TraktGenre> genres = [.. response.Content];
            genres.Count.ShouldBe(27);

            if (extendedInfo != null)
            {
                TraktGenre actionGenre = genres[0];
                actionGenre.Name.ShouldBe("Action");

                actionGenre.Subgenres.ShouldNotBeNull();
                actionGenre.Subgenres!.Count.ShouldBe(85);

                TraktSubgenre firstSub = actionGenre.Subgenres!.First();
                firstSub.Name.ShouldBe("19th Century");
            }
            else
            {
                genres[0].Name.ShouldBe("Action");
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMovieGenresThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(MovieGenresUri, statusCode);

            Func<Task<TraktListResponse<TraktGenre>>> act = () => client.Genres.GetMovieGenresAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
