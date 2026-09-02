namespace TraktNET.Json.Users
{
    public sealed class TraktUserBrowsingSettingsTests
    {
        [Fact]
        public void TestTraktUserBrowsingSettingsConstructor()
        {
            var settings = new TraktUserBrowsingSettings();

            settings.WatchPopupAction.ShouldBeNull();
            settings.HideWatchingNow.ShouldBeNull();
            settings.ListPopupAction.ShouldBeNull();
            settings.WeekStartDay.ShouldBeNull();
            settings.WatchAfterRating.ShouldBeNull();
            settings.WatchOnlyOnce.ShouldBeNull();
            settings.ShowRatingPrompt.ShouldBeNull();
            settings.Locale.ShouldBeNull();
            settings.OtherSiteRatings.ShouldBeNull();
            settings.ReleaseDateIgnoreRuntime.ShouldBeNull();
            settings.DisplayEarlyRatings.ShouldBeNull();
            settings.HideEpisodeTypeTags.ShouldBeNull();
            settings.HideUnsavedFiltersPrompt.ShouldBeNull();
            settings.Spoilers.ShouldBeNull();
            settings.Calendar.ShouldBeNull();
            settings.Progress.ShouldBeNull();
            settings.Watchnow.ShouldBeNull();
            settings.DarkKnight.ShouldBeNull();
            settings.AppTheme.ShouldBeNull();
            settings.Welcome.ShouldBeNull();
            settings.Genres.ShouldBeNull();
            settings.Comments.ShouldBeNull();
            settings.Recommendations.ShouldBeNull();
            settings.Rewatching.ShouldBeNull();
            settings.Profile.ShouldBeNull();
            settings.Search.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserBrowsingSettingsFromJson()
        {
            TraktUserBrowsingSettings? settings = await TestUtility.DeserializeJsonAsync<TraktUserBrowsingSettings>("Users\\userbrowsingsettings.json");

            settings.ShouldNotBeNull();
            settings.WatchPopupAction.ShouldBe("checkin");
            settings.HideWatchingNow.ShouldBe(false);
            settings.ListPopupAction.ShouldBe("add");
            settings.WeekStartDay.ShouldBe("monday");
            settings.WatchAfterRating.ShouldBe("always");
            settings.WatchOnlyOnce.ShouldBe(true);
            settings.ShowRatingPrompt.ShouldBe(false);
            settings.Locale.ShouldBe("en-US");
            settings.OtherSiteRatings.ShouldBe(true);
            settings.ReleaseDateIgnoreRuntime.ShouldBe(false);
            settings.DisplayEarlyRatings.ShouldBe(true);
            settings.HideEpisodeTypeTags.ShouldBe(false);
            settings.HideUnsavedFiltersPrompt.ShouldBe(true);

            // Spoilers
            settings.Spoilers.ShouldNotBeNull();
            settings.Spoilers.Episodes.ShouldBe("hide");
            settings.Spoilers.Shows.ShouldBe("hide");
            settings.Spoilers.Movies.ShouldBe("hide");
            settings.Spoilers.Comments.ShouldBe("hide");
            settings.Spoilers.Ratings.ShouldBe("hide");
            settings.Spoilers.Actors.ShouldBe("hide");

            // Calendar
            settings.Calendar.ShouldNotBeNull();
            settings.Calendar.Period.ShouldBe("month");
            settings.Calendar.StartDay.ShouldBe("today");
            settings.Calendar.Layout.ShouldBe("grid");
            settings.Calendar.ImageType.ShouldBe("fanart");
            settings.Calendar.HideSpecials.ShouldBe(true);
            settings.Calendar.Autoscroll.ShouldBe(false);

            // Progress
            settings.Progress.ShouldNotBeNull();
            settings.Progress.OnDeck.ShouldNotBeNull();
            settings.Progress.OnDeck.Sort.ShouldBe("recent");
            settings.Progress.OnDeck.SortHow.ShouldBe("desc");
            settings.Progress.OnDeck.Refresh.ShouldBe(true);
            settings.Progress.OnDeck.SimpleProgress.ShouldBe(false);
            settings.Progress.OnDeck.OnlyFavorites.ShouldBe(true);

            settings.Progress.Watched.ShouldNotBeNull();
            settings.Progress.Watched.Refresh.ShouldBe(true);
            settings.Progress.Watched.SimpleProgress.ShouldBe(false);
            settings.Progress.Watched.IncludeSpecials.ShouldBe(true);
            settings.Progress.Watched.IncludeWatchlisted.ShouldBe(false);
            settings.Progress.Watched.IncludeCollected.ShouldBe(true);
            settings.Progress.Watched.Sort.ShouldBe("title");
            settings.Progress.Watched.SortHow.ShouldBe("asc");
            settings.Progress.Watched.UseLastActivity.ShouldBe(true);
            settings.Progress.Watched.GridView.ShouldBe(false);

            settings.Progress.Collected.ShouldNotBeNull();
            settings.Progress.Collected.Refresh.ShouldBe(true);
            settings.Progress.Collected.SimpleProgress.ShouldBe(false);
            settings.Progress.Collected.IncludeSpecials.ShouldBe(true);
            settings.Progress.Collected.IncludeWatchlisted.ShouldBe(false);
            settings.Progress.Collected.IncludeWatched.ShouldBe(true);
            settings.Progress.Collected.Sort.ShouldBe("title");
            settings.Progress.Collected.SortHow.ShouldBe("asc");
            settings.Progress.Collected.UseLastActivity.ShouldBe(true);
            settings.Progress.Collected.GridView.ShouldBe(false);

            // Watchnow
            settings.Watchnow.ShouldNotBeNull();
            settings.Watchnow.Country.ShouldBe("us");
            settings.Watchnow.Favorites.ShouldNotBeNull();
            settings.Watchnow.Favorites.Count.ShouldBe(2);
            settings.Watchnow.Favorites.ShouldBe([ "netflix", "hulu" ]);
            settings.Watchnow.OnlyFavorites.ShouldBe(false);

            settings.DarkKnight.ShouldBe("always");
            settings.AppTheme.ShouldBe("dark");

            // Welcome
            settings.Welcome.ShouldNotBeNull();
            settings.Welcome.CompletedAt.ShouldBe("2024-01-01T00:00:00.000Z");
            settings.Welcome.ExitStep.ShouldBe("profile");

            // Genres
            settings.Genres.ShouldNotBeNull();
            settings.Genres.Favorites.ShouldNotBeNull();
            settings.Genres.Favorites.ShouldBe([ "action", "comedy" ]);
            settings.Genres.Disliked.ShouldNotBeNull();
            settings.Genres.Disliked.ShouldBe([ "horror" ]);

            // Comments
            settings.Comments.ShouldNotBeNull();
            settings.Comments.BlockedUids.ShouldNotBeNull();
            settings.Comments.BlockedUids.ShouldBe([ "annoying_user" ]);

            // Recommendations
            settings.Recommendations.ShouldNotBeNull();
            settings.Recommendations.IgnoreCollected.ShouldBe(true);
            settings.Recommendations.IgnoreWatchlisted.ShouldBe(true);

            // Rewatching
            settings.Rewatching.ShouldNotBeNull();
            settings.Rewatching.AdjustPercentage.ShouldBe(false);

            // Profile
            settings.Profile.ShouldNotBeNull();
            settings.Profile.Favorites.ShouldNotBeNull();
            settings.Profile.Favorites.SortBy.ShouldBe("rank");
            settings.Profile.Favorites.SortHow.ShouldBe("asc");

            settings.Profile.MostWatchedShows.ShouldNotBeNull();
            settings.Profile.MostWatchedShows.SortBy.ShouldBe("plays");
            settings.Profile.MostWatchedShows.Tab.ShouldBe("weekly");

            settings.Profile.MostWatchedMovies.ShouldNotBeNull();
            settings.Profile.MostWatchedMovies.SortBy.ShouldBe("plays");
            settings.Profile.MostWatchedMovies.Tab.ShouldBe("weekly");

            // Search
            settings.Search.ShouldNotBeNull();
            settings.Search.ImageType.ShouldBe("poster");
            settings.Search.RecentQueries.ShouldNotBeNull();
            settings.Search.RecentQueries.Count.ShouldBe(1);
            settings.Search.RecentQueries[0].Query.ShouldBe("star wars");
            settings.Search.RecentQueries[0].Type.ShouldBe("movie");
            settings.Search.RecentQueries[0].CreatedAt.ShouldBe(1719878400000L);
        }
    }
}
