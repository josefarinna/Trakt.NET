namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieReleaseTests
    {
        [Fact]
        public void TestTraktMovieReleaseConstructor()
        {
            var movieRelease = new TraktMovieRelease();

            movieRelease.Country.Should().BeNull();
            movieRelease.Certification.Should().BeNull();
            movieRelease.ReleaseDate.Should().BeNull();
            movieRelease.ReleaseType.Should().BeNull();
            movieRelease.Note.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktMovieReleaseFromJson()
        {
            TraktMovieRelease? movieRelease = await TestUtility.DeserializeJsonAsync<TraktMovieRelease>("Movies\\movierelease.json");

            movieRelease.Should().NotBeNull();

            movieRelease!.Country.Should().Be("fr");
            movieRelease!.Certification.Should().Be("12");

#if NET7_0_OR_GREATER
            movieRelease!.ReleaseDate.Should().Be(TestUtility.ParseDate("2023-04-22"));
#else
            movieRelease!.ReleaseDate.Should().Be(TestUtility.ParseUTCDateTime("2023-04-22T00:00:00.000Z"));
#endif

            movieRelease!.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            movieRelease!.Note.Should().Be("Disneyland Paris");
        }

        [Fact]
        public async Task TestTraktMovieReleasesFromJson()
        {
            IReadOnlyList<TraktMovieRelease>? movieReleases = await TestUtility.DeserializeJsonListAsync<TraktMovieRelease>("Movies\\moviereleases.json");

            movieReleases.Should().NotBeNull().And.HaveCount(2);

            TraktMovieRelease movieRelease = movieReleases![0];

            movieRelease.Should().NotBeNull();

            movieRelease.Country.Should().Be("fr");
            movieRelease.Certification.Should().Be("12");

#if NET7_0_OR_GREATER
            movieRelease.ReleaseDate.Should().Be(TestUtility.ParseDate("2023-04-22"));
#else
            movieRelease.ReleaseDate.Should().Be(TestUtility.ParseUTCDateTime("2023-04-22T00:00:00.000Z"));
#endif

            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            movieRelease.Note.Should().Be("Disneyland Paris");

            // --------------------------------------------------------------------------------------------

            movieRelease = movieReleases![1];

            movieRelease.Should().NotBeNull();

            movieRelease.Country.Should().Be("us");
            movieRelease.Certification.Should().Be("PG-13");

#if NET7_0_OR_GREATER
            movieRelease.ReleaseDate.Should().Be(TestUtility.ParseDate("2023-04-27"));
#else
            movieRelease.ReleaseDate.Should().Be(TestUtility.ParseUTCDateTime("2023-04-27T00:00:00.000Z"));
#endif

            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            movieRelease.Note.Should().Be("El Capitan Theatre");
        }
    }
}
