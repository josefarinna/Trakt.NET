using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieAliasesTests
    {
        private const string GetMovieAliasesUriPrefix = "movies";
        private const string GetMovieAliasesUriSuffix = "aliases";
        private static readonly string GetMovieAliasesUri = $"{GetMovieAliasesUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieAliasesUriSuffix}";
        private static readonly string GetMovieAliasesUriWithSlug = $"{GetMovieAliasesUriPrefix}/{TestConstants.Movies.MovieSlug}/{GetMovieAliasesUriSuffix}";

        [Fact]
        public async Task TestGetMovieAliasesWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviealiases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAliasesUri, responseContent);

            TraktListResponse<TraktMovieAlias> response = await client.Movies.GetMovieAliasesAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieAlias> movieAliases = response.Content;

            TraktMovieAlias movieAlias = movieAliases[0];

            movieAlias.Title.ShouldBe("Les Gardiens de la Galaxie 3");
            movieAlias.Country.ShouldBe("fr");

            movieAlias = movieAliases[1];

            movieAlias.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieAlias.Country.ShouldBe("us");
        }

        [Fact]
        public async Task TestGetMovieAliasesWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviealiases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAliasesUriWithSlug, responseContent);

            TraktListResponse<TraktMovieAlias> response = await client.Movies.GetMovieAliasesAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieAlias> movieAliases = response.Content;

            TraktMovieAlias movieAlias = movieAliases[0];

            movieAlias.Title.ShouldBe("Les Gardiens de la Galaxie 3");
            movieAlias.Country.ShouldBe("fr");

            movieAlias = movieAliases[1];

            movieAlias.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieAlias.Country.ShouldBe("us");
        }

        [Fact]
        public async Task TestGetMovieAliasesWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviealiases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAliasesUriWithSlug, responseContent);

            TraktListResponse<TraktMovieAlias> response = await client.Movies.GetMovieAliasesAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieAlias> movieAliases = response.Content;

            TraktMovieAlias movieAlias = movieAliases[0];

            movieAlias.Title.ShouldBe("Les Gardiens de la Galaxie 3");
            movieAlias.Country.ShouldBe("fr");

            movieAlias = movieAliases[1];

            movieAlias.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieAlias.Country.ShouldBe("us");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieAliasesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAliasesUri, statusCode);

            Func<Task<TraktListResponse<TraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieAliasesWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviealiases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieAliasesUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(default(TraktMovieIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieAliasesAsync(movieIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
