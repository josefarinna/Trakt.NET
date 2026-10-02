using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktVIPVeteranTitleTests
    {
        [Fact]
        public void TestTraktVIPVeteranTitleToJson()
        {
            TraktVIPVeteranTitle.Unspecified.ToJson().ShouldBeNull();
            TraktVIPVeteranTitle.Veteran.ToJson().ShouldBe("veteran");
            TraktVIPVeteranTitle.Legend.ToJson().ShouldBe("legend");
            ((TraktVIPVeteranTitle)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktVIPVeteranTitleFromJson()
        {
            "unspecified".ToTraktVIPVeteranTitle().ShouldBe(TraktVIPVeteranTitle.Unspecified);
            "veteran".ToTraktVIPVeteranTitle().ShouldBe(TraktVIPVeteranTitle.Veteran);
            "legend".ToTraktVIPVeteranTitle().ShouldBe(TraktVIPVeteranTitle.Legend);

            string? nullValue = null;
            nullValue.ToTraktVIPVeteranTitle().ShouldBe(TraktVIPVeteranTitle.Unspecified);
            "invalid".ToTraktVIPVeteranTitle().ShouldBe(TraktVIPVeteranTitle.Unspecified);
            "".ToTraktVIPVeteranTitle().ShouldBe(TraktVIPVeteranTitle.Unspecified);
        }

        [Fact]
        public void TestTraktVIPVeteranTitleDisplayName()
        {
            TraktVIPVeteranTitle.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktVIPVeteranTitle.Veteran.DisplayName().ShouldBe("Veteran");
            TraktVIPVeteranTitle.Legend.DisplayName().ShouldBe("Legend");
            ((TraktVIPVeteranTitle)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktVIPVeteranTitleJsonConverter()
        {
            var converter = new TraktVIPVeteranTitleJsonConverter();
            converter.CanConvert(typeof(TraktVIPVeteranTitle)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktVIPVeteranTitle.Veteran, options).ShouldBe("\"veteran\"");
            JsonSerializer.Deserialize<TraktVIPVeteranTitle>("\"veteran\"", options).ShouldBe(TraktVIPVeteranTitle.Veteran);
            JsonSerializer.Deserialize<TraktVIPVeteranTitle>("\"\"", options).ShouldBe(TraktVIPVeteranTitle.Unspecified);
        }
    }
}
