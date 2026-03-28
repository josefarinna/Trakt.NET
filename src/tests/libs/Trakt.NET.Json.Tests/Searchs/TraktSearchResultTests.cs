namespace TraktNET.Json.Search
{
    public sealed class TraktSearchResultTests
    {
        [Fact]
        public void TestTraktSearchResultConstructor()
        {
            var searchResult = new TraktSearchResult();

            searchResult.Type.ShouldBeNull();
            searchResult.Score.ShouldBeNull();
            searchResult.Movie.ShouldBeNull();
            searchResult.Show.ShouldBeNull();
            searchResult.Episode.ShouldBeNull();
            searchResult.Person.ShouldBeNull();
            searchResult.List.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSearchResultFromJson()
        {
            IReadOnlyList<TraktSearchResult>? results = await TestUtility.DeserializeJsonListAsync<TraktSearchResult>("Searchs\\searchresult.json");

            results.ShouldNotBeNull();
            results.Count.ShouldBe(10);

            TraktSearchResult firstResult = results[0];
            firstResult.Type.ShouldBe(TraktSearchResultType.Movie);
            firstResult.Score.ShouldBe(578730123365189800f);

            firstResult.Movie.ShouldNotBeNull();
            TraktMovie movie = firstResult.Movie!;
            movie.Title.ShouldBe("Avengers: Endgame");
            movie.Year.ShouldBe(2019U);

            movie.IDs.ShouldNotBeNull();
            movie.IDs!.Trakt.ShouldBe(191798U);
            movie.IDs.Slug.ShouldBe("avengers-endgame-2019");
            movie.IDs.IMDB.ShouldBe("tt4154796");
            movie.IDs.TMDB.ShouldBe(299534U);

            movie.Tagline.ShouldBe("Avenge the fallen.");
            movie.Runtime.ShouldBe(181U);
            movie.Country.ShouldBe("us");
            movie.Status.ShouldBe(TraktMovieStatus.Released);
            movie.Rating.ShouldBe(8.40629f);
            movie.Votes.ShouldBe(59222U);

            TraktSearchResult secondResult = results[1];
            secondResult.Type.ShouldBe(TraktSearchResultType.Movie);
            secondResult.Movie.ShouldNotBeNull();
            secondResult.Movie!.Title.ShouldBe("The Avengers");
            secondResult.Movie.Year.ShouldBe(2012U);
            secondResult.Movie.IDs!.Trakt.ShouldBe(14701U);

            TraktSearchResult thirdResult = results[2];
            thirdResult.Type.ShouldBe(TraktSearchResultType.Movie);
            thirdResult.Movie.ShouldNotBeNull();
            thirdResult.Movie!.Title.ShouldBe("Avengers: Infinity War");
            thirdResult.Movie.Year.ShouldBe(2018U);

            thirdResult.Movie.Genres.ShouldNotBeNull();
            thirdResult.Movie.Genres!.Count.ShouldBe(4);
            thirdResult.Movie.Genres.ShouldContain("action");
            thirdResult.Movie.Genres.ShouldContain("science-fiction");
        }
    }
}
