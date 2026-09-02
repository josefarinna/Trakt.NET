namespace TraktNET.Json.Users
{
    public sealed class TraktUserMonthInReviewTests
    {
        [Fact]
        public void TestTraktUserMonthInReviewDefaultConstructor()
        {
            var monthInReview = new TraktUserMonthInReview();

            monthInReview.Stats.ShouldBeNull();
            monthInReview.Images.ShouldBeNull();
            monthInReview.FirstWatched.ShouldBeNull();
            monthInReview.LastWatched.ShouldBeNull();
            monthInReview.Countries.ShouldBeNull();
            monthInReview.Trends.ShouldBeNull();
            monthInReview.Thanks.ShouldBeNull();
            monthInReview.StreamingServices.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserMonthInReviewFromJson()
        {
            TraktUserMonthInReview? monthInReview = await TestUtility.DeserializeJsonAsync<TraktUserMonthInReview>("Users\\month_in_review.json");

            monthInReview.ShouldNotBeNull();

            // Stats - All
            monthInReview.Stats.ShouldNotBeNull();
            monthInReview.Stats.All.ShouldNotBeNull();
            monthInReview.Stats.All.Minutes.ShouldNotBeNull();
            monthInReview.Stats.All.Minutes.Total.ShouldBe(10416U);
            monthInReview.Stats.All.Minutes.Yearly.ShouldBe(125000U);
            monthInReview.Stats.All.Minutes.Monthly.ShouldBe(10416U);
            monthInReview.Stats.All.Minutes.Weekly.ShouldBe(2403U);
            monthInReview.Stats.All.Minutes.Daily.ShouldBe(342U);

            monthInReview.Stats.All.PlayCounts.ShouldNotBeNull();
            monthInReview.Stats.All.PlayCounts.Total.ShouldBe(208U);
            monthInReview.Stats.All.CollectedCounts.ShouldNotBeNull();
            monthInReview.Stats.All.CollectedCounts.Total.ShouldBe(41U);
            monthInReview.Stats.All.RatingsCounts.ShouldNotBeNull();
            monthInReview.Stats.All.RatingsCounts.Total.ShouldBe(29U);
            monthInReview.Stats.All.CommentsCounts.ShouldNotBeNull();
            monthInReview.Stats.All.CommentsCounts.Total.ShouldBe(6U);
            monthInReview.Stats.All.ListsCounts.ShouldNotBeNull();
            monthInReview.Stats.All.ListsCounts.Total.ShouldBe(1U);

            // Images
            monthInReview.Images.ShouldNotBeNull();
            monthInReview.Images.Cover.ShouldBe("https://walter.trakt.tv/images/cover.jpg");
            monthInReview.Images.Story.ShouldBe("https://walter.trakt.tv/images/story.jpg");

            // FirstWatched
            monthInReview.FirstWatched.ShouldNotBeNull();
            monthInReview.FirstWatched.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-01T20:00:00.000Z"));
            monthInReview.FirstWatched.Type.ShouldBe(TraktSyncItemType.Movie);
            monthInReview.FirstWatched.Movie.ShouldNotBeNull();
            monthInReview.FirstWatched.Movie.Title.ShouldBe("Inception");

            // LastWatched
            monthInReview.LastWatched.ShouldNotBeNull();
            monthInReview.LastWatched.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-31T23:30:00.000Z"));
            monthInReview.LastWatched.Type.ShouldBe(TraktSyncItemType.Episode);
            monthInReview.LastWatched.Episode.ShouldNotBeNull();
            monthInReview.LastWatched.Episode.Title.ShouldBe("Winter Is Coming");
            monthInReview.LastWatched.Show.ShouldNotBeNull();
            monthInReview.LastWatched.Show.Title.ShouldBe("Game of Thrones");

            // Countries
            monthInReview.Countries.ShouldNotBeNull();
            monthInReview.Countries.Shows.ShouldNotBeNull();
            monthInReview.Countries.Shows.CountryCount.ShouldBe(2U);
            monthInReview.Countries.Shows.Countries.ShouldNotBeNull();
            monthInReview.Countries.Shows.Countries.Count.ShouldBe(2);

            // Trends
            monthInReview.Trends.ShouldNotBeNull();
            monthInReview.Trends.Shows.ShouldNotBeNull();
            monthInReview.Trends.Shows.Count.ShouldBe(1);
            monthInReview.Trends.Shows[0].Month.ShouldBe(10U);
            monthInReview.Trends.Shows[0].MonthName.ShouldBe("October");

            // Thanks
            monthInReview.Thanks.ShouldNotBeNull();
            monthInReview.Thanks.Shows.ShouldNotBeNull();
            monthInReview.Thanks.Shows.Count.ShouldBe(1);
            monthInReview.Thanks.Shows[0].Show.ShouldNotBeNull();
            monthInReview.Thanks.Shows[0].Show!.Title.ShouldBe("Breaking Bad");

            // Streaming Services
            monthInReview.StreamingServices.ShouldNotBeNull();
            monthInReview.StreamingServices.Country.ShouldBe("us");
            monthInReview.StreamingServices.Services.ShouldNotBeNull();
            monthInReview.StreamingServices.Services.Count.ShouldBe(2);

            TraktUserReviewStreamingService service1 = monthInReview.StreamingServices.Services[0];
            service1.Source.ShouldBe("netflix");
            service1.Name.ShouldBe("Netflix");
            service1.Shows.ShouldBe(12U);
            service1.Movies.ShouldBe(5U);
            service1.All.ShouldBe(17U);

            TraktUserReviewStreamingService service2 = monthInReview.StreamingServices.Services[1];
            service2.Source.ShouldBe("hbo_max");
            service2.Name.ShouldBe("Max");
            service2.Shows.ShouldBe(8U);
            service2.Movies.ShouldBe(3U);
            service2.All.ShouldBe(11U);
        }
    }
}
