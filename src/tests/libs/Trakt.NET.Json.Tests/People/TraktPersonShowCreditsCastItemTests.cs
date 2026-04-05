namespace TraktNET.Json.People
{
    public sealed class TraktPersonShowCreditsCastItemTests
    {
        [Fact]
        public void TestTraktPersonShowCreditsCastItemDefaultConstructor()
        {
            var creditsCastItem = new TraktPersonShowCreditsCastItem();

            creditsCastItem.Characters.ShouldBeNull();
            creditsCastItem.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonShowCreditsCastItemFromJson()
        {
            TraktPersonShowCreditsCastItem? creditsCastItem = await TestUtility.DeserializeJsonAsync<TraktPersonShowCreditsCastItem>("People\\personshowcreditscastitem.json");

            creditsCastItem.ShouldNotBeNull();
            creditsCastItem.Characters.ShouldNotBeNull();
            creditsCastItem.Characters!.Count.ShouldBe(1);
            creditsCastItem.Characters!.ShouldContain("Joe Brody");
            creditsCastItem.Show.ShouldNotBeNull();
            creditsCastItem.Show!.Title.ShouldBe("Game of Thrones");
            creditsCastItem.Show!.Year.ShouldBe(2011U);
            creditsCastItem.Show!.Airs.ShouldBeNull();
            creditsCastItem.Show!.AvailableTranslations.ShouldBeNull();
            creditsCastItem.Show!.IDs.ShouldNotBeNull();
            creditsCastItem.Show!.IDs!.Trakt.ShouldBe(1390U);
            creditsCastItem.Show!.IDs!.Slug.ShouldBe("game-of-thrones");
            creditsCastItem.Show!.IDs!.TVDB.ShouldBe(121361U);
            creditsCastItem.Show!.IDs!.IMDB.ShouldBe("tt0944947");
            creditsCastItem.Show!.IDs!.TMDB.ShouldBe(1399U);
            creditsCastItem.Show!.Genres.ShouldBeNull();
            creditsCastItem.Show!.Overview.ShouldBeNullOrEmpty();
            creditsCastItem.Show!.FirstAired.ShouldBeNull();
            creditsCastItem.Show!.Runtime.ShouldBeNull();
            creditsCastItem.Show!.Certification.ShouldBeNullOrEmpty();
            creditsCastItem.Show!.Network.ShouldBeNullOrEmpty();
            creditsCastItem.Show!.Country.ShouldBeNullOrEmpty();
            creditsCastItem.Show!.UpdatedAt.ShouldBeNull();
            creditsCastItem.Show!.Trailer.ShouldBeNullOrEmpty();
            creditsCastItem.Show!.Homepage.ShouldBeNullOrEmpty();
            creditsCastItem.Show!.Status.ShouldBeNull();
            creditsCastItem.Show!.Rating.ShouldBeNull();
            creditsCastItem.Show!.Votes.ShouldBeNull();
            creditsCastItem.Show!.Language.ShouldBeNullOrEmpty();
            creditsCastItem.Show!.AiredEpisodes.ShouldBeNull();
        }
    }
}
