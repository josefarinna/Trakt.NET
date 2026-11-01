#if NET6_0_OR_GREATER
using System.Text.Json;

namespace TraktNET.Json
{
    public sealed class TimeOnlyJsonConverterTests
    {
        private static readonly JsonSerializerOptions s_options = new() { Converters = { new TimeOnlyJsonConverter() } };

        [Theory]
        [InlineData("\"20:30\"", 20, 30, 0)]
        [InlineData("\"20:30:15\"", 20, 30, 15)]
        [InlineData("\"\"", 0, 0, 0)]
        public void TestRead(string json, int hour, int minute, int second)
            => JsonSerializer.Deserialize<TimeOnly>(json, s_options).ShouldBe(new TimeOnly(hour, minute, second));

        [Fact]
        public void TestWrite()
            => JsonSerializer.Serialize(new TimeOnly(20, 30, 15), s_options).ShouldBe("\"20:30\"");
    }
}
#endif
