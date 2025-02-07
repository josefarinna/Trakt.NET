namespace TraktNET.Enums
{
    public sealed class TraktMovieStatusTests
    {
        [Fact]
        public void TestTraktMovieStatusToJson()
        {
            TraktMovieStatus.Unspecified.ToJson().ShouldBeNull();
            TraktMovieStatus.Released.ToJson().ShouldBe("released");
            TraktMovieStatus.InProduction.ToJson().ShouldBe("in production");
            TraktMovieStatus.PostProduction.ToJson().ShouldBe("post production");
            TraktMovieStatus.Planned.ToJson().ShouldBe("planned");
            TraktMovieStatus.Rumored.ToJson().ShouldBe("rumored");
            TraktMovieStatus.Canceled.ToJson().ShouldBe("canceled");
        }

        [Fact]
        public void TestTraktMovieStatusFromJson()
        {
            "unspecified".ToTraktMovieStatus().ShouldBe(TraktMovieStatus.Unspecified);
            "released".ToTraktMovieStatus().ShouldBe(TraktMovieStatus.Released);
            "in production".ToTraktMovieStatus().ShouldBe(TraktMovieStatus.InProduction);
            "post production".ToTraktMovieStatus().ShouldBe(TraktMovieStatus.PostProduction);
            "planned".ToTraktMovieStatus().ShouldBe(TraktMovieStatus.Planned);
            "rumored".ToTraktMovieStatus().ShouldBe(TraktMovieStatus.Rumored);
            "canceled".ToTraktMovieStatus().ShouldBe(TraktMovieStatus.Canceled);

            string? nullValue = null;
            nullValue.ToTraktMovieStatus().ShouldBe(TraktMovieStatus.Unspecified);
        }

        [Fact]
        public void TestTraktMovieStatusDisplayName()
        {
            TraktMovieStatus.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktMovieStatus.Released.DisplayName().ShouldBe("Released");
            TraktMovieStatus.InProduction.DisplayName().ShouldBe("In Production");
            TraktMovieStatus.PostProduction.DisplayName().ShouldBe("Post Production");
            TraktMovieStatus.Planned.DisplayName().ShouldBe("Planned");
            TraktMovieStatus.Rumored.DisplayName().ShouldBe("Rumored");
            TraktMovieStatus.Canceled.DisplayName().ShouldBe("Canceled");
        }
    }
}
