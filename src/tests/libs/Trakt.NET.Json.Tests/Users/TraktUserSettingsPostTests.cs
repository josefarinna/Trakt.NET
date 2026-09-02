namespace TraktNET.Json.Users
{
    public sealed class TraktUserSettingsPostTests
    {
        [Fact]
        public void TestTraktUserSettingsPostConstructor()
        {
            var post = new TraktUserSettingsPost();

            post.User.ShouldBeNull();
            post.Browsing.ShouldBeNull();
        }

        [Fact]
        public void TestTraktUserSettingsBrowsingPostConstructor()
        {
            var browsing = new TraktUserSettingsBrowsingPost();

            browsing.ShowRatingPrompt.ShouldBeNull();
            browsing.Locale.ShouldBeNull();
            browsing.Watchnow.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserSettingsPostFromJson()
        {
            TraktUserSettingsPost? post = await TestUtility.DeserializeJsonAsync<TraktUserSettingsPost>("Users\\usersettingspost.json");

            post.ShouldNotBeNull();
            
            // User
            post.User.ShouldNotBeNull();
            post.User.Name.ShouldBe("Sean New Name");
            post.User.About.ShouldBe("New about section text");
            post.User.Location.ShouldBe("Paris, France");
            post.User.Private.ShouldBe(true);
            post.User.Dob.ShouldBe("1990-05-15");

            // Browsing
            post.Browsing.ShouldNotBeNull();
            post.Browsing.ShowRatingPrompt.ShouldBe(true);
            post.Browsing.Locale.ShouldBe("fr-FR");
            post.Browsing.Watchnow.ShouldNotBeNull();
            post.Browsing.Watchnow.Country.ShouldBe("fr");
            post.Browsing.Watchnow.Favorites.ShouldNotBeNull();
            post.Browsing.Watchnow.Favorites.ShouldBe([ "netflix" ]);
            post.Browsing.Watchnow.OnlyFavorites.ShouldBe(true);
        }
    }
}
