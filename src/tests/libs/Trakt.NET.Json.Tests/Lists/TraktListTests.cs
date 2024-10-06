namespace TraktNET.Json.Lists
{
    public sealed class TraktListTests
    {
        [Fact]
        public void TestTraktListConstructor()
        {
            var list = new TraktList();

            list.Name.Should().BeNull();
            list.Description.Should().BeNull();
            list.Privacy.Should().BeNull();
            list.ShareLink.Should().BeNull();
            list.Type.Should().BeNull();
            list.DisplayNumbers.Should().BeNull();
            list.AllowComments.Should().BeNull();
            list.SortBy.Should().BeNull();
            list.SortHow.Should().BeNull();
            list.CreatedAt.Should().BeNull();
            list.UpdatedAt.Should().BeNull();
            list.ItemCount.Should().BeNull();
            list.CommentCount.Should().BeNull();
            list.Likes.Should().BeNull();
            list.IDs.Should().BeNull();
            list.User.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktListFromJson()
        {
            TraktList? list = await TestUtility.DeserializeJsonAsync<TraktList>("Lists\\list.json");

            list.Should().NotBeNull();

            list!.Name.Should().Be("MARVEL Cinematic Universe");
            list!.Description.Should().Be("MCU Shows and Movies in chronological order.");
            list!.Privacy.Should().Be(TraktListPrivacy.Public);
            list!.ShareLink.Should().Be("https://trakt.tv/lists/1248149");
            list!.Type.Should().Be(TraktListType.Personal);
            list!.DisplayNumbers.Should().BeTrue();
            list!.AllowComments.Should().BeTrue();
            list!.SortBy.Should().Be(TraktSortBy.Rank);
            list!.SortHow.Should().Be(TraktSortHow.Ascending);
            list!.CreatedAt.Should().Be(TestUtility.ParseUTCDateTime("2015-07-16T14:59:57.000Z"));
            list!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-10-04T06:47:38.000Z"));
            list!.ItemCount.Should().Be(218U);
            list!.CommentCount.Should().Be(33U);
            list!.Likes.Should().Be(4668U);

            list!.IDs.Should().NotBeNull();
            list!.IDs!.Trakt.Should().Be(1248149U);
            list!.IDs!.Slug.Should().Be("marvel-cinematic-universe");
            list!.IDs!.HasAnyID.Should().BeTrue();
            list!.IDs!.BestID.Should().Be("marvel-cinematic-universe");

            list!.User.Should().NotBeNull();
            list!.User!.Username.Should().Be("Donxy");
            list!.User!.Name.Should().Be("Donxy");
            list!.User!.Private.Should().BeFalse();
            list!.User!.VIP.Should().BeFalse();
            list!.User!.VIPEP.Should().BeTrue();
            list!.User!.IDs.Should().NotBeNull();
            list!.User!.IDs!.Slug.Should().Be("donxy");
        }
    }
}
