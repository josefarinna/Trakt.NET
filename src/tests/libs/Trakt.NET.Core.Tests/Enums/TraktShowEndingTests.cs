using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktShowEndingTests
    {
        [Fact]
        public void TestTraktShowEndingToJson()
        {
            TraktShowEnding.Unspecified.ToJson().ShouldBeNull();
            TraktShowEnding.Concluded.ToJson().ShouldBe("concluded");
            TraktShowEnding.Open.ToJson().ShouldBe("open");
            ((TraktShowEnding)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktShowEndingFromJson()
        {
            "unspecified".ToTraktShowEnding().ShouldBe(TraktShowEnding.Unspecified);
            "concluded".ToTraktShowEnding().ShouldBe(TraktShowEnding.Concluded);
            "open".ToTraktShowEnding().ShouldBe(TraktShowEnding.Open);

            string? nullValue = null;
            nullValue.ToTraktShowEnding().ShouldBe(TraktShowEnding.Unspecified);
            "invalid".ToTraktShowEnding().ShouldBe(TraktShowEnding.Unspecified);
            "".ToTraktShowEnding().ShouldBe(TraktShowEnding.Unspecified);
        }

        [Fact]
        public void TestTraktShowEndingDisplayName()
        {
            TraktShowEnding.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktShowEnding.Concluded.DisplayName().ShouldBe("Concluded");
            TraktShowEnding.Open.DisplayName().ShouldBe("Open");
            ((TraktShowEnding)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktShowEndingJsonConverter()
        {
            var converter = new TraktShowEndingJsonConverter();
            converter.CanConvert(typeof(TraktShowEnding)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktShowEnding.Concluded, options).ShouldBe("\"concluded\"");
            JsonSerializer.Deserialize<TraktShowEnding>("\"concluded\"", options).ShouldBe(TraktShowEnding.Concluded);
            JsonSerializer.Deserialize<TraktShowEnding>("\"\"", options).ShouldBe(TraktShowEnding.Unspecified);
        }
    }
}
