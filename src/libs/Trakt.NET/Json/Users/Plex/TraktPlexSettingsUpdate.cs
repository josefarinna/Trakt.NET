namespace TraktNET
{
    /// <summary>Represents the data to update Plex settings.</summary>
    public record class TraktPlexSettingsUpdate
    {
        /// <summary>Gets or sets the sync details to update.</summary>
        public TraktPlexSyncUpdate? Sync { get; set; }

        /// <summary>Gets or sets the scrobbler details to update.</summary>
        public TraktPlexScrobblerUpdate? Scrobbler { get; set; }

        /// <summary>Gets or sets the webhook details to update.</summary>
        public TraktPlexWebhookUpdate? Webhook { get; set; }

        /// <summary>Gets or sets the sync triggering details.</summary>
        public TraktPlexTriggerSync? TriggerSync { get; set; }
    }

    /// <summary>Represents the Plex sync update settings.</summary>
    public record class TraktPlexSyncUpdate
    {
        /// <summary>Gets or sets the sync selection.</summary>
        public TraktPlexSelection? Selection { get; set; }

        /// <summary>Gets or sets the batch-sync toggles.</summary>
        public TraktPlexSyncTogglesUpdate? Toggles { get; set; }
    }

    /// <summary>Represents the batch-sync update toggles.</summary>
    public record class TraktPlexSyncTogglesUpdate
    {
        /// <summary>Gets or sets the movie sync toggles.</summary>
        public TraktPlexMovieSyncTogglesUpdate? Movie { get; set; }

        /// <summary>Gets or sets the show sync toggles.</summary>
        public TraktPlexShowSyncTogglesUpdate? Show { get; set; }

        /// <summary>Gets or sets the season sync toggles.</summary>
        public TraktPlexSeasonSyncTogglesUpdate? Season { get; set; }

        /// <summary>Gets or sets the episode sync toggles.</summary>
        public TraktPlexEpisodeSyncTogglesUpdate? Episode { get; set; }
    }

    /// <summary>Represents the movie batch-sync update toggles.</summary>
    public record class TraktPlexMovieSyncTogglesUpdate
    {
        /// <summary>Gets or sets a value indicating whether to sync watching status.</summary>
        public bool? Watching { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync watched status.</summary>
        public bool? Watched { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync ratings.</summary>
        public bool? Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync collected status.</summary>
        public bool? Collected { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync watchlist.</summary>
        public bool? Watchlist { get; set; }
    }

    /// <summary>Represents the show batch-sync update toggles.</summary>
    public record class TraktPlexShowSyncTogglesUpdate
    {
        /// <summary>Gets or sets a value indicating whether to sync ratings.</summary>
        public bool? Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync watchlist.</summary>
        public bool? Watchlist { get; set; }
    }

    /// <summary>Represents the season batch-sync update toggles.</summary>
    public record class TraktPlexSeasonSyncTogglesUpdate
    {
        /// <summary>Gets or sets a value indicating whether to sync ratings.</summary>
        public bool? Rated { get; set; }
    }

    /// <summary>Represents the episode batch-sync update toggles.</summary>
    public record class TraktPlexEpisodeSyncTogglesUpdate
    {
        /// <summary>Gets or sets a value indicating whether to sync watching status.</summary>
        public bool? Watching { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync watched status.</summary>
        public bool? Watched { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync ratings.</summary>
        public bool? Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync collected status.</summary>
        public bool? Collected { get; set; }
    }

    /// <summary>Represents the Plex scrobbler update details.</summary>
    public record class TraktPlexScrobblerUpdate
    {
        /// <summary>Gets or sets the scrobbler toggles.</summary>
        public TraktPlexScrobblerTogglesUpdate? Toggles { get; set; }
    }

    /// <summary>Represents the scrobbler update toggles.</summary>
    public record class TraktPlexScrobblerTogglesUpdate
    {
        /// <summary>Gets or sets the movie scrobbler toggles.</summary>
        public TraktPlexMovieScrobblerTogglesUpdate? Movie { get; set; }

        /// <summary>Gets or sets the show scrobbler toggles.</summary>
        public TraktPlexShowScrobblerTogglesUpdate? Show { get; set; }

        /// <summary>Gets or sets the season scrobbler toggles.</summary>
        public TraktPlexSeasonScrobblerTogglesUpdate? Season { get; set; }

        /// <summary>Gets or sets the episode scrobbler toggles.</summary>
        public TraktPlexEpisodeScrobblerTogglesUpdate? Episode { get; set; }
    }

    /// <summary>Represents the movie scrobbler update toggles.</summary>
    public record class TraktPlexMovieScrobblerTogglesUpdate
    {
        /// <summary>Gets or sets a value indicating whether to scrobble watching status.</summary>
        public bool? Watching { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble watched status.</summary>
        public bool? Watched { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble ratings.</summary>
        public bool? Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble collected status.</summary>
        public bool? Collected { get; set; }
    }

    /// <summary>Represents the show scrobbler update toggles.</summary>
    public record class TraktPlexShowScrobblerTogglesUpdate
    {
        /// <summary>Gets or sets a value indicating whether to scrobble ratings.</summary>
        public bool? Rated { get; set; }
    }

    /// <summary>Represents the season scrobbler update toggles.</summary>
    public record class TraktPlexSeasonScrobblerTogglesUpdate
    {
        /// <summary>Gets or sets a value indicating whether to scrobble ratings.</summary>
        public bool? Rated { get; set; }
    }

    /// <summary>Represents the episode scrobbler update toggles.</summary>
    public record class TraktPlexEpisodeScrobblerTogglesUpdate
    {
        /// <summary>Gets or sets a value indicating whether to scrobble watching status.</summary>
        public bool? Watching { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble watched status.</summary>
        public bool? Watched { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble ratings.</summary>
        public bool? Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble collected status.</summary>
        public bool? Collected { get; set; }
    }

    /// <summary>Represents the Plex webhook update details.</summary>
    public record class TraktPlexWebhookUpdate
    {
        /// <summary>Gets or sets comma-separated Plex home usernames to scrobble for.</summary>
        public string? HomeUsers { get; set; }
    }

    /// <summary>Represents the sync triggering options for Plex settings update.</summary>
    public record class TraktPlexTriggerSync
    {
        /// <summary>Gets or sets whether to trigger sync for all watched data.</summary>
        public bool? WatchedAllData { get; set; }

        /// <summary>Gets or sets whether to trigger sync for all collection data.</summary>
        public bool? CollectionAllData { get; set; }

        /// <summary>Gets or sets whether to trigger sync for all ratings data.</summary>
        public bool? RatingsAllData { get; set; }

        /// <summary>Gets or sets whether to trigger sync for all watchlist data.</summary>
        public bool? WatchlistAllData { get; set; }
    }
}
