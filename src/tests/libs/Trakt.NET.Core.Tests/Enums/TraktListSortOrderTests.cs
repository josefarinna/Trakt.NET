using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktListSortOrderTests
    {
        [Fact]
        public void TestTraktListSortOrderToJson()
        {
            TraktListSortOrder.Unspecified.ToJson().ShouldBeNull();
            TraktListSortOrder.Popular.ToJson().ShouldBe("popular");
            TraktListSortOrder.Likes.ToJson().ShouldBe("likes");
            TraktListSortOrder.Comments.ToJson().ShouldBe("comments");
            TraktListSortOrder.Items.ToJson().ShouldBe("items");
            TraktListSortOrder.Added.ToJson().ShouldBe("added");
            TraktListSortOrder.Updated.ToJson().ShouldBe("updated");
            ((TraktListSortOrder)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktListSortOrderFromJson()
        {
            "unspecified".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Unspecified);
            "popular".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Popular);
            "likes".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Likes);
            "comments".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Comments);
            "items".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Items);
            "added".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Added);
            "updated".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Updated);

            string? nullValue = null;
            nullValue.ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Unspecified);
            "invalid".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Unspecified);
            "".ToTraktListSortOrder().ShouldBe(TraktListSortOrder.Unspecified);
        }

        [Fact]
        public void TestTraktListSortOrderDisplayName()
        {
            TraktListSortOrder.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktListSortOrder.Popular.DisplayName().ShouldBe("Popular");
            TraktListSortOrder.Likes.DisplayName().ShouldBe("Likes");
            TraktListSortOrder.Comments.DisplayName().ShouldBe("Comments");
            TraktListSortOrder.Items.DisplayName().ShouldBe("Items");
            TraktListSortOrder.Added.DisplayName().ShouldBe("Added");
            TraktListSortOrder.Updated.DisplayName().ShouldBe("Updated");
            ((TraktListSortOrder)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktListSortOrderJsonConverter()
        {
            var converter = new TraktListSortOrderJsonConverter();
            converter.CanConvert(typeof(TraktListSortOrder)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktListSortOrder.Popular, options).ShouldBe("\"popular\"");
            JsonSerializer.Deserialize<TraktListSortOrder>("\"popular\"", options).ShouldBe(TraktListSortOrder.Popular);
            JsonSerializer.Deserialize<TraktListSortOrder>("\"\"", options).ShouldBe(TraktListSortOrder.Unspecified);
        }
    }
}
