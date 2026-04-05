namespace TraktNET.Json.People
{
    public sealed class TraktPersonMovieCreditsCastItemTests
    {
        [Fact]
        public void TestTraktPersonMovieCreditsCastItemDefaultConstructor()
        {
            var creditsCastItem = new TraktPersonMovieCreditsCastItem();

            creditsCastItem.Characters.ShouldBeNull();
            creditsCastItem.Movie.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonMovieCreditsCastItemFromJson()
        {
            TraktPersonMovieCreditsCastItem? creditsCastItem = await TestUtility.DeserializeJsonAsync<TraktPersonMovieCreditsCastItem>("People\\personmoviecreditscastitem.json");

            creditsCastItem.ShouldNotBeNull();
            creditsCastItem.Characters.ShouldNotBeNull();
            creditsCastItem.Characters.Count.ShouldBe(1);
            creditsCastItem.Characters.ShouldContain("Joe Brody");
            creditsCastItem.Movie.ShouldNotBeNull();
            creditsCastItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            creditsCastItem.Movie.Year.ShouldBe(2015U);
            creditsCastItem.Movie.IDs.ShouldNotBeNull();
            creditsCastItem.Movie.IDs!.Trakt.ShouldBe(94024U);
            creditsCastItem.Movie.IDs!.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            creditsCastItem.Movie.IDs!.IMDB.ShouldBe("tt2488496");
            creditsCastItem.Movie.IDs!.TMDB.ShouldBe(140607U);
            creditsCastItem.Movie.Tagline.ShouldBeNullOrEmpty();
            creditsCastItem.Movie.Overview.ShouldBeNullOrEmpty();
            creditsCastItem.Movie.Released.ShouldBeNull();
            creditsCastItem.Movie.Runtime.ShouldBeNull();
            creditsCastItem.Movie.UpdatedAt.ShouldBeNull();
            creditsCastItem.Movie.Trailer.ShouldBeNullOrEmpty();
            creditsCastItem.Movie.Homepage.ShouldBeNullOrEmpty();
            creditsCastItem.Movie.Rating.ShouldBeNull();
            creditsCastItem.Movie.Votes.ShouldBeNull();
            creditsCastItem.Movie.Language.ShouldBeNullOrEmpty();
            creditsCastItem.Movie.AvailableTranslations.ShouldBeNull();
            creditsCastItem.Movie.Genres.ShouldBeNull();
            creditsCastItem.Movie.Certification.ShouldBeNullOrEmpty();
        }
    }
}
