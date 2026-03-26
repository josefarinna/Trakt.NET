namespace TraktNET.Json.Lists
{
    public sealed partial class TraktListLikeTests
    {
        [Fact]
        public void TestListLikeDefaultConstructor()
        {
            var listLike = new TraktListLike();

            listLike.LikedAt.ShouldBeNull();
            listLike.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestListLikeFromJson()
        {
            TraktListLike? listLike = await TestUtility.DeserializeJsonAsync<TraktListLike>("Lists\\listlike.json");

            listLike.ShouldNotBeNull();
            listLike.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            listLike.User.ShouldNotBeNull();
            listLike.User.Username.ShouldBe("justin");
            listLike.User.Private.ShouldBe(false);
            listLike.User.Name.ShouldBe("Justin Nemeth");
            listLike.User.VIP.ShouldBe(true);
            listLike.User.VIPEP.ShouldBe(true);

            listLike.User.IDs.ShouldNotBeNull();
            listLike.User.IDs!.Slug.ShouldBe("justin");
        }
    }
}
