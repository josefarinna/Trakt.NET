namespace TraktNET.Enums
{
    public sealed class TraktFavoriteObjectTypeTests
    {
        [Fact]
        public void TestTraktFavoriteObjectTypeToJson()
        {
            TraktFavoriteObjectType.Unspecified.ToJson().Should().BeNull();
            TraktFavoriteObjectType.Movie.ToJson().Should().Be("movie");
            TraktFavoriteObjectType.Show.ToJson().Should().Be("show");
        }

        [Fact]
        public void TestTraktFavoriteObjectTypeFromJson()
        {
            "unspecified".ToTraktFavoriteObjectType().Should().Be(TraktFavoriteObjectType.Unspecified);
            "movie".ToTraktFavoriteObjectType().Should().Be(TraktFavoriteObjectType.Movie);
            "show".ToTraktFavoriteObjectType().Should().Be(TraktFavoriteObjectType.Show);

            string? nullValue = null;
            nullValue.ToTraktFavoriteObjectType().Should().Be(TraktFavoriteObjectType.Unspecified);
        }

        [Fact]
        public void TestTraktFavoriteObjectTypeDisplayName()
        {
            TraktFavoriteObjectType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktFavoriteObjectType.Movie.DisplayName().Should().Be("Movie");
            TraktFavoriteObjectType.Show.DisplayName().Should().Be("Show");
        }
    }
}
