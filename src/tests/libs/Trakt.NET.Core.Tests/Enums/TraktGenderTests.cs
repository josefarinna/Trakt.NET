using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktGenderTests
    {
        [Fact]
        public void TestTraktGenderToJson()
        {
            TraktGender.Unspecified.ToJson().ShouldBeNull();
            TraktGender.Male.ToJson().ShouldBe("male");
            TraktGender.Female.ToJson().ShouldBe("female");
            TraktGender.NonBinary.ToJson().ShouldBe("non_binary");
            ((TraktGender)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktGenderFromJson()
        {
            "unspecified".ToTraktGender().ShouldBe(TraktGender.Unspecified);
            "male".ToTraktGender().ShouldBe(TraktGender.Male);
            "female".ToTraktGender().ShouldBe(TraktGender.Female);
            "non_binary".ToTraktGender().ShouldBe(TraktGender.NonBinary);

            string? nullValue = null;
            nullValue.ToTraktGender().ShouldBe(TraktGender.Unspecified);
            "invalid".ToTraktGender().ShouldBe(TraktGender.Unspecified);
            "".ToTraktGender().ShouldBe(TraktGender.Unspecified);
        }

        [Fact]
        public void TestTraktGenderDisplayName()
        {
            TraktGender.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktGender.Male.DisplayName().ShouldBe("Male");
            TraktGender.Female.DisplayName().ShouldBe("Female");
            TraktGender.NonBinary.DisplayName().ShouldBe("Non Binary");
            ((TraktGender)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktGenderJsonConverter()
        {
            var converter = new TraktGenderJsonConverter();
            converter.CanConvert(typeof(TraktGender)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktGender.Male, options).ShouldBe("\"male\"");
            JsonSerializer.Deserialize<TraktGender>("\"male\"", options).ShouldBe(TraktGender.Male);
            JsonSerializer.Deserialize<TraktGender>("\"\"", options).ShouldBe(TraktGender.Unspecified);
        }
    }
}
