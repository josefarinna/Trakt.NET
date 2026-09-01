using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktFilterOperatorTests
    {
        [Fact]
        public void TestTraktFilterOperatorToJson()
        {
            TraktFilterOperator.Unspecified.ToJson().ShouldBeNull();
            TraktFilterOperator.And.ToJson().ShouldBe("and");
            TraktFilterOperator.Or.ToJson().ShouldBe("or");
            ((TraktFilterOperator)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktFilterOperatorFromJson()
        {
            "unspecified".ToTraktFilterOperator().ShouldBe(TraktFilterOperator.Unspecified);
            "and".ToTraktFilterOperator().ShouldBe(TraktFilterOperator.And);
            "or".ToTraktFilterOperator().ShouldBe(TraktFilterOperator.Or);

            string? nullValue = null;
            nullValue.ToTraktFilterOperator().ShouldBe(TraktFilterOperator.Unspecified);
            "invalid".ToTraktFilterOperator().ShouldBe(TraktFilterOperator.Unspecified);
            "".ToTraktFilterOperator().ShouldBe(TraktFilterOperator.Unspecified);
        }

        [Fact]
        public void TestTraktFilterOperatorDisplayName()
        {
            TraktFilterOperator.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktFilterOperator.And.DisplayName().ShouldBe("And");
            TraktFilterOperator.Or.DisplayName().ShouldBe("Or");
            ((TraktFilterOperator)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktFilterOperatorJsonConverter()
        {
            var converter = new TraktFilterOperatorJsonConverter();
            converter.CanConvert(typeof(TraktFilterOperator)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktFilterOperator.And, options).ShouldBe("\"and\"");
            JsonSerializer.Deserialize<TraktFilterOperator>("\"and\"", options).ShouldBe(TraktFilterOperator.And);
            JsonSerializer.Deserialize<TraktFilterOperator>("\"\"", options).ShouldBe(TraktFilterOperator.Unspecified);
        }
    }
}

