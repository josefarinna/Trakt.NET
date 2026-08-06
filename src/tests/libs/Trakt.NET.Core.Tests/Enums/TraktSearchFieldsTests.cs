namespace TraktNET.Enums
{
    public sealed class TraktSearchFieldTests
    {
        [Fact]
        public void TestTraktSearchFieldToJson()
        {
            TraktSearchFields.Unspecified.ToJson().ShouldBeNull();
            TraktSearchFields.Title.ToJson().ShouldBe("title");
            TraktSearchFields.Tagline.ToJson().ShouldBe("tagline");
            TraktSearchFields.Overview.ToJson().ShouldBe("overview");
            TraktSearchFields.People.ToJson().ShouldBe("people");
            TraktSearchFields.Translations.ToJson().ShouldBe("translations");
            TraktSearchFields.Aliases.ToJson().ShouldBe("aliases");
            TraktSearchFields.Name.ToJson().ShouldBe("name");
            TraktSearchFields.Biography.ToJson().ShouldBe("biography");
            TraktSearchFields.Description.ToJson().ShouldBe("description");
        }

        [Fact]
        public void TestTraktSearchFieldFromJson()
        {
            "unspecified".ToTraktSearchFields().ShouldBe(TraktSearchFields.Unspecified);
            "title".ToTraktSearchFields().ShouldBe(TraktSearchFields.Title);
            "tagline".ToTraktSearchFields().ShouldBe(TraktSearchFields.Tagline);
            "overview".ToTraktSearchFields().ShouldBe(TraktSearchFields.Overview);
            "people".ToTraktSearchFields().ShouldBe(TraktSearchFields.People);
            "translations".ToTraktSearchFields().ShouldBe(TraktSearchFields.Translations);
            "aliases".ToTraktSearchFields().ShouldBe(TraktSearchFields.Aliases);
            "name".ToTraktSearchFields().ShouldBe(TraktSearchFields.Name);
            "biography".ToTraktSearchFields().ShouldBe(TraktSearchFields.Biography);
            "description".ToTraktSearchFields().ShouldBe(TraktSearchFields.Description);

            string? nullValue = null;
            nullValue.ToTraktSearchFields().ShouldBe(TraktSearchFields.Unspecified);
        }

        [Fact]
        public void TestTraktSearchFieldDisplayName()
        {
            TraktSearchFields.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSearchFields.Title.DisplayName().ShouldBe("Title");
            TraktSearchFields.Tagline.DisplayName().ShouldBe("Tagline");
            TraktSearchFields.Overview.DisplayName().ShouldBe("Overview");
            TraktSearchFields.People.DisplayName().ShouldBe("People");
            TraktSearchFields.Translations.DisplayName().ShouldBe("Translations");
            TraktSearchFields.Aliases.DisplayName().ShouldBe("Aliases");
            TraktSearchFields.Name.DisplayName().ShouldBe("Name");
            TraktSearchFields.Biography.DisplayName().ShouldBe("Biography");
            TraktSearchFields.Description.DisplayName().ShouldBe("Description");
        }
    }
}
