#if !NET8_0_OR_GREATER
namespace TraktNET.Json
{
    public sealed class LowerSnakeCaseJsonNamingPolicyTests
    {
        private static readonly LowerSnakeCaseJsonNamingPolicy s_policy = new();

        [Theory]
        [InlineData("", "")]
        [InlineData("name", "name")]
        [InlineData("Name", "name")]
        [InlineData("camelCase", "camel_case")]
        [InlineData("PascalCase", "pascal_case")]
        [InlineData("XMLReader", "xml_reader")]
        [InlineData("SHA512Hash", "sha512_hash")]
        [InlineData("ABc", "a_bc")]
        [InlineData("already_snake_case", "already_snake_case")]
        [InlineData("ABC???def", "abc???def")]
        [InlineData("  Leading And Trailing Spaces  ", "leading_and_trailing_spaces")]
        [InlineData("multiple   spaces", "multiple_spaces")]
        public void TestConvertName(string name, string expected)
            => s_policy.ConvertName(name).ShouldBe(expected);

        [Theory]
        [InlineData(53)]
        [InlineData(100)]
        public void TestConvertLongName(int wordCount)
        {
            // Each "Ab" word results in "ab" with a separator in between, so the result
            // exceeds the initially allocated buffer and requires it to be expanded.
            string name = string.Concat(Enumerable.Repeat("Ab", wordCount));
            string expected = string.Join("_", Enumerable.Repeat("ab", wordCount));

            s_policy.ConvertName(name).ShouldBe(expected);
        }

        [Fact]
        public void TestConvertNameThrowsArgumentNullException()
            => Should.Throw<ArgumentNullException>(() => s_policy.ConvertName(null!));
    }
}
#endif
