using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktUserSyncItemKindTests
    {
        [Fact]
        public void TestTraktUserSyncItemKindToJson()
        {
            TraktUserSyncItemKind.Unspecified.ToJson().ShouldBeNull();
            TraktUserSyncItemKind.History.ToJson().ShouldBe("history");
            TraktUserSyncItemKind.Rating.ToJson().ShouldBe("rating");
            ((TraktUserSyncItemKind)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktUserSyncItemKindFromJson()
        {
            "unspecified".ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.Unspecified);
            "history".ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.History);
            "rating".ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.Rating);

            string? nullValue = null;
            nullValue.ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.Unspecified);
            "invalid".ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.Unspecified);
            "".ToTraktUserSyncItemKind().ShouldBe(TraktUserSyncItemKind.Unspecified);
        }

        [Fact]
        public void TestTraktUserSyncItemKindDisplayName()
        {
            TraktUserSyncItemKind.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUserSyncItemKind.History.DisplayName().ShouldBe("History");
            TraktUserSyncItemKind.Rating.DisplayName().ShouldBe("Rating");
            ((TraktUserSyncItemKind)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktUserSyncItemKindJsonConverter()
        {
            var converter = new TraktUserSyncItemKindJsonConverter();
            converter.CanConvert(typeof(TraktUserSyncItemKind)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktUserSyncItemKind.History, options).ShouldBe("\"history\"");
            JsonSerializer.Deserialize<TraktUserSyncItemKind>("\"history\"", options).ShouldBe(TraktUserSyncItemKind.History);
            JsonSerializer.Deserialize<TraktUserSyncItemKind>("\"\"", options).ShouldBe(TraktUserSyncItemKind.Unspecified);
        }
    }
}
