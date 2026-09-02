using System.Collections.Generic;

namespace TraktNET
{
    /// <summary>Represents user's browsing settings.</summary>
    public record class TraktUserBrowsingSettings
    {
        /// <summary>Gets or sets the watch popup action.</summary>
        public string? WatchPopupAction { get; set; }

        /// <summary>Gets or sets whether to hide watching now.</summary>
        public bool? HideWatchingNow { get; set; }

        /// <summary>Gets or sets the list popup action.</summary>
        public string? ListPopupAction { get; set; }

        /// <summary>Gets or sets the week start day.</summary>
        public string? WeekStartDay { get; set; }

        /// <summary>Gets or sets the watch after rating.</summary>
        public string? WatchAfterRating { get; set; }

        /// <summary>Gets or sets whether to watch only once.</summary>
        public bool? WatchOnlyOnce { get; set; }

        /// <summary>Gets or sets whether to show rating prompt.</summary>
        public bool? ShowRatingPrompt { get; set; }

        /// <summary>Gets or sets the user's locale.</summary>
        public string? Locale { get; set; }

        /// <summary>Gets or sets whether other site ratings are displayed.</summary>
        public bool? OtherSiteRatings { get; set; }

        /// <summary>Gets or sets whether release date ignores runtime.</summary>
        public bool? ReleaseDateIgnoreRuntime { get; set; }

        /// <summary>Gets or sets whether to display early ratings.</summary>
        public bool? DisplayEarlyRatings { get; set; }

        /// <summary>Gets or sets whether to hide episode type tags.</summary>
        public bool? HideEpisodeTypeTags { get; set; }

        /// <summary>Gets or sets whether to hide unsaved filters prompt.</summary>
        public bool? HideUnsavedFiltersPrompt { get; set; }

        /// <summary>Gets or sets the spoilers settings.</summary>
        public TraktUserBrowsingSpoilersSettings? Spoilers { get; set; }

        /// <summary>Gets or sets the calendar settings.</summary>
        public TraktUserBrowsingCalendarSettings? Calendar { get; set; }

        /// <summary>Gets or sets the progress settings.</summary>
        public TraktUserBrowsingProgressSettings? Progress { get; set; }

        /// <summary>Gets or sets the watch now settings.</summary>
        public TraktUserWatchnowSettings? Watchnow { get; set; }

        /// <summary>Gets or sets the dark knight theme option.</summary>
        public string? DarkKnight { get; set; }

        /// <summary>Gets or sets the app theme.</summary>
        public string? AppTheme { get; set; }

        /// <summary>Gets or sets the welcome settings.</summary>
        public TraktUserBrowsingWelcomeSettings? Welcome { get; set; }

        /// <summary>Gets or sets the favorite/disliked genres settings.</summary>
        public TraktUserBrowsingGenresSettings? Genres { get; set; }

        /// <summary>Gets or sets the comment settings.</summary>
        public TraktUserBrowsingCommentsSettings? Comments { get; set; }

        /// <summary>Gets or sets the recommendations settings.</summary>
        public TraktUserBrowsingRecommendationsSettings? Recommendations { get; set; }

        /// <summary>Gets or sets the rewatching settings.</summary>
        public TraktUserBrowsingRewatchingSettings? Rewatching { get; set; }

        /// <summary>Gets or sets the profile settings.</summary>
        public TraktUserBrowsingProfileSettings? Profile { get; set; }

        /// <summary>Gets or sets the search settings.</summary>
        public TraktUserBrowsingSearchSettings? Search { get; set; }
    }

    /// <summary>Represents spoilers settings in browsing settings.</summary>
    public record class TraktUserBrowsingSpoilersSettings
    {
        /// <summary>Gets or sets the episode spoilers setting.</summary>
        public string? Episodes { get; set; }

        /// <summary>Gets or sets the show spoilers setting.</summary>
        public string? Shows { get; set; }

        /// <summary>Gets or sets the movie spoilers setting.</summary>
        public string? Movies { get; set; }

        /// <summary>Gets or sets the comment spoilers setting.</summary>
        public string? Comments { get; set; }

        /// <summary>Gets or sets the rating spoilers setting.</summary>
        public string? Ratings { get; set; }

