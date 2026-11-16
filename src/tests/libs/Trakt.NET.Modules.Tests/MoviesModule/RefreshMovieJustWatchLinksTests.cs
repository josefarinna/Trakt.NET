using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class RefreshMovieJustWatchLinksTests
    {
        private const string RefreshMovieUri = $"movies/{TestConstants.Movies.MovieID}/refresh/justwatch";
        private const string RefreshMovieUriWithSlug = $"movies/{TestConstants.Movies.MovieSlug}/refresh/justwatch";

        [Fact]
        public async Task TestRefreshMovieJustWatchLinksWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUri, HttpStatusCode.Created);

            TraktResponse response = await client.Movies.RefreshMovieJustWatchLinksAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshMovieJustWatchLinksWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Movies.RefreshMovieJustWatchLinksAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshMovieJustWatchLinksWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Movies.RefreshMovieJustWatchLinksAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestRefreshMovieJustWatchLinksThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Movies.RefreshMovieJustWatchLinksAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshMovieJustWatchLinksThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshMovieUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Movies.RefreshMovieJustWatchLinksAsync(default(TraktMovieIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.RefreshMovieJustWatchLinksAsync(new TraktMovieIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.RefreshMovieJustWatchLinksAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
