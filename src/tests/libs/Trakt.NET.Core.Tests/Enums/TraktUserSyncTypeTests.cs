using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktUserSyncTypeTests
    {
        [Fact]
        public void TestTraktUserSyncTypeToJson()
        {
            TraktUserSyncType.Unspecified.ToJson().ShouldBeNull();
            TraktUserSyncType.Younify.ToJson().ShouldBe("younify");
            TraktUserSyncType.Plex.ToJson().ShouldBe("plex");
            TraktUserSyncType.Import.ToJson().ShouldBe("import");
            ((TraktUserSyncType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktUserSyncTypeFromJson()
        {
            "unspecified".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Unspecified);
            "younify".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Younify);
            "plex".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Plex);
            "import".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Import);

            string? nullValue = null;
            nullValue.ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Unspecified);
            "invalid".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Unspecified);
            "".ToTraktUserSyncType().ShouldBe(TraktUserSyncType.Unspecified);
        }

        [Fact]
        public void TestTraktUserSyncTypeDisplayName()
        {
            TraktUserSyncType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUserSyncType.Younify.DisplayName().ShouldBe("Younify");
            TraktUserSyncType.Plex.DisplayName().ShouldBe("Plex");
            TraktUserSyncType.Import.DisplayName().ShouldBe("Import");
            ((TraktUserSyncType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktUserSyncTypeJsonConverter()
        {
            var converter = new TraktUserSyncTypeJsonConverter();
            converter.CanConvert(typeof(TraktUserSyncType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktUserSyncType.Younify, options).ShouldBe("\"younify\"");
            JsonSerializer.Deserialize<TraktUserSyncType>("\"younify\"", options).ShouldBe(TraktUserSyncType.Younify);
            JsonSerializer.Deserialize<TraktUserSyncType>("\"\"", options).ShouldBe(TraktUserSyncType.Unspecified);
        }
    }
}
