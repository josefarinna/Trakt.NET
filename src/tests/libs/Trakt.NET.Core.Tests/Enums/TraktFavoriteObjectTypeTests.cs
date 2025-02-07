namespace TraktNET.Enums
{
    public sealed class TraktFavoriteObjectTypeTests
    {
        [Fact]
        public void TestTraktFavoriteObjectTypeToJson()
        {
            TraktFavoriteObjectType.Unspecified.ToJson().ShouldBeNull();
            TraktFavoriteObjectType.Movie.ToJson().ShouldBe("movie");
            TraktFavoriteObjectType.Show.ToJson().ShouldBe("show");
        }

        [Fact]
        public void TestTraktFavoriteObjectTypeFromJson()
        {
            "unspecified".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Unspecified);
            "movie".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Movie);
            "show".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Show);

            string? nullValue = null;
            nullValue.ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Unspecified);
        }

        [Fact]
        public void TestTraktFavoriteObjectTypeDisplayName()
        {
            TraktFavoriteObjectType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktFavoriteObjectType.Movie.DisplayName().ShouldBe("Movie");
            TraktFavoriteObjectType.Show.DisplayName().ShouldBe("Show");
        }
    }
}
