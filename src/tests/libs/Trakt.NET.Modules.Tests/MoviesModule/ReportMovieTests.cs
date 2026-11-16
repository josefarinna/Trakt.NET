using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class ReportMovieTests
    {
        private const string ReportMovieUri = $"movies/{TestConstants.Movies.MovieID}/report";
        private const string ReportMovieUriWithSlug = $"movies/{TestConstants.Movies.MovieSlug}/report";

        [Fact]
        public async Task TestReportMovieWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportMovieUri, HttpStatusCode.Created);

            TraktResponse response = await client.Movies.ReportMovieAsync(TestConstants.Movies.TraktMovieID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportMovieWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportMovieUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Movies.ReportMovieAsync(TestConstants.Movies.MovieSlug, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportMovieWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportMovieUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Movies.ReportMovieAsync(TestConstants.Movies.MovieIDs, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestReportMovieThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportMovieUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Movies.ReportMovieAsync(TestConstants.Movies.TraktMovieID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportMovieThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportMovieUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Movies.ReportMovieAsync(default(TraktMovieIDs)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Movies.ReportMovieAsync(new TraktMovieIDs(), TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.ReportMovieAsync(0, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Movies.ReportMovieAsync(default(string)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Movies.ReportMovieAsync(string.Empty, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Movies.ReportMovieAsync("movie id", TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportMovieThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportMovieUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Movies.ReportMovieAsync(TestConstants.Movies.MovieSlug, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Movies.ReportMovieAsync(TestConstants.Movies.MovieSlug, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Movies.ReportMovieAsync(TestConstants.Movies.MovieSlug, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
