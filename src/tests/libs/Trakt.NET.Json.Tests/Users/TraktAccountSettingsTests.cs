namespace TraktNET.Json.Users
{
    public sealed class TraktAccountSettingsTests
    {
        [Fact]
        public void TestTraktAccountSettingsDefaultConstructor()
        {
            var accountSettings = new TraktAccountSettings();

            accountSettings.Timezone.ShouldBeNull();
            accountSettings.Time24Hr.ShouldBeNull();
            accountSettings.CoverImage.ShouldBeNull();
            accountSettings.Token.ShouldBeNull();
            accountSettings.DateFormat.ShouldBeNull();
            accountSettings.DisplayAds.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktAccountSettingsFromJson()
        {
            TraktAccountSettings? accountSettings = await TestUtility.DeserializeJsonAsync<TraktAccountSettings>("Users\\accountsettings.json");

            accountSettings.ShouldNotBeNull();
            accountSettings.Timezone.ShouldBe("America/Los_Angeles");
            accountSettings.Time24Hr.ShouldBe(true);
            accountSettings.CoverImage.ShouldBe("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            accountSettings.Token.ShouldBe("60fa34c4f5e7f093ecc5a2d16d691e24");
            accountSettings.DateFormat.ShouldBe(TraktDateFormat.DayMonthYear);
            accountSettings.DisplayAds.ShouldBe(true);
        }
    }
}
