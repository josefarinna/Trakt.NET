namespace TraktNET.Json.Searchs
{
    public sealed class TraktSearchRecentPostTests
    {
        [Fact]
        public void TestTraktSearchRecentPostDefaultConstructor()
        {
            var post = new TraktSearchRecentPost();

            post.Query.ShouldBeNull();
            post.ID.ShouldBe(0U);
            post.Type.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSearchRecentPostFromJson()
        {
            TraktSearchRecentPost? post = await TestUtility.DeserializeJsonAsync<TraktSearchRecentPost>("Searchs\\searchrecentpost.json");

            post.ShouldNotBeNull();
            post.Query.ShouldBe("batman");
            post.ID.ShouldBe(99U);
            post.Type.ShouldBe(TraktSearchRecentType.Movie);
        }

        [Fact]
        public void TestTraktSearchRecentPostSerialization()
        {
            var post = new TraktSearchRecentPost
            {
                Query = "batman",
                ID = 99U,
                Type = TraktSearchRecentType.Movie
            };

            string json = TestUtility.SerializeObject(post);

            json.ShouldContain("\"query\":\"batman\"");
            json.ShouldContain("\"id\":99");
            json.ShouldContain("\"type\":\"movies\"");
        }

        [Fact]
        public void TestTraktSearchRecentPostValidate()
        {
            var post = new TraktSearchRecentPost
            {
                Query = "batman",
                ID = 99U,
                Type = TraktSearchRecentType.Movie
            };

            Action act = () => post.Validate();
            act.ShouldNotThrow();

            post.Query = null;
            act.ShouldThrow<ArgumentException>();

            post.Query = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.Query = "   ";
            act.ShouldThrow<ArgumentException>();

            post.Query = "batman";
            post.ID = 0U;
            act.ShouldThrow<TraktRequestValidationException>();

            post.ID = 99U;
            post.Type = TraktSearchRecentType.Unspecified;
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