        /// <summary>Gets or sets the actor spoilers setting.</summary>
        public string? Actors { get; set; }
    }

    /// <summary>Represents calendar settings in browsing settings.</summary>
    public record class TraktUserBrowsingCalendarSettings
    {
        /// <summary>Gets or sets the period.</summary>
        public string? Period { get; set; }

        /// <summary>Gets or sets the start day.</summary>
        public string? StartDay { get; set; }

        /// <summary>Gets or sets the layout.</summary>
        public string? Layout { get; set; }

        /// <summary>Gets or sets the image type.</summary>
        public string? ImageType { get; set; }

        /// <summary>Gets or sets whether to hide specials.</summary>
        public bool? HideSpecials { get; set; }

        /// <summary>Gets or sets whether to autoscroll.</summary>
        public bool? Autoscroll { get; set; }
    }

    /// <summary>Represents progress settings in browsing settings.</summary>
    public record class TraktUserBrowsingProgressSettings
    {
        /// <summary>Gets or sets the on deck progress settings.</summary>
        public TraktUserBrowsingProgressOnDeckSettings? OnDeck { get; set; }

        /// <summary>Gets or sets the watched progress settings.</summary>
        public TraktUserBrowsingProgressWatchedSettings? Watched { get; set; }

        /// <summary>Gets or sets the collected progress settings.</summary>
        public TraktUserBrowsingProgressCollectedSettings? Collected { get; set; }
    }

    /// <summary>Represents on deck progress settings in browsing settings.</summary>
    public record class TraktUserBrowsingProgressOnDeckSettings
    {
        /// <summary>Gets or sets the sort order.</summary>
        public string? Sort { get; set; }

        /// <summary>Gets or sets the sort direction.</summary>
        public string? SortHow { get; set; }

        /// <summary>Gets or sets whether to refresh.</summary>
        public bool? Refresh { get; set; }

        /// <summary>Gets or sets whether to show simple progress.</summary>
        public bool? SimpleProgress { get; set; }

        /// <summary>Gets or sets whether to include only favorites.</summary>
        public bool? OnlyFavorites { get; set; }
    }

    /// <summary>Represents watched progress settings in browsing settings.</summary>
    public record class TraktUserBrowsingProgressWatchedSettings
    {
        /// <summary>Gets or sets whether to refresh.</summary>
        public bool? Refresh { get; set; }

        /// <summary>Gets or sets whether to show simple progress.</summary>
        public bool? SimpleProgress { get; set; }

        /// <summary>Gets or sets whether to include specials.</summary>
        public bool? IncludeSpecials { get; set; }

        /// <summary>Gets or sets whether to include watchlisted.</summary>
        public bool? IncludeWatchlisted { get; set; }

        /// <summary>Gets or sets whether to include collected.</summary>
        public bool? IncludeCollected { get; set; }

        /// <summary>Gets or sets the sort order.</summary>
        public string? Sort { get; set; }

        /// <summary>Gets or sets the sort direction.</summary>
        public string? SortHow { get; set; }

        /// <summary>Gets or sets whether to use last activity.</summary>
        public bool? UseLastActivity { get; set; }

        /// <summary>Gets or sets whether grid view is enabled.</summary>
        public bool? GridView { get; set; }
    }

    /// <summary>Represents collected progress settings in browsing settings.</summary>
    public record class TraktUserBrowsingProgressCollectedSettings
    {
        /// <summary>Gets or sets whether to refresh.</summary>
        public bool? Refresh { get; set; }

        /// <summary>Gets or sets whether to show simple progress.</summary>
        public bool? SimpleProgress { get; set; }

        /// <summary>Gets or sets whether to include specials.</summary>
        public bool? IncludeSpecials { get; set; }

        /// <summary>Gets or sets whether to include watchlisted.</summary>
        public bool? IncludeWatchlisted { get; set; }

        /// <summary>Gets or sets whether to include watched.</summary>
        public bool? IncludeWatched { get; set; }

        /// <summary>Gets or sets the sort order.</summary>
        public string? Sort { get; set; }

        /// <summary>Gets or sets the sort direction.</summary>
        public string? SortHow { get; set; }

        /// <summary>Gets or sets whether to use last activity.</summary>
        public bool? UseLastActivity { get; set; }

