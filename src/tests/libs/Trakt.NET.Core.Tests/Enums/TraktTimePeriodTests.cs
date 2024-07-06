namespace TraktNET.Enums
{
    public sealed class TraktTimePeriodTests
    {
        [Fact]
        public void TestTraktTimePeriodToJson()
        {
            TraktTimePeriod.Unspecified.ToJson().Should().BeNull();
            TraktTimePeriod.Daily.ToJson().Should().Be("daily");
            TraktTimePeriod.Weekly.ToJson().Should().Be("weekly");
            TraktTimePeriod.Monthly.ToJson().Should().Be("monthly");
            TraktTimePeriod.Yearly.ToJson().Should().Be("yearly");
            TraktTimePeriod.All.ToJson().Should().Be("all");
        }

        [Fact]
        public void TestTraktTimePeriodFromJson()
        {
            "unspecified".ToTraktTimePeriod().Should().Be(TraktTimePeriod.Unspecified);
            "daily".ToTraktTimePeriod().Should().Be(TraktTimePeriod.Daily);
            "weekly".ToTraktTimePeriod().Should().Be(TraktTimePeriod.Weekly);
            "monthly".ToTraktTimePeriod().Should().Be(TraktTimePeriod.Monthly);
            "yearly".ToTraktTimePeriod().Should().Be(TraktTimePeriod.Yearly);
            "all".ToTraktTimePeriod().Should().Be(TraktTimePeriod.All);

            string? nullValue = null;
            nullValue.ToTraktTimePeriod().Should().Be(TraktTimePeriod.Unspecified);
        }

        [Fact]
        public void TestTraktTimePeriodDisplayName()
        {
            TraktTimePeriod.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktTimePeriod.Daily.DisplayName().Should().Be("Daily");
            TraktTimePeriod.Weekly.DisplayName().Should().Be("Weekly");
            TraktTimePeriod.Monthly.DisplayName().Should().Be("Monthly");
            TraktTimePeriod.Yearly.DisplayName().Should().Be("Yearly");
            TraktTimePeriod.All.DisplayName().Should().Be("All");
        }
    }
}
