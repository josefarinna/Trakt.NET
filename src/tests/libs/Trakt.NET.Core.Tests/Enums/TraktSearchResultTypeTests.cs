namespace TraktNET.Enums
{
    public sealed class TraktSearchResultTypeTests
    {
        [Fact]
        public void TestTraktSearchResultTypeToJson()
        {
            TraktSearchResultType.Unspecified.ToJson().Should().BeNull();
            TraktSearchResultType.Movie.ToJson().Should().Be("movie");
            TraktSearchResultType.Show.ToJson().Should().Be("show");
            TraktSearchResultType.Episode.ToJson().Should().Be("episode");
            TraktSearchResultType.Person.ToJson().Should().Be("person");
            TraktSearchResultType.List.ToJson().Should().Be("list");
        }

        [Fact]
        public void TestTraktSearchResultTypeFromJson()
        {
            "unspecified".ToTraktSearchResultType().Should().Be(TraktSearchResultType.Unspecified);
            "movie".ToTraktSearchResultType().Should().Be(TraktSearchResultType.Movie);
            "show".ToTraktSearchResultType().Should().Be(TraktSearchResultType.Show);
            "episode".ToTraktSearchResultType().Should().Be(TraktSearchResultType.Episode);
            "person".ToTraktSearchResultType().Should().Be(TraktSearchResultType.Person);
            "list".ToTraktSearchResultType().Should().Be(TraktSearchResultType.List);

            string? nullValue = null;
            nullValue.ToTraktSearchResultType().Should().Be(TraktSearchResultType.Unspecified);
        }

        [Fact]
        public void TestTraktSearchResultTypeDisplayName()
        {
            TraktSearchResultType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktSearchResultType.Movie.DisplayName().Should().Be("Movie");
            TraktSearchResultType.Show.DisplayName().Should().Be("Show");
            TraktSearchResultType.Episode.DisplayName().Should().Be("Episode");
            TraktSearchResultType.Person.DisplayName().Should().Be("Person");
            TraktSearchResultType.List.DisplayName().Should().Be("List");
        }
    }
}
