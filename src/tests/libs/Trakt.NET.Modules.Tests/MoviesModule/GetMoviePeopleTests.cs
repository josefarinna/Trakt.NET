using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMoviePeopleTests
    {
        private const string GetMoviePeopleUriPrefix = "movies";
        private const string GetMoviePeopleUriSuffix = "people";
        private const string GetMoviePeopleUriWithSlug = GetMoviePeopleUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMoviePeopleUriSuffix;
        private static readonly string GetMoviePeopleUri = $"{GetMoviePeopleUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMoviePeopleUriSuffix}";

        [Theory]
        [InlineData(null, $"{GetMoviePeopleUriPrefix}/293990/{GetMoviePeopleUriSuffix}", "Movies\\moviepeople.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetMoviePeopleUriPrefix}/293990/{GetMoviePeopleUriSuffix}", "Movies\\moviepeople.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMoviePeopleUriPrefix}/293990/{GetMoviePeopleUriSuffix}?extended=full", "Movies\\moviepeople.json")]
        public async Task TestGetMoviePeopleWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.TraktMovieID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktCastAndCrew moviePeople = response.Content!;

            moviePeople.Cast.ShouldNotBeNull();
            moviePeople.Cast![0].Person.ShouldNotBeNull();
            moviePeople.Cast[0].Person!.Name.ShouldBe("Chris Pratt");

            moviePeople.Crew.ShouldNotBeNull();
            moviePeople.Crew!.Directing.ShouldNotBeNull();
            moviePeople.Crew.Directing![0].Person.ShouldNotBeNull();
            moviePeople.Crew.Directing![0].Person!.Name.ShouldBe("Kera Dacy");
        }

        [Theory]
        [InlineData(null, GetMoviePeopleUriWithSlug, "Movies\\moviepeople.json")]
        public async Task TestGetMoviePeopleWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.MovieSlug, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktCastAndCrew moviePeople = response.Content!;

            moviePeople.Cast.ShouldNotBeNull();
            moviePeople.Cast![0].Person.ShouldNotBeNull();
            moviePeople.Cast[0].Person!.Name.ShouldBe("Chris Pratt");

            moviePeople.Crew.ShouldNotBeNull();
            moviePeople.Crew!.Directing.ShouldNotBeNull();
            moviePeople.Crew.Directing![0].Person.ShouldNotBeNull();
            moviePeople.Crew.Directing![0].Person!.Name.ShouldBe("Kera Dacy");
        }

        [Theory]
        [InlineData(null, GetMoviePeopleUriWithSlug, "Movies\\moviepeople.json")]
        public async Task TestGetMoviePeopleWithIDs(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(TestConstants.Movies.MovieIDs, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktCastAndCrew moviePeople = response.Content!;

            moviePeople.Cast.ShouldNotBeNull();
            moviePeople.Cast![0].Person.ShouldNotBeNull();
            moviePeople.Cast[0].Person!.Name.ShouldBe("Chris Pratt");

            moviePeople.Crew.ShouldNotBeNull();
            moviePeople.Crew!.Directing.ShouldNotBeNull();
            moviePeople.Crew.Directing![0].Person.ShouldNotBeNull();
            moviePeople.Crew.Directing![0].Person!.Name.ShouldBe("Kera Dacy");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMoviePeopleWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMoviePeopleUri, statusCode);

            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMoviePeopleWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviepeople.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMoviePeopleUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(default(TraktMovieIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMoviePeopleAsync(movieIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
