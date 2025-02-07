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
        }

        [Fact]
        public void TestTraktSortHowFromJson()
        {
            "unspecified".ToTraktSortHow().ShouldBe(TraktSortHow.Unspecified);
            "asc".ToTraktSortHow().ShouldBe(TraktSortHow.Ascending);
            "desc".ToTraktSortHow().ShouldBe(TraktSortHow.Descending);

            string? nullValue = null;
            nullValue.ToTraktSortHow().ShouldBe(TraktSortHow.Unspecified);
        }

        [Fact]
        public void TestTraktSortHowDisplayName()
        {
            TraktSortHow.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSortHow.Ascending.DisplayName().ShouldBe("Ascending");
            TraktSortHow.Descending.DisplayName().ShouldBe("Descending");
        }
    }
}
