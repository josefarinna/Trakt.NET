namespace TraktNET.Json.People
{
    public sealed class TraktPersonMovieCreditsCrewItemTests
    {
        [Fact]
        public void TestTraktPersonMovieCreditsCrewItemDefaultConstructor()
        {
            var creditsCrewItem = new TraktPersonMovieCreditsCrewItem();

            creditsCrewItem.Jobs.ShouldBeNull();
            creditsCrewItem.Movie.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonMovieCreditsCrewItemFromJson()
        {
            TraktPersonMovieCreditsCrewItem? creditsCrewItem = await TestUtility.DeserializeJsonAsync<TraktPersonMovieCreditsCrewItem>("People\\personmoviecreditscrewitem.json");

            creditsCrewItem.ShouldNotBeNull();
            creditsCrewItem.Jobs.ShouldNotBeNull();
            creditsCrewItem.Jobs.Count.ShouldBe(1);
            creditsCrewItem.Jobs.ShouldContain("Director");
            creditsCrewItem.Movie.ShouldNotBeNull();
            creditsCrewItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            creditsCrewItem.Movie.Year.ShouldBe(2015U);
            creditsCrewItem.Movie.IDs.ShouldNotBeNull();
            creditsCrewItem.Movie.IDs!.Trakt.ShouldBe(94024U);
            creditsCrewItem.Movie.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            creditsCrewItem.Movie.IDs!.IMDB.ShouldBe("tt2488496");
            creditsCrewItem.Movie.IDs!.TMDB.ShouldBe(140607U);
            creditsCrewItem.Movie.Tagline.ShouldBeNullOrEmpty();
            creditsCrewItem.Movie.Overview.ShouldBeNullOrEmpty();
            creditsCrewItem.Movie.Released.ShouldBeNull();
            creditsCrewItem.Movie.Runtime.ShouldBeNull();
            creditsCrewItem.Movie.UpdatedAt.ShouldBeNull();
            creditsCrewItem.Movie.Trailer.ShouldBeNullOrEmpty();
            creditsCrewItem.Movie.Homepage.ShouldBeNullOrEmpty();
            creditsCrewItem.Movie.Rating.ShouldBeNull();
            creditsCrewItem.Movie.Votes.ShouldBeNull();
            creditsCrewItem.Movie.Language.ShouldBeNullOrEmpty();
            creditsCrewItem.Movie.AvailableTranslations.ShouldBeNull();
            creditsCrewItem.Movie.Genres.ShouldBeNull();
            creditsCrewItem.Movie.Certification.ShouldBeNullOrEmpty();
        }
    }
}
