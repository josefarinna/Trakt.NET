namespace TraktNET.Enums
{
    public sealed class TraktSearchFieldTests
    {
        [Fact]
        public void TestTraktSearchFieldToJson()
        {
            TraktSearchField.Unspecified.ToJson().ShouldBeNull();
            TraktSearchField.Title.ToJson().ShouldBe("title");
            TraktSearchField.Tagline.ToJson().ShouldBe("tagline");
            TraktSearchField.Overview.ToJson().ShouldBe("overview");
            TraktSearchField.People.ToJson().ShouldBe("people");
            TraktSearchField.Translations.ToJson().ShouldBe("translations");
            TraktSearchField.Aliases.ToJson().ShouldBe("aliases");
            TraktSearchField.Name.ToJson().ShouldBe("name");
            TraktSearchField.Biography.ToJson().ShouldBe("biography");
            TraktSearchField.Description.ToJson().ShouldBe("description");
        }

        [Fact]
        public void TestTraktSearchFieldFromJson()
        {
            "unspecified".ToTraktSearchField().ShouldBe(TraktSearchField.Unspecified);
            "title".ToTraktSearchField().ShouldBe(TraktSearchField.Title);
            "tagline".ToTraktSearchField().ShouldBe(TraktSearchField.Tagline);
            "overview".ToTraktSearchField().ShouldBe(TraktSearchField.Overview);
            "people".ToTraktSearchField().ShouldBe(TraktSearchField.People);
            "translations".ToTraktSearchField().ShouldBe(TraktSearchField.Translations);
            "aliases".ToTraktSearchField().ShouldBe(TraktSearchField.Aliases);
            "name".ToTraktSearchField().ShouldBe(TraktSearchField.Name);
            "biography".ToTraktSearchField().ShouldBe(TraktSearchField.Biography);
            "description".ToTraktSearchField().ShouldBe(TraktSearchField.Description);

            string? nullValue = null;
            nullValue.ToTraktSearchField().ShouldBe(TraktSearchField.Unspecified);
        }

        [Fact]
        public void TestTraktSearchFieldDisplayName()
        {
            TraktSearchField.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSearchField.Title.DisplayName().ShouldBe("Title");
            TraktSearchField.Tagline.DisplayName().ShouldBe("Tagline");
            TraktSearchField.Overview.DisplayName().ShouldBe("Overview");
            TraktSearchField.People.DisplayName().ShouldBe("People");
            TraktSearchField.Translations.DisplayName().ShouldBe("Translations");
            TraktSearchField.Aliases.DisplayName().ShouldBe("Aliases");
            TraktSearchField.Name.DisplayName().ShouldBe("Name");
            TraktSearchField.Biography.DisplayName().ShouldBe("Biography");
            TraktSearchField.Description.DisplayName().ShouldBe("Description");
        }
    }
}
