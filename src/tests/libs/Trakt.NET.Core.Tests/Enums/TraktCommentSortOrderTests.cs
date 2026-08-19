using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktCommentSortOrderTests
    {
        [Fact]
        public void TestTraktCommentSortOrderToJson()
        {
            TraktCommentSortOrder.Unspecified.ToJson().ShouldBeNull();
            TraktCommentSortOrder.Newest.ToJson().ShouldBe("newest");
            TraktCommentSortOrder.Oldest.ToJson().ShouldBe("oldest");
            TraktCommentSortOrder.Likes.ToJson().ShouldBe("likes");
            TraktCommentSortOrder.Replies.ToJson().ShouldBe("replies");
            TraktCommentSortOrder.Highest.ToJson().ShouldBe("highest");
            TraktCommentSortOrder.Lowest.ToJson().ShouldBe("lowest");
            TraktCommentSortOrder.Plays.ToJson().ShouldBe("plays");
            TraktCommentSortOrder.Watched.ToJson().ShouldBe("watched");
            ((TraktCommentSortOrder)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktCommentSortOrderFromJson()
        {
            "unspecified".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Unspecified);
            "newest".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Newest);
            "oldest".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Oldest);
            "likes".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Likes);
            "replies".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Replies);
            "highest".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Highest);
            "lowest".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Lowest);
            "plays".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Plays);
            "watched".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Watched);

            string? nullValue = null;
            nullValue.ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Unspecified);
            "invalid".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Unspecified);
            "".ToTraktCommentSortOrder().ShouldBe(TraktCommentSortOrder.Unspecified);
        }

        [Fact]
        public void TestTraktCommentSortOrderDisplayName()
        {
            TraktCommentSortOrder.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCommentSortOrder.Newest.DisplayName().ShouldBe("Newest");
            TraktCommentSortOrder.Oldest.DisplayName().ShouldBe("Oldest");
            TraktCommentSortOrder.Likes.DisplayName().ShouldBe("Likes");
            TraktCommentSortOrder.Replies.DisplayName().ShouldBe("Replies");
            TraktCommentSortOrder.Highest.DisplayName().ShouldBe("Highest");
            TraktCommentSortOrder.Lowest.DisplayName().ShouldBe("Lowest");
            TraktCommentSortOrder.Plays.DisplayName().ShouldBe("Plays");
            TraktCommentSortOrder.Watched.DisplayName().ShouldBe("Watched");
            ((TraktCommentSortOrder)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktCommentSortOrderJsonConverter()
        {
            var converter = new TraktCommentSortOrderJsonConverter();
            converter.CanConvert(typeof(TraktCommentSortOrder)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktCommentSortOrder.Newest, options).ShouldBe("\"newest\"");
            JsonSerializer.Deserialize<TraktCommentSortOrder>("\"newest\"", options).ShouldBe(TraktCommentSortOrder.Newest);
            JsonSerializer.Deserialize<TraktCommentSortOrder>("\"\"", options).ShouldBe(TraktCommentSortOrder.Unspecified);
        }
    }
}
