namespace TraktNET.Enums
{
    public sealed class TraktSearchFieldTests
    {
        [Fact]
        public void TestTraktSearchFieldToJson()
        {
            TraktSearchField.Unspecified.ToJson().Should().BeNull();
            TraktSearchField.Title.ToJson().Should().Be("title");
            TraktSearchField.Tagline.ToJson().Should().Be("tagline");
            TraktSearchField.Overview.ToJson().Should().Be("overview");
            TraktSearchField.People.ToJson().Should().Be("people");
            TraktSearchField.Translations.ToJson().Should().Be("translations");
            TraktSearchField.Aliases.ToJson().Should().Be("aliases");
            TraktSearchField.Name.ToJson().Should().Be("name");
            TraktSearchField.Biography.ToJson().Should().Be("biography");
            TraktSearchField.Description.ToJson().Should().Be("description");
        }

        [Fact]
        public void TestTraktSearchFieldFromJson()
        {
            "unspecified".ToTraktSearchField().Should().Be(TraktSearchField.Unspecified);
            "title".ToTraktSearchField().Should().Be(TraktSearchField.Title);
            "tagline".ToTraktSearchField().Should().Be(TraktSearchField.Tagline);
            "overview".ToTraktSearchField().Should().Be(TraktSearchField.Overview);
            "people".ToTraktSearchField().Should().Be(TraktSearchField.People);
            "translations".ToTraktSearchField().Should().Be(TraktSearchField.Translations);
            "aliases".ToTraktSearchField().Should().Be(TraktSearchField.Aliases);
            "name".ToTraktSearchField().Should().Be(TraktSearchField.Name);
            "biography".ToTraktSearchField().Should().Be(TraktSearchField.Biography);
            "description".ToTraktSearchField().Should().Be(TraktSearchField.Description);

            string? nullValue = null;
            nullValue.ToTraktSearchField().Should().Be(TraktSearchField.Unspecified);
        }

        [Fact]
        public void TestTraktSearchFieldDisplayName()
        {
            TraktSearchField.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktSearchField.Title.DisplayName().Should().Be("Title");
            TraktSearchField.Tagline.DisplayName().Should().Be("Tagline");
            TraktSearchField.Overview.DisplayName().Should().Be("Overview");
            TraktSearchField.People.DisplayName().Should().Be("People");
            TraktSearchField.Translations.DisplayName().Should().Be("Translations");
            TraktSearchField.Aliases.DisplayName().Should().Be("Aliases");
            TraktSearchField.Name.DisplayName().Should().Be("Name");
            TraktSearchField.Biography.DisplayName().Should().Be("Biography");
            TraktSearchField.Description.DisplayName().Should().Be("Description");
        }
    }
}
