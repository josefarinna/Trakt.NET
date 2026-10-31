using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktVipVeteranTitleTests
    {
        [Fact]
        public void TestTraktVipVeteranTitleToJson()
        {
            TraktVipVeteranTitle.Unspecified.ToJson().ShouldBeNull();
            TraktVipVeteranTitle.Veteran.ToJson().ShouldBe("veteran");
            TraktVipVeteranTitle.Legend.ToJson().ShouldBe("legend");
            ((TraktVipVeteranTitle)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktVipVeteranTitleFromJson()
        {
            "unspecified".ToTraktVipVeteranTitle().ShouldBe(TraktVipVeteranTitle.Unspecified);
            "veteran".ToTraktVipVeteranTitle().ShouldBe(TraktVipVeteranTitle.Veteran);
            "legend".ToTraktVipVeteranTitle().ShouldBe(TraktVipVeteranTitle.Legend);

            string? nullValue = null;
            nullValue.ToTraktVipVeteranTitle().ShouldBe(TraktVipVeteranTitle.Unspecified);
            "invalid".ToTraktVipVeteranTitle().ShouldBe(TraktVipVeteranTitle.Unspecified);
            "".ToTraktVipVeteranTitle().ShouldBe(TraktVipVeteranTitle.Unspecified);
        }

        [Fact]
        public void TestTraktVipVeteranTitleDisplayName()
        {
            TraktVipVeteranTitle.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktVipVeteranTitle.Veteran.DisplayName().ShouldBe("Veteran");
            TraktVipVeteranTitle.Legend.DisplayName().ShouldBe("Legend");
            ((TraktVipVeteranTitle)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktVipVeteranTitleJsonConverter()
        {
            var converter = new TraktVipVeteranTitleJsonConverter();
            converter.CanConvert(typeof(TraktVipVeteranTitle)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktVipVeteranTitle.Veteran, options).ShouldBe("\"veteran\"");
            JsonSerializer.Deserialize<TraktVipVeteranTitle>("\"veteran\"", options).ShouldBe(TraktVipVeteranTitle.Veteran);
            JsonSerializer.Deserialize<TraktVipVeteranTitle>("\"\"", options).ShouldBe(TraktVipVeteranTitle.Unspecified);
        }
    }
}
