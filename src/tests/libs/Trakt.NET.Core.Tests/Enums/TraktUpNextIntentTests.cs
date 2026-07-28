namespace TraktNET.Enums
{
    public sealed class TraktUpNextIntentTests
    {
        [Fact]
        public void TestTraktUpNextIntentToJson()
        {
            TraktUpNextIntent.Unspecified.ToJson().ShouldBeNull();
            TraktUpNextIntent.All.ToJson().ShouldBe("all");
            TraktUpNextIntent.Continue.ToJson().ShouldBe("continue");
            TraktUpNextIntent.Start.ToJson().ShouldBe("start");
            TraktUpNextIntent.Completed.ToJson().ShouldBe("completed");
        }

        [Fact]
        public void TestTraktUpNextIntentFromJson()
        {
            "unspecified".ToTraktUpNextIntent().ShouldBe(TraktUpNextIntent.Unspecified);
            "all".ToTraktUpNextIntent().ShouldBe(TraktUpNextIntent.All);
            "continue".ToTraktUpNextIntent().ShouldBe(TraktUpNextIntent.Continue);
            "start".ToTraktUpNextIntent().ShouldBe(TraktUpNextIntent.Start);
            "completed".ToTraktUpNextIntent().ShouldBe(TraktUpNextIntent.Completed);

            string? nullValue = null;
            nullValue.ToTraktUpNextIntent().ShouldBe(TraktUpNextIntent.Unspecified);
        }

        [Fact]
        public void TestTraktUpNextIntentDisplayName()
        {
            TraktUpNextIntent.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUpNextIntent.All.DisplayName().ShouldBe("All");
            TraktUpNextIntent.Continue.DisplayName().ShouldBe("Continue");
            TraktUpNextIntent.Start.DisplayName().ShouldBe("Start");
            TraktUpNextIntent.Completed.DisplayName().ShouldBe("Completed");
        }

        [Fact]
        public void TestTraktUpNextIntentToURI()
        {
            TraktUpNextIntent.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktUpNextIntent.All.ToURI().ShouldBe("all");
            TraktUpNextIntent.Continue.ToURI().ShouldBe("continue");
            TraktUpNextIntent.Start.ToURI().ShouldBe("start");
            TraktUpNextIntent.Completed.ToURI().ShouldBe("completed");
        }

        [Fact]
        public void TestTraktUpNextIntentAsPathParameter()
        {
            TraktUpNextIntent.Unspecified.AsPathParameter().ShouldBe(string.Empty);
            TraktUpNextIntent.All.AsPathParameter().ShouldBe("all");
            TraktUpNextIntent.Continue.AsPathParameter().ShouldBe("continue");
            TraktUpNextIntent.Start.AsPathParameter().ShouldBe("start");
            TraktUpNextIntent.Completed.AsPathParameter().ShouldBe("completed");
        }
    }
}
