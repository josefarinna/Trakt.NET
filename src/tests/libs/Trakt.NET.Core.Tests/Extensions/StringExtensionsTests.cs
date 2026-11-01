namespace TraktNET.Extensions
{
    public sealed class StringExtensionsTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("one", 1)]
        [InlineData("one two", 2)]
        [InlineData("one, two. three: four; five\nsix\tseven", 7)]
        [InlineData("  one  ,  two  ", 2)]
        public void TestWordCount(string value, int expected)
            => value.WordCount().ShouldBe(expected);

        [Theory]
        [InlineData("one two", true)]
        [InlineData("one", false)]
        public void TestContainsSpace(string value, bool expected)
            => value.ContainsSpace().ShouldBe(expected);
    }
}
