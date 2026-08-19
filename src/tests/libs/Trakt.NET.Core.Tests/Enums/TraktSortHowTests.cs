using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSortHowTests
    {
        [Fact]
        public void TestTraktSortHowToJson()
        {
            TraktSortHow.Unspecified.ToJson().ShouldBeNull();
            TraktSortHow.Ascending.ToJson().ShouldBe("asc");
            TraktSortHow.Descending.ToJson().ShouldBe("desc");
            ((TraktSortHow)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSortHowFromJson()
        {
            "unspecified".ToTraktSortHow().ShouldBe(TraktSortHow.Unspecified);
            "asc".ToTraktSortHow().ShouldBe(TraktSortHow.Ascending);
            "desc".ToTraktSortHow().ShouldBe(TraktSortHow.Descending);

            string? nullValue = null;
            nullValue.ToTraktSortHow().ShouldBe(TraktSortHow.Unspecified);
            "invalid".ToTraktSortHow().ShouldBe(TraktSortHow.Unspecified);
            "".ToTraktSortHow().ShouldBe(TraktSortHow.Unspecified);
        }

        [Fact]
        public void TestTraktSortHowDisplayName()
        {
            TraktSortHow.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSortHow.Ascending.DisplayName().ShouldBe("Ascending");
            TraktSortHow.Descending.DisplayName().ShouldBe("Descending");
            ((TraktSortHow)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSortHowJsonConverter()
        {
            var converter = new TraktSortHowJsonConverter();
            converter.CanConvert(typeof(TraktSortHow)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSortHow.Ascending, options).ShouldBe("\"asc\"");
            JsonSerializer.Deserialize<TraktSortHow>("\"asc\"", options).ShouldBe(TraktSortHow.Ascending);
            JsonSerializer.Deserialize<TraktSortHow>("\"\"", options).ShouldBe(TraktSortHow.Unspecified);
        }
    }
}
