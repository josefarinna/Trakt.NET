namespace TraktNET.Json.Users
{
    public sealed class TraktUserSavedFilterPostTests
    {
        [Fact]
        public void TestTraktUserSavedFilterPostDefaultConstructor()
        {
            var userSavedFilterPost = new TraktUserSavedFilterPost();

            userSavedFilterPost.Name.ShouldBeNullOrEmpty();
            userSavedFilterPost.Url.ShouldBeNullOrEmpty();
        }

        [Fact]
        public async Task TestTraktUserSavedFilterPostFromJson()
        {
            TraktUserSavedFilterPost? userSavedFilterPost =
                await TestUtility.DeserializeJsonAsync<TraktUserSavedFilterPost>("Users\\usersavedfilterpost.json");

            userSavedFilterPost.ShouldNotBeNull();
            userSavedFilterPost.Name.ShouldBe("Movies: IMDB + TMDB ratings");
            userSavedFilterPost.Url.ShouldBe("/movies/recommended/weekly?imdb_ratings=6.9-10.0");
        }
    }
}
