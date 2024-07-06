namespace TraktNET.Enums
{
    public sealed class TraktCommentObjectTypeTests
    {
        [Fact]
        public void TestTraktCommentObjectTypeToJson()
        {
            TraktCommentObjectType.Unspecified.ToJson().Should().BeNull();
            TraktCommentObjectType.Movie.ToJson().Should().Be("movie");
            TraktCommentObjectType.Show.ToJson().Should().Be("show");
            TraktCommentObjectType.Season.ToJson().Should().Be("season");
            TraktCommentObjectType.Episode.ToJson().Should().Be("episode");
            TraktCommentObjectType.List.ToJson().Should().Be("list");
            TraktCommentObjectType.All.ToJson().Should().Be("all");
        }

        [Fact]
        public void TestTraktCommentObjectTypeFromJson()
        {
            "unspecified".ToTraktCommentObjectType().Should().Be(TraktCommentObjectType.Unspecified);
            "movie".ToTraktCommentObjectType().Should().Be(TraktCommentObjectType.Movie);
            "show".ToTraktCommentObjectType().Should().Be(TraktCommentObjectType.Show);
            "season".ToTraktCommentObjectType().Should().Be(TraktCommentObjectType.Season);
            "episode".ToTraktCommentObjectType().Should().Be(TraktCommentObjectType.Episode);
            "list".ToTraktCommentObjectType().Should().Be(TraktCommentObjectType.List);
            "all".ToTraktCommentObjectType().Should().Be(TraktCommentObjectType.All);

            string? nullValue = null;
            nullValue.ToTraktCommentObjectType().Should().Be(TraktCommentObjectType.Unspecified);
        }

        [Fact]
        public void TestTraktCommentObjectTypeDisplayName()
        {
            TraktCommentObjectType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktCommentObjectType.Movie.DisplayName().Should().Be("Movie");
            TraktCommentObjectType.Show.DisplayName().Should().Be("Show");
            TraktCommentObjectType.Season.DisplayName().Should().Be("Season");
            TraktCommentObjectType.Episode.DisplayName().Should().Be("Episode");
            TraktCommentObjectType.List.DisplayName().Should().Be("List");
            TraktCommentObjectType.All.DisplayName().Should().Be("All");
        }
    }
}
