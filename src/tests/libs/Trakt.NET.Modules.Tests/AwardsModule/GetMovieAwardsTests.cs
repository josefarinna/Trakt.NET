using System.Net;

namespace TraktNET.AwardsModule
{
    public sealed class GetMovieAwardsTests
    {
        private const string GetMovieAwardsUriPrefix = "movies";
        private const string GetMovieAwardsUriSuffix = "awards";
        private static readonly string GetMovieAwardsUri = $"{GetMovieAwardsUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieAwardsUriSuffix}";
        private static readonly string GetMovieAwardsUriWithSlug = $"{GetMovieAwardsUriPrefix}/{TestConstants.Movies.MovieSlug}/{GetMovieAwardsUriSuffix}";

        [Fact]
        public async Task TestGetMovieAwardsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\movie_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAwardsUri, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Awards.GetMovieAwardsAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktTitleAward> movieAwards = response.Content!;

            TraktTitleAward award = movieAwards[0];
            award.Year.ShouldBe(2025U);
            award.Won.ShouldBe(true);
            award.Award.ShouldNotBeNull();
            award.Award.Slug.ShouldBe("best-motion-picture-of-the-year");
            award.Award.Name.ShouldBe("Best Motion Picture of the Year");
            award.Ceremony.ShouldNotBeNull();
            award.Ceremony.Slug.ShouldBe("oscars");
            award.Ceremony.Edition.ShouldBe(97U);
            award.Person.ShouldNotBeNull();
            award.Person.Name.ShouldBe("Christopher Nolan");

            award = movieAwards[1];
            award.Year.ShouldBe(2025U);
            award.Won.ShouldBe(false);
            award.Award.ShouldNotBeNull();
            award.Award.Slug.ShouldBe("best-achievement-in-directing");
            award.Person.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetMovieAwardsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\movie_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Awards.GetMovieAwardsAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetMovieAwardsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\movie_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAwardsUriWithSlug, responseContent);

            TraktListResponse<TraktTitleAward> response = await client.Awards.GetMovieAwardsAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieAwardsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAwardsUri, statusCode);

            Func<Task<TraktListResponse<TraktTitleAward>>> act = () => client.Awards.GetMovieAwardsAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetMovieAwardsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\movie_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAwardsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktTitleAward>>> act = () => client.Awards.GetMovieAwardsAsync(default(TraktMovieIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Awards.GetMovieAwardsAsync(movieIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task TestGetMovieAwardsThrowsRequestValidationException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Awards\\movie_awards.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAwardsUriWithSlug, responseContent);

            Func<Task<TraktListResponse<TraktTitleAward>>> act = () => client.Awards.GetMovieAwardsAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Awards.GetMovieAwardsAsync("  ", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Awards.GetMovieAwardsAsync("movie id with spaces", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
