using System.Net;

namespace TraktNET.GenresModule
{
    public sealed partial class GetShowGenresTests
    {
        private const string ShowGenresUri = "genres/shows";

        [Theory]
        [InlineData(TraktExtendedInfo.Subgenres, $"{ShowGenresUri}?extended=subgenres", "Genres\\genresshows_extended.json")]
        [InlineData(null, ShowGenresUri, "Genres\\genresshows.json")]
        public async Task TestGetShowGenres(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktGenre> response = await client.Genres.GetShowGenresAsync(extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            List<TraktGenre> genres = [.. response.Content];
            genres.Count.ShouldBe(37);

            if (extendedInfo != null)
            {
                TraktGenre actionGenre = genres[0];
                actionGenre.Name.ShouldBe("Action");

                actionGenre.Subgenres.ShouldNotBeNull();
                actionGenre.Subgenres.Count.ShouldBe(85);

                TraktSubgenre firstSub = actionGenre.Subgenres.First();
                firstSub.Name.ShouldBe("19th Century");
            }
            else
            {
                genres[0].Name.ShouldBe("Action");
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetShowGenresThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(ShowGenresUri, statusCode);

            Func<Task<TraktListResponse<TraktGenre>>> act = () => client.Genres.GetShowGenresAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
