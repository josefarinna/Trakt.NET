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

            // Stats - Movies
            yearInReview.Stats.Movies.ShouldNotBeNull();
            yearInReview.Stats.Movies.Minutes.ShouldNotBeNull();
            yearInReview.Stats.Movies.Minutes.Total.ShouldBe(50000U);
            yearInReview.Stats.Movies.PlayCounts.ShouldNotBeNull();
            yearInReview.Stats.Movies.PlayCounts.Total.ShouldBe(1000U);

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
        }
    }
}
