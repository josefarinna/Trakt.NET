namespace TraktNET.Json.Users
{
    public sealed class TraktUserLimitsTests
    {
        [Fact]
        public void TestTraktUserLimitsDefaultConstructor()
        {
            var userLimits = new TraktUserLimits();

            userLimits.List.ShouldBeNull();
            userLimits.Watchlist.ShouldBeNull();
            userLimits.Favorites.ShouldBeNull();
            userLimits.Search.ShouldBeNull();
            userLimits.Collection.ShouldBeNull();
            userLimits.Notes.ShouldBeNull();
            userLimits.SavedFilters.ShouldBeNull();
            userLimits.Recommendations.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserLimitsFromJson()
        {
            TraktUserLimits? userLimits = await TestUtility.DeserializeJsonAsync<TraktUserLimits>("Users\\userlimits.json");

            userLimits.ShouldNotBeNull();

            userLimits.List.ShouldNotBeNull();
            userLimits.List.Count.ShouldBe(10U);
            userLimits.List.ItemCount.ShouldBe(250U);

            userLimits.Watchlist.ShouldNotBeNull();
            userLimits.Watchlist.ItemCount.ShouldBe(250U);

            userLimits.Favorites.ShouldNotBeNull();
            userLimits.Favorites.ItemCount.ShouldBe(100U);

            userLimits.Search.ShouldNotBeNull();
            userLimits.Search.RecentCount.ShouldBe(5U);

            userLimits.Collection.ShouldNotBeNull();
            userLimits.Collection.ItemCount.ShouldBe(100U);

            userLimits.Notes.ShouldNotBeNull();
            userLimits.Notes.ItemCount.ShouldBe(100U);

            userLimits.SavedFilters.ShouldNotBeNull();
            userLimits.SavedFilters.Count.ShouldBe(5U);

            userLimits.Recommendations.ShouldNotBeNull();
            userLimits.Recommendations.ItemCount.ShouldBe(100U);
        }
    }
}
