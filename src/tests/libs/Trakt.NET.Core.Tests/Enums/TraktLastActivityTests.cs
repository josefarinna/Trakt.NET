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
        }

        [Fact]
        public void TestTraktLastActivityDisplayName()
        {
            TraktLastActivity.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktLastActivity.Collected.DisplayName().ShouldBe("Collected");
            TraktLastActivity.Aired.DisplayName().ShouldBe("Aired");
            TraktLastActivity.Watched.DisplayName().ShouldBe("Watched");
        }
    }
}
