namespace TraktNET.Json.Users
{
    public sealed class TraktUserYearInReviewTests
    {
        [Fact]
        public void TestTraktUserYearInReviewDefaultConstructor()
        {
            var yearInReview = new TraktUserYearInReview();

            yearInReview.Stats.ShouldBeNull();
            yearInReview.Images.ShouldBeNull();
            yearInReview.FirstWatched.ShouldBeNull();
            yearInReview.LastWatched.ShouldBeNull();
            yearInReview.Countries.ShouldBeNull();
            yearInReview.Trends.ShouldBeNull();
            yearInReview.Thanks.ShouldBeNull();
            yearInReview.MostWatched.ShouldBeNull();
            yearInReview.Genres.ShouldBeNull();
            yearInReview.Networks.ShouldBeNull();
            yearInReview.ProductionCompanies.ShouldBeNull();
            yearInReview.TopRated.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserYearInReviewFromJson()
        {
            TraktUserYearInReview? yearInReview = await TestUtility.DeserializeJsonAsync<TraktUserYearInReview>("Users\\year_in_review.json");

            yearInReview.ShouldNotBeNull();

            // Stats - All
            yearInReview.Stats.ShouldNotBeNull();
            yearInReview.Stats.All.ShouldNotBeNull();
            yearInReview.Stats.All.Minutes.ShouldNotBeNull();
            yearInReview.Stats.All.Minutes.Total.ShouldBe(125000U);
            yearInReview.Stats.All.Minutes.Yearly.ShouldBe(125000U);
            yearInReview.Stats.All.Minutes.Monthly.ShouldBe(10416U);
            yearInReview.Stats.All.Minutes.Weekly.ShouldBe(2403U);
            yearInReview.Stats.All.Minutes.Daily.ShouldBe(342U);

            yearInReview.Stats.All.PlayCounts.ShouldNotBeNull();
            yearInReview.Stats.All.PlayCounts.Total.ShouldBe(2500U);
            yearInReview.Stats.All.CollectedCounts.ShouldNotBeNull();
            yearInReview.Stats.All.CollectedCounts.Total.ShouldBe(500U);
            yearInReview.Stats.All.RatingsCounts.ShouldNotBeNull();
            yearInReview.Stats.All.RatingsCounts.Total.ShouldBe(350U);
            yearInReview.Stats.All.CommentsCounts.ShouldNotBeNull();
            yearInReview.Stats.All.CommentsCounts.Total.ShouldBe(75U);
            yearInReview.Stats.All.ListsCounts.ShouldNotBeNull();
            yearInReview.Stats.All.ListsCounts.Total.ShouldBe(10U);

            // Stats - Shows
            yearInReview.Stats.Shows.ShouldNotBeNull();
            yearInReview.Stats.Shows.Minutes.ShouldNotBeNull();
            yearInReview.Stats.Shows.Minutes.Total.ShouldBe(75000U);
            yearInReview.Stats.Shows.PlayCounts.ShouldNotBeNull();
            yearInReview.Stats.Shows.PlayCounts.Total.ShouldBe(1500U);
            yearInReview.Stats.Shows.ItemsCount.ShouldBe(50U);
            yearInReview.Stats.Shows.Distributions.ShouldNotBeNull();
            yearInReview.Stats.Shows.Distributions.Weekly.ShouldNotBeNull();
            yearInReview.Stats.Shows.Distributions.Weekly.ShouldBe([1U, 2U, 3U]);
            yearInReview.Stats.Shows.Distributions.Monthly.ShouldNotBeNull();
            yearInReview.Stats.Shows.Distributions.Monthly.ShouldBe([10U, 20U]);
            yearInReview.Stats.Shows.Distributions.Days.ShouldNotBeNull();
            yearInReview.Stats.Shows.Distributions.Days.ShouldBe([5U, 6U]);
            yearInReview.Stats.Shows.Distributions.Hourly.ShouldNotBeNull();
            yearInReview.Stats.Shows.Distributions.Hourly.ShouldBe([0U, 1U]);

            // Stats - Movies
            yearInReview.Stats.Movies.ShouldNotBeNull();
            yearInReview.Stats.Movies.Minutes.ShouldNotBeNull();
            yearInReview.Stats.Movies.Minutes.Total.ShouldBe(50000U);
            yearInReview.Stats.Movies.PlayCounts.ShouldNotBeNull();
            yearInReview.Stats.Movies.PlayCounts.Total.ShouldBe(1000U);
            yearInReview.Stats.Movies.ItemsCount.ShouldBe(30U);
            yearInReview.Stats.Movies.Distributions.ShouldNotBeNull();
            yearInReview.Stats.Movies.Distributions.Weekly.ShouldNotBeNull();
            yearInReview.Stats.Movies.Distributions.Weekly.ShouldBe([4U, 5U, 6U]);
            yearInReview.Stats.Movies.Distributions.Monthly.ShouldNotBeNull();
            yearInReview.Stats.Movies.Distributions.Monthly.ShouldBe([15U, 25U]);
            yearInReview.Stats.Movies.Distributions.Days.ShouldNotBeNull();
            yearInReview.Stats.Movies.Distributions.Days.ShouldBe([7U, 8U]);
            yearInReview.Stats.Movies.Distributions.Hourly.ShouldNotBeNull();
            yearInReview.Stats.Movies.Distributions.Hourly.ShouldBe([2U, 3U]);

            // Images
            yearInReview.Images.ShouldNotBeNull();
            yearInReview.Images.Cover.ShouldBe("https://walter.trakt.tv/images/cover.jpg");
            yearInReview.Images.Story.ShouldBe("https://walter.trakt.tv/images/story.jpg");

            // FirstWatched
            yearInReview.FirstWatched.ShouldNotBeNull();
            yearInReview.FirstWatched.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-01-01T20:00:00.000Z"));
            yearInReview.FirstWatched.Type.ShouldBe(TraktSyncItemType.Movie);
            yearInReview.FirstWatched.Movie.ShouldNotBeNull();
            yearInReview.FirstWatched.Movie.Title.ShouldBe("Inception");
            yearInReview.FirstWatched.Movie.Year.ShouldBe(2010U);

            // LastWatched
            yearInReview.LastWatched.ShouldNotBeNull();
            yearInReview.LastWatched.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-12-31T23:30:00.000Z"));
            yearInReview.LastWatched.Type.ShouldBe(TraktSyncItemType.Episode);
            yearInReview.LastWatched.Episode.ShouldNotBeNull();
            yearInReview.LastWatched.Episode.Title.ShouldBe("Winter Is Coming");
            yearInReview.LastWatched.Episode.Season.ShouldBe(1U);
            yearInReview.LastWatched.Episode.Number.ShouldBe(1U);
            yearInReview.LastWatched.Show.ShouldNotBeNull();
            yearInReview.LastWatched.Show.Title.ShouldBe("Game of Thrones");

            // Countries
            yearInReview.Countries.ShouldNotBeNull();
            yearInReview.Countries.Shows.ShouldNotBeNull();
            yearInReview.Countries.Shows.CountryCount.ShouldBe(2U);
            yearInReview.Countries.Shows.Countries.ShouldNotBeNull();
            yearInReview.Countries.Shows.Countries.Count.ShouldBe(2);
            yearInReview.Countries.Shows.Countries[0].Country.ShouldBe("us");
            yearInReview.Countries.Shows.Countries[0].Count.ShouldBe(50U);

            yearInReview.Countries.Movies.ShouldNotBeNull();
            yearInReview.Countries.Movies.CountryCount.ShouldBe(2U);
            yearInReview.Countries.Movies.Countries.ShouldNotBeNull();
            yearInReview.Countries.Movies.Countries.Count.ShouldBe(2);
            yearInReview.Countries.Movies.Countries[0].Country.ShouldBe("us");
            yearInReview.Countries.Movies.Countries[0].Count.ShouldBe(40U);

            // Trends
            yearInReview.Trends.ShouldNotBeNull();
            yearInReview.Trends.Shows.ShouldNotBeNull();
            yearInReview.Trends.Shows.Count.ShouldBe(1);
            yearInReview.Trends.Shows[0].Month.ShouldBe(1U);
            yearInReview.Trends.Shows[0].MonthName.ShouldBe("January");
            yearInReview.Trends.Shows[0].Watchers.ShouldBe(12000U);
            yearInReview.Trends.Shows[0].Watched.ShouldBe(true);
            yearInReview.Trends.Shows[0].Show.ShouldNotBeNull();
            yearInReview.Trends.Shows[0].Show!.Title.ShouldBe("Game of Thrones");

            yearInReview.Trends.Movies.ShouldNotBeNull();
            yearInReview.Trends.Movies.Count.ShouldBe(1);
            yearInReview.Trends.Movies[0].Month.ShouldBe(1U);
            yearInReview.Trends.Movies[0].MonthName.ShouldBe("January");
            yearInReview.Trends.Movies[0].Watchers.ShouldBe(15000U);
            yearInReview.Trends.Movies[0].Watched.ShouldBe(false);
            yearInReview.Trends.Movies[0].Movie.ShouldNotBeNull();
            yearInReview.Trends.Movies[0].Movie!.Title.ShouldBe("Inception");

            // Thanks
            yearInReview.Thanks.ShouldNotBeNull();
            yearInReview.Thanks.Shows.ShouldNotBeNull();
            yearInReview.Thanks.Shows.Count.ShouldBe(1);
            yearInReview.Thanks.Shows[0].Show.ShouldNotBeNull();
            yearInReview.Thanks.Shows[0].Show!.Title.ShouldBe("Breaking Bad");

            yearInReview.Thanks.Movies.ShouldNotBeNull();
            yearInReview.Thanks.Movies.Count.ShouldBe(1);
            yearInReview.Thanks.Movies[0].Movie.ShouldNotBeNull();
            yearInReview.Thanks.Movies[0].Movie!.Title.ShouldBe("The Dark Knight");

            // MostWatched
            yearInReview.MostWatched.ShouldNotBeNull();
            yearInReview.MostWatched.Shows.ShouldNotBeNull();
            yearInReview.MostWatched.Shows.Count.ShouldBe(1);
            yearInReview.MostWatched.Shows[0].Plays.ShouldBe(20U);
            yearInReview.MostWatched.Shows[0].Minutes.ShouldBe(900U);
            yearInReview.MostWatched.Shows[0].Show.ShouldNotBeNull();
            yearInReview.MostWatched.Shows[0].Show!.Title.ShouldBe("Breaking Bad");

            yearInReview.MostWatched.Movies.ShouldNotBeNull();
            yearInReview.MostWatched.Movies.Count.ShouldBe(1);
            yearInReview.MostWatched.Movies[0].Plays.ShouldBe(5U);
            yearInReview.MostWatched.Movies[0].Minutes.ShouldBe(740U);
            yearInReview.MostWatched.Movies[0].Movie.ShouldNotBeNull();
            yearInReview.MostWatched.Movies[0].Movie!.Title.ShouldBe("The Dark Knight");

            // Genres
            yearInReview.Genres.ShouldNotBeNull();
            yearInReview.Genres.Shows.ShouldNotBeNull();
            yearInReview.Genres.Shows.ItemCount.ShouldBe(10U);
            yearInReview.Genres.Shows.Genres.ShouldNotBeNull();
            yearInReview.Genres.Shows.Genres.Count.ShouldBe(1);
            yearInReview.Genres.Shows.Genres[0].Slug.ShouldBe("drama");
            yearInReview.Genres.Shows.Genres[0].Name.ShouldBe("Drama");
            yearInReview.Genres.Shows.Genres[0].Count.ShouldBe(6U);

            yearInReview.Genres.Movies.ShouldNotBeNull();
            yearInReview.Genres.Movies.ItemCount.ShouldBe(8U);
            yearInReview.Genres.Movies.Genres.ShouldNotBeNull();
            yearInReview.Genres.Movies.Genres.Count.ShouldBe(1);
            yearInReview.Genres.Movies.Genres[0].Slug.ShouldBe("action");
            yearInReview.Genres.Movies.Genres[0].Name.ShouldBe("Action");
            yearInReview.Genres.Movies.Genres[0].Count.ShouldBe(5U);

            // Networks
            yearInReview.Networks.ShouldNotBeNull();
            yearInReview.Networks.Count.ShouldBe(1);
            yearInReview.Networks[0].ID.ShouldBe(1U);
            yearInReview.Networks[0].Name.ShouldBe("AMC");
            yearInReview.Networks[0].Count.ShouldBe(12U);
            yearInReview.Networks[0].ImageUrl.ShouldBe("https://walter.trakt.tv/images/amc.png");
            yearInReview.Networks[0].Color.ShouldBe("#fc0303");

            // ProductionCompanies
            yearInReview.ProductionCompanies.ShouldNotBeNull();
            yearInReview.ProductionCompanies.Count.ShouldBe(1);
            yearInReview.ProductionCompanies[0].ID.ShouldBe(2U);
            yearInReview.ProductionCompanies[0].Name.ShouldBe("Warner Bros. Pictures");
            yearInReview.ProductionCompanies[0].Count.ShouldBe(8U);
            yearInReview.ProductionCompanies[0].ImageUrl.ShouldBe("https://walter.trakt.tv/images/wb.png");
            yearInReview.ProductionCompanies[0].Color.ShouldBe("#0000ff");

            // TopRated
            yearInReview.TopRated.ShouldNotBeNull();
            yearInReview.TopRated.Shows.ShouldNotBeNull();
            yearInReview.TopRated.Shows.Count.ShouldBe(1);
            yearInReview.TopRated.Shows[0].Rating.ShouldBe(10U);
            yearInReview.TopRated.Shows[0].Show.ShouldNotBeNull();
            yearInReview.TopRated.Shows[0].Show!.Title.ShouldBe("Breaking Bad");

            yearInReview.TopRated.Movies.ShouldNotBeNull();
            yearInReview.TopRated.Movies.Count.ShouldBe(1);
            yearInReview.TopRated.Movies[0].Rating.ShouldBe(9U);
            yearInReview.TopRated.Movies[0].Movie.ShouldNotBeNull();
            yearInReview.TopRated.Movies[0].Movie!.Title.ShouldBe("The Dark Knight");
        }

        [Fact]
        public async Task TestTraktUserYearInReviewToJson()
        {
            TraktUserYearInReview? yearInReview = await TestUtility.DeserializeJsonAsync<TraktUserYearInReview>("Users\\year_in_review.json");
            yearInReview.ShouldNotBeNull();

            string json = TestUtility.SerializeObject(yearInReview);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"stats\"");
            json.ShouldContain("\"most_watched\"");
            json.ShouldContain("\"genres\"");
            json.ShouldContain("\"networks\"");
            json.ShouldContain("\"production_companies\"");
            json.ShouldContain("\"top_rated\"");
        }
    }
}
