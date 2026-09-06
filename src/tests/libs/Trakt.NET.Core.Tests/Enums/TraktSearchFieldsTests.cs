using System.Text.Json;

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
            TraktSearchFields titleAndOverview = TraktSearchFields.Title | TraktSearchFields.Overview;
            titleAndOverview.ToJson().ShouldBeNull();
            ((TraktSearchFields)9999).ToJson().ShouldBeNull();
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
            "invalid".ToTraktSearchFields().ShouldBe(TraktSearchFields.Unspecified);
            "".ToTraktSearchFields().ShouldBe(TraktSearchFields.Unspecified);
        }

        [Fact]
        public void TestTraktSearchFieldsToURI()
        {
            TraktSearchFields.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktSearchFields.Title.ToURI().ShouldBe("title");
            TraktSearchFields.Tagline.ToURI().ShouldBe("tagline");
            TraktSearchFields.Overview.ToURI().ShouldBe("overview");
            TraktSearchFields.People.ToURI().ShouldBe("people");
            TraktSearchFields.Translations.ToURI().ShouldBe("translations");
            TraktSearchFields.Aliases.ToURI().ShouldBe("aliases");
            TraktSearchFields.Name.ToURI().ShouldBe("name");
            TraktSearchFields.Biography.ToURI().ShouldBe("biography");
            TraktSearchFields.Description.ToURI().ShouldBe("description");
            TraktSearchFields titleAndOverview = TraktSearchFields.Title | TraktSearchFields.Overview;
            titleAndOverview.ToURI().ShouldBe(string.Empty);
            ((TraktSearchFields)9999).ToURI().ShouldBe(string.Empty);
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
            TraktSearchFields titleAndOverview = TraktSearchFields.Title | TraktSearchFields.Overview;
            titleAndOverview.DisplayName().ShouldBe("Title, Overview");
            TraktSearchFields multiple = TraktSearchFields.People | TraktSearchFields.Translations | TraktSearchFields.Aliases;
            multiple.DisplayName().ShouldBe("People, Translations, Aliases");
            TraktSearchFields names = TraktSearchFields.Name | TraktSearchFields.Biography | TraktSearchFields.Description;
            names.DisplayName().ShouldBe("Name, Biography, Description");
            ((TraktSearchFields)1024).DisplayName().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktSearchFieldsHasFlagSet()
        {
            TraktSearchFields.Unspecified.HasFlagSet(TraktSearchFields.Unspecified).ShouldBeTrue();
            TraktSearchFields.Unspecified.HasFlagSet(TraktSearchFields.Title).ShouldBeFalse();
            TraktSearchFields title = TraktSearchFields.Title;
            title.HasFlagSet(TraktSearchFields.Unspecified).ShouldBeTrue();
            title.HasFlagSet(TraktSearchFields.Title).ShouldBeTrue();
            title.HasFlagSet(TraktSearchFields.Overview).ShouldBeFalse();
            TraktSearchFields combined = TraktSearchFields.Title | TraktSearchFields.Overview;
            combined.HasFlagSet(TraktSearchFields.Unspecified).ShouldBeTrue();
            combined.HasFlagSet(TraktSearchFields.Title).ShouldBeTrue();
            combined.HasFlagSet(TraktSearchFields.Overview).ShouldBeTrue();
            combined.HasFlagSet(TraktSearchFields.People).ShouldBeFalse();
            combined.HasFlagSet(TraktSearchFields.Title | TraktSearchFields.Overview).ShouldBeTrue();
            combined.HasFlagSet(TraktSearchFields.Title | TraktSearchFields.People).ShouldBeFalse();
        }

        [Fact]
        public void TestTraktSearchFieldsAsQuery()
        {
            TraktSearchFields.Unspecified.AsQuery().ShouldBe(string.Empty);
            TraktSearchFields.Title.AsQuery().ShouldBe("fields=title");
            TraktSearchFields.Tagline.AsQuery().ShouldBe("fields=tagline");
            TraktSearchFields.Overview.AsQuery().ShouldBe("fields=overview");
            TraktSearchFields.People.AsQuery().ShouldBe("fields=people");
            TraktSearchFields.Translations.AsQuery().ShouldBe("fields=translations");
            TraktSearchFields.Aliases.AsQuery().ShouldBe("fields=aliases");
            TraktSearchFields.Name.AsQuery().ShouldBe("fields=name");
            TraktSearchFields.Biography.AsQuery().ShouldBe("fields=biography");
            TraktSearchFields.Description.AsQuery().ShouldBe("fields=description");

            TraktSearchFields titleAndOverview = TraktSearchFields.Title | TraktSearchFields.Overview;
            titleAndOverview.AsQuery().ShouldBe("fields=title,overview");

            TraktSearchFields multiple = TraktSearchFields.People | TraktSearchFields.Translations | TraktSearchFields.Aliases;
            multiple.AsQuery().ShouldBe("fields=people,translations,aliases");

            TraktSearchFields names = TraktSearchFields.Name | TraktSearchFields.Biography | TraktSearchFields.Description;
            names.AsQuery().ShouldBe("fields=name,biography,description");
        }

        [Fact]
        public void TestTraktSearchFieldsJsonConverter()
        {
            var converter = new TraktSearchFieldsJsonConverter();
            converter.CanConvert(typeof(TraktSearchFields)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSearchFields.Title, options).ShouldBe("\"title\"");
            JsonSerializer.Serialize(TraktSearchFields.Title | TraktSearchFields.Overview, options).ShouldBe("null");
            JsonSerializer.Deserialize<TraktSearchFields>("\"title\"", options).ShouldBe(TraktSearchFields.Title);
            JsonSerializer.Deserialize<TraktSearchFields>("\"\"", options).ShouldBe(TraktSearchFields.Unspecified);
            JsonSerializer.Deserialize<TraktSearchFields>("\"invalid\"", options).ShouldBe(TraktSearchFields.Unspecified);
        }
    }
}
