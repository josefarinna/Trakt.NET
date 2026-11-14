using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktAwardKindTests
    {
        [Fact]
        public void TestTraktAwardKindToJson()
        {
            TraktAwardKind.Unspecified.ToJson().ShouldBeNull();
            TraktAwardKind.Title.ToJson().ShouldBe("title");
            TraktAwardKind.Person.ToJson().ShouldBe("person");
            ((TraktAwardKind)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktAwardKindFromJson()
        {
            "unspecified".ToTraktAwardKind().ShouldBe(TraktAwardKind.Unspecified);
            "title".ToTraktAwardKind().ShouldBe(TraktAwardKind.Title);
            "person".ToTraktAwardKind().ShouldBe(TraktAwardKind.Person);

            string? nullValue = null;
            nullValue.ToTraktAwardKind().ShouldBe(TraktAwardKind.Unspecified);
            "invalid".ToTraktAwardKind().ShouldBe(TraktAwardKind.Unspecified);
            "".ToTraktAwardKind().ShouldBe(TraktAwardKind.Unspecified);
        }

        [Fact]
        public void TestTraktAwardKindDisplayName()
        {
            TraktAwardKind.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAwardKind.Title.DisplayName().ShouldBe("Title");
            TraktAwardKind.Person.DisplayName().ShouldBe("Person");
            ((TraktAwardKind)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktAwardKindJsonConverter()
        {
            var converter = new TraktAwardKindJsonConverter();
            converter.CanConvert(typeof(TraktAwardKind)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktAwardKind.Title, options).ShouldBe("\"title\"");
            JsonSerializer.Deserialize<TraktAwardKind>("\"title\"", options).ShouldBe(TraktAwardKind.Title);
            JsonSerializer.Deserialize<TraktAwardKind>("\"\"", options).ShouldBe(TraktAwardKind.Unspecified);
        }
    }
}
