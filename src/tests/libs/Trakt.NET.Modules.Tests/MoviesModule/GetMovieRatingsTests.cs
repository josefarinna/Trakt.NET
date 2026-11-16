using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieRatingsTests
    {
        private const string GetMovieRatingsUri = $"movies/{TestConstants.Movies.MovieID}/ratings";
        private const string GetMovieRatingsUriWithSlug = $"movies/{TestConstants.Movies.MovieSlug}/ratings";

        [Theory]
        [InlineData(null, GetMovieRatingsUri)]
        [InlineData(TraktExtendedInfo.None, GetMovieRatingsUri)]
        [InlineData(TraktExtendedInfo.All, $"{GetMovieRatingsUri}?extended=all")]
        public async Task TestGetMovieRatingsWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movieratings.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.TraktMovieID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktRating movieRatings = response.Content;

            movieRatings.Rating.ShouldBe(7.96017f);
            movieRatings.Votes.ShouldBe(18906U);
        }

        [Theory]
        [InlineData(null, GetMovieRatingsUriWithSlug)]
        public async Task TestGetMovieRatingsWithSlug(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movieratings.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.MovieSlug, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktRating movieRatings = response.Content;

            movieRatings.Rating.ShouldBe(7.96017f);
            movieRatings.Votes.ShouldBe(18906U);
        }

        [Theory]
        [InlineData(null, GetMovieRatingsUriWithSlug)]
        public async Task TestGetMovieRatingsWithIDs(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movieratings.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktRating> response = await client.Movies.GetMovieRatingsAsync(TestConstants.Movies.MovieIDs, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktRating movieRatings = response.Content;

            movieRatings.Rating.ShouldBe(7.96017f);
            movieRatings.Votes.ShouldBe(18906U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieRatingsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUri, statusCode);

            Func<Task<TraktResponse<TraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieRatingsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movieratings.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRatingsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(default(TraktMovieIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieRatingsAsync(movieIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
