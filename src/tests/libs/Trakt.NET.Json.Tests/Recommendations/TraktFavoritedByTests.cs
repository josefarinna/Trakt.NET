namespace TraktNET.Json.Recommendations
{
    public sealed class TraktFavoritedByTests
    {
        [Fact]
        public void TestTraktFavoritedByDefaultConstructor()
        {
            var favoritedBy = new TraktFavoritedBy();

            favoritedBy.User.ShouldBeNull();
            favoritedBy.Notes.ShouldBeNullOrEmpty();
        }

        [Fact]
        public async Task TestTraktFavoritedByFromJson()
        {
            TraktFavoritedBy? favoritedBy = await TestUtility.DeserializeJsonAsync<TraktFavoritedBy>("Recommendations\\favoritedby.json");

            favoritedBy.ShouldNotBeNull();
            favoritedBy.User.ShouldNotBeNull();
            favoritedBy.User.Username.ShouldBe("sean");
            favoritedBy.User.Private.ShouldBe(false);
            favoritedBy.User.Name.ShouldBe("Sean Rudford");
            favoritedBy.User.VIP.ShouldBe(true);
            favoritedBy.User.VIPEP.ShouldBe(true);
            favoritedBy.User.IDs.ShouldNotBeNull();
            favoritedBy.User.IDs.Slug.ShouldBe("sean");
            favoritedBy.User.IDs.UUID.ShouldBe("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            favoritedBy.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            favoritedBy.User.Location.ShouldBe("SF");
            favoritedBy.User.About.ShouldBe("I have all your cassette tapes.");
            favoritedBy.User.Gender.ShouldBe(TraktGender.Male);
            favoritedBy.User.Age.ShouldBe(35U);
            favoritedBy.User.Images.ShouldNotBeNull();
            favoritedBy.User.Images.Avatar.ShouldNotBeNull();
            favoritedBy.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            favoritedBy.User.VIPOG.ShouldBe(true);
            favoritedBy.User.VIPYears.ShouldBe(5U);
            favoritedBy.User.VIPCoverImage.ShouldBe("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            favoritedBy.Notes.ShouldBe("Favorited because ...");
        }
    }
}
