namespace TraktNET.Json.People
{
    public sealed class TraktPersonShowCreditsCrewItemTests
    {
        [Fact]
        public void TestTraktPersonShowCreditsCrewItemDefaultConstructor()
        {
            var creditsCrewItem = new TraktPersonShowCreditsCrewItem();

            creditsCrewItem.Jobs.ShouldBeNull();
            creditsCrewItem.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonShowCreditsCrewItemFromJson()
        {
            TraktPersonShowCreditsCrewItem? creditsCrewItem = await TestUtility.DeserializeJsonAsync<TraktPersonShowCreditsCrewItem>("People\\personshowcreditscrewitem.json");

            creditsCrewItem.ShouldNotBeNull();
            creditsCrewItem.Jobs.ShouldNotBeNull();
            creditsCrewItem.Jobs.Count.ShouldBe(1);
            creditsCrewItem.Jobs.ShouldContain("Director");
            creditsCrewItem.Show.ShouldNotBeNull();
            creditsCrewItem.Show.Title.ShouldBe("Game of Thrones");
            creditsCrewItem.Show.Year.ShouldBe(2011U);
            creditsCrewItem.Show.Airs.ShouldBeNull();
            creditsCrewItem.Show.AvailableTranslations.ShouldBeNull();
            creditsCrewItem.Show.IDs.ShouldNotBeNull();
            creditsCrewItem.Show.IDs!.Trakt.ShouldBe(1390U);
            creditsCrewItem.Show.IDs!.Slug.ShouldBe("game-of-thrones");
            creditsCrewItem.Show.IDs!.TVDB.ShouldBe(121361U);
            creditsCrewItem.Show.IDs!.IMDB.ShouldBe("tt0944947");
            creditsCrewItem.Show.IDs!.TMDB.ShouldBe(1399U);
            creditsCrewItem.Show.Genres.ShouldBeNull();
            creditsCrewItem.Show.Overview.ShouldBeNullOrEmpty();
            creditsCrewItem.Show.FirstAired.ShouldBeNull();
            creditsCrewItem.Show.Runtime.ShouldBeNull();
            creditsCrewItem.Show.Certification.ShouldBeNullOrEmpty();
            creditsCrewItem.Show.Network.ShouldBeNullOrEmpty();
            creditsCrewItem.Show.Country.ShouldBeNullOrEmpty();
            creditsCrewItem.Show.UpdatedAt.ShouldBeNull();
            creditsCrewItem.Show.Trailer.ShouldBeNullOrEmpty();
            creditsCrewItem.Show.Homepage.ShouldBeNullOrEmpty();
            creditsCrewItem.Show.Status.ShouldBeNull();
            creditsCrewItem.Show.Rating.ShouldBeNull();
            creditsCrewItem.Show.Votes.ShouldBeNull();
            creditsCrewItem.Show.Language.ShouldBeNullOrEmpty();
            creditsCrewItem.Show.AiredEpisodes.ShouldBeNull();
        }
    }
}
