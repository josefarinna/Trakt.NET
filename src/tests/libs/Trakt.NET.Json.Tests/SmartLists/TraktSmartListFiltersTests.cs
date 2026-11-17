namespace TraktNET.Json.SmartLists
{
    public sealed class TraktSmartListFiltersTests
    {
        [Fact]
        public void TestTraktSmartListFiltersConstructor()
        {
            var filters = new TraktSmartListFilters();

            filters.Genres.ShouldBeNull();
            filters.GenresOperator.ShouldBeNull();
            filters.Subgenres.ShouldBeNull();
            filters.Certifications.ShouldBeNull();
            filters.Languages.ShouldBeNull();
            filters.Countries.ShouldBeNull();
            filters.Statuses.ShouldBeNull();
            filters.Networks.ShouldBeNull();
            filters.Keywords.ShouldBeNull();
            filters.KeywordsOperator.ShouldBeNull();
            filters.Watchnow.ShouldBeNull();
            filters.WatchnowCountry.ShouldBeNull();
            filters.Years.ShouldBeNull();
            filters.Ratings.ShouldBeNull();
            filters.Runtimes.ShouldBeNull();
            filters.IMDBRatings.ShouldBeNull();
            filters.RottenTomatoesMeters.ShouldBeNull();
            filters.RottenTomatoesUserMeters.ShouldBeNull();
            filters.LetterboxdRatings.ShouldBeNull();
            filters.MALRatings.ShouldBeNull();
            filters.ParentalNudity.ShouldBeNull();
            filters.ParentalViolence.ShouldBeNull();
            filters.ParentalProfanity.ShouldBeNull();
            filters.ParentalAlcohol.ShouldBeNull();
            filters.ParentalFrightening.ShouldBeNull();
            filters.ParentalIncludeUnrated.ShouldBeNull();
            filters.IgnoreWatched.ShouldBeNull();
            filters.IgnoreWatchlisted.ShouldBeNull();
            filters.IgnoreWatching.ShouldBeNull();
            filters.IgnoreUnreleased.ShouldBeNull();
            filters.IgnoreReleased.ShouldBeNull();
            filters.IgnoreEnded.ShouldBeNull();
            filters.IgnoreAiring.ShouldBeNull();
            filters.IgnoreNoReleaseDate.ShouldBeNull();
            filters.Studios.ShouldBeNull();
            filters.People.ShouldBeNull();
            filters.PeopleOperator.ShouldBeNull();
            filters.PeopleRole.ShouldBeNull();
            filters.ReleasedWithinDays.ShouldBeNull();
            filters.TMDBRatings.ShouldBeNull();
            filters.Metascores.ShouldBeNull();
            filters.Votes.ShouldBeNull();
            filters.IMDBVotes.ShouldBeNull();
            filters.Awards.ShouldBeNull();
            filters.AwardYears.ShouldBeNull();
            filters.AwardWon.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSmartListFiltersToJson()
        {
            var filters = new TraktSmartListFilters
            {
                Awards = ["oscars", "emmys"],
                AwardYears = [2020U, 2025U],
                AwardWon = true
            };

            string json = TestUtility.SerializeObject(filters);
            json.ShouldNotBeNullOrEmpty();
            json.ShouldContain("\"awards\":[\"oscars\",\"emmys\"]");
            json.ShouldContain("\"award_years\":[2020,2025]");
            json.ShouldContain("\"award_won\":true");
        }
    }
}
