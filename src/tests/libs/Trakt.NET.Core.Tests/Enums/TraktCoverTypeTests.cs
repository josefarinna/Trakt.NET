namespace TraktNET.Enums
{
    public sealed class TraktCoverTypeTests
    {
        [Fact]
        public void TestTraktCoverTypeToJson()
        {
            TraktCoverType.Unspecified.ToJson().ShouldBeNull();
            TraktCoverType.Movie.ToJson().ShouldBe("movie");
            TraktCoverType.Show.ToJson().ShouldBe("show");
            TraktCoverType.Episode.ToJson().ShouldBe("episode");
        }

        [Fact]
        public void TestTraktCoverTypeFromJson()
        {
            "unspecified".ToTraktCoverType().ShouldBe(TraktCoverType.Unspecified);
            "movie".ToTraktCoverType().ShouldBe(TraktCoverType.Movie);
            "show".ToTraktCoverType().ShouldBe(TraktCoverType.Show);
            "episode".ToTraktCoverType().ShouldBe(TraktCoverType.Episode);

            string? nullValue = null;
            nullValue.ToTraktCoverType().ShouldBe(TraktCoverType.Unspecified);
        }

        [Fact]
        public void TestTraktCoverTypeDisplayName()
        {
            TraktCoverType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCoverType.Movie.DisplayName().ShouldBe("Movie");
            TraktCoverType.Show.DisplayName().ShouldBe("Show");
            TraktCoverType.Episode.DisplayName().ShouldBe("Episode");
        }
    }
}
