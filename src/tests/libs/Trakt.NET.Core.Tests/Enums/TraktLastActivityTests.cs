namespace TraktNET.Enums
{
    public sealed class TraktLastActivityTests
    {
        [Fact]
        public void TestTraktLastActivityToJson()
        {
            TraktLastActivity.Unspecified.ToJson().Should().BeNull();
            TraktLastActivity.Collected.ToJson().Should().Be("collected");
            TraktLastActivity.Aired.ToJson().Should().Be("aired");
            TraktLastActivity.Watched.ToJson().Should().Be("watched");
        }

        [Fact]
        public void TestTraktLastActivityFromJson()
        {
            "unspecified".ToTraktLastActivity().Should().Be(TraktLastActivity.Unspecified);
            "collected".ToTraktLastActivity().Should().Be(TraktLastActivity.Collected);
            "aired".ToTraktLastActivity().Should().Be(TraktLastActivity.Aired);
            "watched".ToTraktLastActivity().Should().Be(TraktLastActivity.Watched);

            string? nullValue = null;
            nullValue.ToTraktLastActivity().Should().Be(TraktLastActivity.Unspecified);
        }

        [Fact]
        public void TestTraktLastActivityDisplayName()
        {
            TraktLastActivity.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktLastActivity.Collected.DisplayName().Should().Be("Collected");
            TraktLastActivity.Aired.DisplayName().Should().Be("Aired");
            TraktLastActivity.Watched.DisplayName().Should().Be("Watched");
        }
    }
}
