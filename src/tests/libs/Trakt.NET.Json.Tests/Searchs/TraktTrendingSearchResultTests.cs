namespace TraktNET.Json.Search
{
    public sealed class TraktTrendingSearchResultTests
    {
        [Fact]
        public void TestTraktTrendingSearchResultConstructor()
        {
            var searchResult = new TraktTrendingSearchResult();

            searchResult.Count.ShouldBeNull();
            searchResult.Id.ShouldBeNull();
            searchResult.Type.ShouldBeNull();
            searchResult.Movie.ShouldBeNull();
            searchResult.Show.ShouldBeNull();
            searchResult.Person.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktTrendingSearchResultFromJson()
        {
            IReadOnlyList<TraktTrendingSearchResult>? results = await TestUtility.DeserializeJsonListAsync<TraktTrendingSearchResult>("Searchs\\trendingsearchresult.json");

            results.ShouldNotBeNull();
            results.Count.ShouldBe(2);

            TraktTrendingSearchResult firstResult = results[0];
            firstResult.Id.ShouldBe(1U);
            firstResult.Count.ShouldBe(120U);
            firstResult.Type.ShouldBe(TraktSearchResultType.Movie);
            firstResult.Movie.ShouldNotBeNull();
            firstResult.Movie!.Title.ShouldBe("Batman Begins");
            firstResult.Movie.Year.ShouldBe(2005U);
            firstResult.Movie.IDs.ShouldNotBeNull();
            firstResult.Movie.IDs!.Trakt.ShouldBe(1U);
            firstResult.Movie.IDs.Slug.ShouldBe("batman-begins-2005");
            firstResult.Movie.IDs.IMDB.ShouldBe("tt0372784");
            firstResult.Movie.IDs.TMDB.ShouldBe(272U);

            TraktTrendingSearchResult secondResult = results[1];
            secondResult.Id.ShouldBe(2U);
            secondResult.Count.ShouldBe(95U);
            secondResult.Type.ShouldBe(TraktSearchResultType.Show);
            secondResult.Show.ShouldNotBeNull();
            secondResult.Show!.Title.ShouldBe("Batman: The Animated Series");
            secondResult.Show.Year.ShouldBe(1992U);
            secondResult.Show.IDs.ShouldNotBeNull();
            secondResult.Show.IDs!.Trakt.ShouldBe(2U);
            secondResult.Show.IDs.Slug.ShouldBe("batman-the-animated-series");
            secondResult.Show.IDs.TVDB.ShouldBe(76115U);
            secondResult.Show.IDs.IMDB.ShouldBe("tt0103359");
            secondResult.Show.IDs.TMDB.ShouldBe(2098U);
        }
    }
}
