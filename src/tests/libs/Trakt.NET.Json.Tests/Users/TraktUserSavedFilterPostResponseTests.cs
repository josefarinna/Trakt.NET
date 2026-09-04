namespace TraktNET.Json.Users
{
    public sealed class TraktUserSavedFilterPostResponseTests
    {
        [Fact]
        public void TestTraktUserSavedFilterPostResponseDefaultConstructor()
        {
            var userSavedFilterPostResponse = new TraktUserSavedFilterPostResponse();

            userSavedFilterPostResponse.Added.ShouldBeNull();
            userSavedFilterPostResponse.Skipped.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserSavedFilterPostResponseFromJson()
        {
            TraktUserSavedFilterPostResponse? userSavedFilterPostResponse =
                await TestUtility.DeserializeJsonAsync<TraktUserSavedFilterPostResponse>("Users\\usersavedfilterpostresponse.json");

            userSavedFilterPostResponse.ShouldNotBeNull();

            userSavedFilterPostResponse.Added.ShouldNotBeNull();
            userSavedFilterPostResponse.Added.Count.ShouldBe(1);

            TraktUserSavedFilter added = userSavedFilterPostResponse.Added[0];
            added.ID.ShouldBe(1U);
            added.Rank.ShouldBe(1U);
            added.Section.ShouldBe(TraktFilterSection.Movies);
            added.Name.ShouldBe("Movies: IMDB + TMDB ratings");
            added.Path.ShouldBe("/movies/recommended/weekly");
            added.Query.ShouldBe("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            added.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-15T11:15:06.000Z"));

            userSavedFilterPostResponse.Skipped.ShouldNotBeNull();
            userSavedFilterPostResponse.Skipped.Count.ShouldBe(1);

            TraktUserSavedFilterPost skipped = userSavedFilterPostResponse.Skipped[0];
            skipped.Name.ShouldBe("Movies: Invalid");
            skipped.Url.ShouldBe("/movies/invalid");
        }
    }
}
