namespace TraktNET.Enums
{
    public sealed class TraktSortHowTests
    {
        [Fact]
        public void TestTraktSortHowToJson()
        {
            TraktSortHow.Unspecified.ToJson().Should().BeNull();
            TraktSortHow.Ascending.ToJson().Should().Be("asc");
            TraktSortHow.Descending.ToJson().Should().Be("desc");
        }

        [Fact]
        public void TestTraktSortHowFromJson()
        {
            "unspecified".ToTraktSortHow().Should().Be(TraktSortHow.Unspecified);
            "asc".ToTraktSortHow().Should().Be(TraktSortHow.Ascending);
            "desc".ToTraktSortHow().Should().Be(TraktSortHow.Descending);

            string? nullValue = null;
            nullValue.ToTraktSortHow().Should().Be(TraktSortHow.Unspecified);
        }

        [Fact]
        public void TestTraktSortHowDisplayName()
        {
            TraktSortHow.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktSortHow.Ascending.DisplayName().Should().Be("Ascending");
            TraktSortHow.Descending.DisplayName().Should().Be("Descending");
        }
    }
}
