using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktLastActivityTests
    {
        [Fact]
        public void TestTraktLastActivityToJson()
        {
            TraktLastActivity.Unspecified.ToJson().ShouldBeNull();
            TraktLastActivity.Collected.ToJson().ShouldBe("collected");
            TraktLastActivity.Aired.ToJson().ShouldBe("aired");
            TraktLastActivity.Watched.ToJson().ShouldBe("watched");
            ((TraktLastActivity)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktLastActivityFromJson()
        {
            "unspecified".ToTraktLastActivity().ShouldBe(TraktLastActivity.Unspecified);
            "collected".ToTraktLastActivity().ShouldBe(TraktLastActivity.Collected);
            "aired".ToTraktLastActivity().ShouldBe(TraktLastActivity.Aired);
            "watched".ToTraktLastActivity().ShouldBe(TraktLastActivity.Watched);

            string? nullValue = null;
            nullValue.ToTraktLastActivity().ShouldBe(TraktLastActivity.Unspecified);
            "invalid".ToTraktLastActivity().ShouldBe(TraktLastActivity.Unspecified);
            "".ToTraktLastActivity().ShouldBe(TraktLastActivity.Unspecified);
        }

        [Fact]
        public void TestTraktLastActivityDisplayName()
        {
            TraktLastActivity.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktLastActivity.Collected.DisplayName().ShouldBe("Collected");
            TraktLastActivity.Aired.DisplayName().ShouldBe("Aired");
            TraktLastActivity.Watched.DisplayName().ShouldBe("Watched");
            ((TraktLastActivity)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktLastActivityJsonConverter()
        {
            var converter = new TraktLastActivityJsonConverter();
            converter.CanConvert(typeof(TraktLastActivity)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktLastActivity.Collected, options).ShouldBe("\"collected\"");
            JsonSerializer.Deserialize<TraktLastActivity>("\"collected\"", options).ShouldBe(TraktLastActivity.Collected);
            JsonSerializer.Deserialize<TraktLastActivity>("\"\"", options).ShouldBe(TraktLastActivity.Unspecified);
        }
    }
}
