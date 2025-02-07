namespace TraktNET.Enums
{
    public sealed class TraktTimePeriodTests
    {
        [Fact]
        public void TestTraktTimePeriodToJson()
        {
            TraktTimePeriod.Unspecified.ToJson().ShouldBeNull();
            TraktTimePeriod.Daily.ToJson().ShouldBe("daily");
            TraktTimePeriod.Weekly.ToJson().ShouldBe("weekly");
            TraktTimePeriod.Monthly.ToJson().ShouldBe("monthly");
            TraktTimePeriod.Yearly.ToJson().ShouldBe("yearly");
            TraktTimePeriod.All.ToJson().ShouldBe("all");
        }

        [Fact]
        public void TestTraktTimePeriodFromJson()
        {
            "unspecified".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Unspecified);
            "daily".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Daily);
            "weekly".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Weekly);
            "monthly".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Monthly);
            "yearly".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Yearly);
            "all".ToTraktTimePeriod().ShouldBe(TraktTimePeriod.All);

            string? nullValue = null;
            nullValue.ToTraktTimePeriod().ShouldBe(TraktTimePeriod.Unspecified);
        }

        [Fact]
        public void TestTraktTimePeriodDisplayName()
        {
            TraktTimePeriod.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktTimePeriod.Daily.DisplayName().ShouldBe("Daily");
            TraktTimePeriod.Weekly.DisplayName().ShouldBe("Weekly");
            TraktTimePeriod.Monthly.DisplayName().ShouldBe("Monthly");
            TraktTimePeriod.Yearly.DisplayName().ShouldBe("Yearly");
            TraktTimePeriod.All.DisplayName().ShouldBe("All");
        }
    }
}