        /// <summary>Gets or sets whether grid view is enabled.</summary>
        public bool? GridView { get; set; }
    }

    /// <summary>Represents welcome settings in browsing settings.</summary>
    public record class TraktUserBrowsingWelcomeSettings
    {
        /// <summary>Gets or sets the completion timestamp.</summary>
        public string? CompletedAt { get; set; }

        /// <summary>Gets or sets the exit step.</summary>
        public string? ExitStep { get; set; }
    }

    /// <summary>Represents genres settings in browsing settings.</summary>
    public record class TraktUserBrowsingGenresSettings
    {
        /// <summary>Gets or sets favorite genres.</summary>
        public IReadOnlyList<string>? Favorites { get; set; }

        /// <summary>Gets or sets disliked genres.</summary>
        public IReadOnlyList<string>? Disliked { get; set; }
    }

    /// <summary>Represents comments settings in browsing settings.</summary>
    public record class TraktUserBrowsingCommentsSettings
    {
        /// <summary>Gets or sets blocked user IDs.</summary>
        public IReadOnlyList<string>? BlockedUids { get; set; }
    }

    /// <summary>Represents recommendations settings in browsing settings.</summary>
    public record class TraktUserBrowsingRecommendationsSettings
    {
        /// <summary>Gets or sets whether to ignore collected.</summary>
        public bool? IgnoreCollected { get; set; }

        /// <summary>Gets or sets whether to ignore watchlisted.</summary>
        public bool? IgnoreWatchlisted { get; set; }
    }

    /// <summary>Represents rewatching settings in browsing settings.</summary>
    public record class TraktUserBrowsingRewatchingSettings
    {
        /// <summary>Gets or sets whether to adjust percentage.</summary>
        public bool? AdjustPercentage { get; set; }
    }

    /// <summary>Represents profile settings in browsing settings.</summary>
    public record class TraktUserBrowsingProfileSettings
    {
        /// <summary>Gets or sets profile favorites settings.</summary>
        public TraktUserBrowsingProfileFavoritesSettings? Favorites { get; set; }

        /// <summary>Gets or sets profile most watched shows settings.</summary>
        public TraktUserBrowsingProfileShowsSettings? MostWatchedShows { get; set; }

        /// <summary>Gets or sets profile most watched movies settings.</summary>
        public TraktUserBrowsingProfileMoviesSettings? MostWatchedMovies { get; set; }
    }

    /// <summary>Represents profile favorites settings in browsing settings.</summary>
    public record class TraktUserBrowsingProfileFavoritesSettings
    {
        /// <summary>Gets or sets the sort by field.</summary>
        public string? SortBy { get; set; }

        /// <summary>Gets or sets the sort direction.</summary>
        public string? SortHow { get; set; }
    }

    /// <summary>Represents profile shows settings in browsing settings.</summary>
    public record class TraktUserBrowsingProfileShowsSettings
    {
        /// <summary>Gets or sets the sort by field.</summary>
        public string? SortBy { get; set; }

        /// <summary>Gets or sets the active tab.</summary>
        public string? Tab { get; set; }
    }

    /// <summary>Represents profile movies settings in browsing settings.</summary>
    public record class TraktUserBrowsingProfileMoviesSettings
    {
        /// <summary>Gets or sets the sort by field.</summary>
        public string? SortBy { get; set; }

        /// <summary>Gets or sets the active tab.</summary>
        public string? Tab { get; set; }
    }

    /// <summary>Represents search settings in browsing settings.</summary>
    public record class TraktUserBrowsingSearchSettings
    {
        /// <summary>Gets or sets search image type.</summary>
        public string? ImageType { get; set; }

        /// <summary>Gets or sets recent search queries.</summary>
        public IReadOnlyList<TraktUserBrowsingRecentQuery>? RecentQueries { get; set; }
    }

    /// <summary>Represents a recent search query in browsing settings.</summary>
    public record class TraktUserBrowsingRecentQuery
    {
        /// <summary>Gets or sets the search query.</summary>
        public string? Query { get; set; }

        /// <summary>Gets or sets the query type.</summary>
        public string? Type { get; set; }

        /// <summary>Gets or sets the creation timestamp.</summary>
        public long? CreatedAt { get; set; }
    }
}
