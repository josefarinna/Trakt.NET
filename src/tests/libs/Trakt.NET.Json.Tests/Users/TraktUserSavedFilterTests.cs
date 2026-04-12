namespace TraktNET.Json.Users
{
    public sealed class TraktUserSavedFilterTests
    {
        [Fact]
        public void TestTraktUserSavedFilterDefaultConstructor()
        {
            var userSavedFilter = new TraktUserSavedFilter();

            userSavedFilter.ID.ShouldBeNull();
            userSavedFilter.Rank.ShouldBeNull();
            userSavedFilter.Section.ShouldBeNull();
            userSavedFilter.Name.ShouldBeNullOrEmpty();
            userSavedFilter.Path.ShouldBeNullOrEmpty();
            userSavedFilter.Query.ShouldBeNullOrEmpty();
            userSavedFilter.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserSavedFilterFromJson()
        {
            TraktUserSavedFilter? userSavedFilter = await TestUtility.DeserializeJsonAsync<TraktUserSavedFilter>("Users\\usersavedfilter.json");

            userSavedFilter.ShouldNotBeNull();
            userSavedFilter.ID.ShouldBe(1U);
            userSavedFilter.Rank.ShouldBe(1U);
            userSavedFilter.Section.ShouldBe(TraktFilterSection.Movies);
            userSavedFilter.Name.ShouldBe("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.ShouldBe("/movies/recommended/weekly");
            userSavedFilter.Query.ShouldBe("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-15T11:15:06.000Z"));
        }
    }
}
