namespace TraktNET.Json.Users
{
    public sealed class TraktUserIDsTests
    {
        [Fact]
        public void TestTraktUserIDsConstructor()
        {
            var userIDs = new TraktUserIDs();

            userIDs.Slug.ShouldBeNull();
            userIDs.UUID.ShouldBeNull();

            userIDs.HasAnyID.ShouldBe(false);
            userIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktUserIDsHasAnyId()
        {
            var userIDs = new TraktUserIDs { Slug = "slug" };
            userIDs.HasAnyID.ShouldBeTrue();

            userIDs = new TraktUserIDs { UUID = "uuid" };
            userIDs.HasAnyID.ShouldBeTrue();

        }

        [Fact]
        public void TestTraktUserIDsGetBestID()
        {
            var userIDs = new TraktUserIDs();

            var bestID = userIDs.BestID;
            bestID.ShouldNotBeNull();

            userIDs = new TraktUserIDs { Slug = "slug" };

            bestID = userIDs.BestID;
            bestID.ShouldBe("slug");

            userIDs = new TraktUserIDs { UUID = "uuid" };

            bestID = userIDs.BestID;
            bestID.ShouldBe("uuid");

            userIDs = new TraktUserIDs
            {
                Slug = "slug",
                UUID = "uuid"
            };

            bestID = userIDs.BestID;
            bestID.ShouldBe("slug");

            userIDs = new TraktUserIDs
            {
                UUID = "uuid"
            };

            bestID = userIDs.BestID;
            bestID.ShouldBe("uuid");
        }

        [Fact]
        public async Task TestTraktUserIDsFromJson()
        {
            TraktUserIDs? userIDs = await TestUtility.DeserializeJsonAsync<TraktUserIDs>("Users\\userids.json");

            userIDs.ShouldNotBeNull();

            userIDs!.Slug.ShouldBe("ixxus");
            userIDs!.UUID.ShouldBe("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");

            userIDs!.HasAnyID.ShouldBe(true);
            userIDs!.BestID.ShouldBe("ixxus");
        }
    }
}
