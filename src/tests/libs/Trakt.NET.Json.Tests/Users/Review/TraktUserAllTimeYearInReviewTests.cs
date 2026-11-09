namespace TraktNET.Json.Users
{
    public sealed class TraktUserAllTimeYearInReviewTests
    {
        [Fact]
        public void TestTraktUserAllTimeYearInReviewDefaultConstructor()
        {
            var allTimeReview = new TraktUserAllTimeYearInReview();

            allTimeReview.Stats.ShouldBeNull();
            allTimeReview.Images.ShouldBeNull();
            allTimeReview.FirstWatched.ShouldBeNull();
            allTimeReview.LastWatched.ShouldBeNull();
            allTimeReview.Countries.ShouldBeNull();
            allTimeReview.Trends.ShouldBeNull();
            allTimeReview.Thanks.ShouldBeNull();
            allTimeReview.MostWatched.ShouldBeNull();
            allTimeReview.Genres.ShouldBeNull();
            allTimeReview.Networks.ShouldBeNull();
            allTimeReview.ProductionCompanies.ShouldBeNull();
            allTimeReview.TopRated.ShouldBeNull();
            allTimeReview.ReleaseYears.ShouldBeNull();
            allTimeReview.ListProgress.ShouldBeNull();
            allTimeReview.GlobalTop.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserAllTimeYearInReviewFromJson()
        {
            TraktUserAllTimeYearInReview? allTimeReview = await TestUtility.DeserializeJsonAsync<TraktUserAllTimeYearInReview>("Users\\year_in_review_all.json");

            allTimeReview.ShouldNotBeNull();

            // Stats
            allTimeReview.Stats.ShouldNotBeNull();
            allTimeReview.Stats.Shows.ShouldNotBeNull();
            allTimeReview.Stats.Shows.Distributions.ShouldNotBeNull();
            allTimeReview.Stats.Shows.Distributions.Yearly.ShouldNotBeNull();
            allTimeReview.Stats.Shows.Distributions.Yearly.Count.ShouldBe(1);
            allTimeReview.Stats.Shows.Distributions.Yearly[0].Year.ShouldBe(2024U);
            allTimeReview.Stats.Shows.Distributions.Yearly[0].Count.ShouldBe(100U);

            allTimeReview.Stats.Shows.RatingsDistribution.ShouldNotBeNull();
            allTimeReview.Stats.Shows.RatingsDistribution.Count.ShouldBe(1);
            allTimeReview.Stats.Shows.RatingsDistribution[0].Rating.ShouldBe(10U);
            allTimeReview.Stats.Shows.RatingsDistribution[0].Count.ShouldBe(25U);

            // Images
            allTimeReview.Images.ShouldNotBeNull();
            allTimeReview.Images.Cover.ShouldBe("https://walter.trakt.tv/images/cover.jpg");
            allTimeReview.Images.Story.ShouldBeNull();

            // ReleaseYears
            allTimeReview.ReleaseYears.ShouldNotBeNull();
            allTimeReview.ReleaseYears.Shows.ShouldNotBeNull();
            allTimeReview.ReleaseYears.Shows.Years.ShouldNotBeNull();
            allTimeReview.ReleaseYears.Shows.Years.Count.ShouldBe(1);
            allTimeReview.ReleaseYears.Shows.Years[0].Year.ShouldBe(2008U);
            allTimeReview.ReleaseYears.Shows.Years[0].Count.ShouldBe(1U);
            allTimeReview.ReleaseYears.Shows.Decades.ShouldNotBeNull();
            allTimeReview.ReleaseYears.Shows.Decades.Count.ShouldBe(1);
            allTimeReview.ReleaseYears.Shows.Decades[0].Decade.ShouldBe(2000U);
            allTimeReview.ReleaseYears.Shows.Decades[0].Count.ShouldBe(1U);

            allTimeReview.ReleaseYears.Movies.ShouldNotBeNull();
            allTimeReview.ReleaseYears.Movies.Years.ShouldNotBeNull();
            allTimeReview.ReleaseYears.Movies.Years.Count.ShouldBe(1);
            allTimeReview.ReleaseYears.Movies.Years[0].Year.ShouldBe(2010U);
            allTimeReview.ReleaseYears.Movies.Years[0].Count.ShouldBe(1U);
            allTimeReview.ReleaseYears.Movies.Decades.ShouldNotBeNull();
            allTimeReview.ReleaseYears.Movies.Decades.Count.ShouldBe(1);
            allTimeReview.ReleaseYears.Movies.Decades[0].Decade.ShouldBe(2010U);
            allTimeReview.ReleaseYears.Movies.Decades[0].Count.ShouldBe(1U);

            // ListProgress
            allTimeReview.ListProgress.ShouldNotBeNull();
            allTimeReview.ListProgress.Shows.ShouldNotBeNull();
            allTimeReview.ListProgress.Shows.Count.ShouldBe(1);
            allTimeReview.ListProgress.Shows[0].ID.ShouldBe(100U);
            allTimeReview.ListProgress.Shows[0].Site.ShouldBe("IMDb");
            allTimeReview.ListProgress.Shows[0].Title.ShouldBe("Top 250 TV");
            allTimeReview.ListProgress.Shows[0].Logo.ShouldBe("https://walter.trakt.tv/images/imdb.png");
            allTimeReview.ListProgress.Shows[0].Total.ShouldBe(250U);
            allTimeReview.ListProgress.Shows[0].Watched.ShouldBe(50U);
            allTimeReview.ListProgress.Shows[0].Percentage.ShouldBe(20U);

            allTimeReview.ListProgress.Movies.ShouldNotBeNull();
            allTimeReview.ListProgress.Movies.Count.ShouldBe(1);
            allTimeReview.ListProgress.Movies[0].ID.ShouldBe(101U);
            allTimeReview.ListProgress.Movies[0].Site.ShouldBe("IMDb");
            allTimeReview.ListProgress.Movies[0].Title.ShouldBe("Top 250 Movies");
            allTimeReview.ListProgress.Movies[0].Logo.ShouldBe("https://walter.trakt.tv/images/imdb.png");
            allTimeReview.ListProgress.Movies[0].Total.ShouldBe(250U);
            allTimeReview.ListProgress.Movies[0].Watched.ShouldBe(125U);
            allTimeReview.ListProgress.Movies[0].Percentage.ShouldBe(50U);

            // GlobalTop
            allTimeReview.GlobalTop.ShouldNotBeNull();
            allTimeReview.GlobalTop.Shows.ShouldNotBeNull();
            allTimeReview.GlobalTop.Shows.Count.ShouldBe(1);
            allTimeReview.GlobalTop.Shows[0].Watchers.ShouldBe(500000U);
            allTimeReview.GlobalTop.Shows[0].Watched.ShouldBe(true);
            allTimeReview.GlobalTop.Shows[0].Show.ShouldNotBeNull();
            allTimeReview.GlobalTop.Shows[0].Show!.Title.ShouldBe("Breaking Bad");

            allTimeReview.GlobalTop.Movies.ShouldNotBeNull();
            allTimeReview.GlobalTop.Movies.Count.ShouldBe(1);
            allTimeReview.GlobalTop.Movies[0].Watchers.ShouldBe(400000U);
            allTimeReview.GlobalTop.Movies[0].Watched.ShouldBe(false);
            allTimeReview.GlobalTop.Movies[0].Movie.ShouldNotBeNull();
            allTimeReview.GlobalTop.Movies[0].Movie!.Title.ShouldBe("The Dark Knight");
        }

        [Fact]
        public async Task TestTraktUserAllTimeYearInReviewToJson()
        {
            TraktUserAllTimeYearInReview? allTimeReview = await TestUtility.DeserializeJsonAsync<TraktUserAllTimeYearInReview>("Users\\year_in_review_all.json");
            allTimeReview.ShouldNotBeNull();

            string json = TestUtility.SerializeObject(allTimeReview);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"stats\"");
            json.ShouldContain("\"release_years\"");
            json.ShouldContain("\"list_progress\"");
            json.ShouldContain("\"global_top\"");
        }
    }
}
