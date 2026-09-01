using System;
using System.Collections.Generic;

namespace TraktNET
{
    /// <summary>Represents Plex connection settings for a user.</summary>
    public record class TraktPlexSettings
    {
        /// <summary>Gets or sets the connection details.</summary>
        public TraktPlexConnection? Connection { get; set; }

        /// <summary>Gets or sets the webhook details.</summary>
        public TraktPlexWebhook? Webhook { get; set; }

        /// <summary>Gets or sets the sync details.</summary>
        public TraktPlexSync? Sync { get; set; }

        /// <summary>Gets or sets the scrobbler details.</summary>
        public TraktPlexScrobbler? Scrobbler { get; set; }
    }

    /// <summary>Represents the Plex connection status.</summary>
    public record class TraktPlexConnection
    {
        /// <summary>Gets or sets whether a Plex authorization exists.</summary>
        public bool Connected { get; set; }

        /// <summary>Gets or sets the stored Plex username/uid.</summary>
        public string? Username { get; set; }
    }

    /// <summary>Represents the Plex scrobbler webhook details.</summary>
    public record class TraktPlexWebhook
    {
        /// <summary>Gets or sets the webhook URL.</summary>
        public string? Url { get; set; }

        /// <summary>Gets or sets when the webhook last fired.</summary>
        public DateTimeOffset? LastEventAt { get; set; }

        /// <summary>Gets or sets the number of webhook events.</summary>
        public int EventCount { get; set; }

        /// <summary>Gets or sets comma-separated Plex home usernames to scrobble for.</summary>
        public string? HomeUsers { get; set; }
    }

    /// <summary>Represents the Plex sync settings.</summary>
    public record class TraktPlexSync
    {
        /// <summary>Gets or sets whether the initial sync has been set up.</summary>
        public bool Configured { get; set; }

        /// <summary>Gets or sets whether a persisted Plex-sync error is active.</summary>
        public bool Error { get; set; }

        /// <summary>Gets or sets the maximum number of Plex servers the user may sync.</summary>
        public uint? ServerLimit { get; set; }

        /// <summary>Gets or sets the sync selection.</summary>
        public TraktPlexSelection? Selection { get; set; }

        /// <summary>Gets or sets the batch-sync toggles.</summary>
        public TraktPlexSyncToggles? Toggles { get; set; }
    }

    /// <summary>Represents the sync selection for Plex.</summary>
    public record class TraktPlexSelection
    {
        /// <summary>Gets or sets the server IDs.</summary>
        public List<string>? ServerIds { get; set; }

        /// <summary>Gets or sets the library IDs.</summary>
        public List<TraktPlexLibrary>? LibraryIds { get; set; }

        /// <summary>Gets or sets the user IDs.</summary>
        public List<string>? UserIds { get; set; }
    }

    /// <summary>Represents a Plex library identifier.</summary>
    public record class TraktPlexLibrary
    {
        /// <summary>Gets or sets the server ID.</summary>
        public string? ServerId { get; set; }

        /// <summary>Gets or sets the UUID.</summary>
        public string? Uuid { get; set; }
    }

    /// <summary>Represents the batch-sync toggles.</summary>
    public record class TraktPlexSyncToggles
    {
        /// <summary>Gets or sets the movie sync toggles.</summary>
        public TraktPlexMovieSyncToggles? Movie { get; set; }

        /// <summary>Gets or sets the show sync toggles.</summary>
        public TraktPlexShowSyncToggles? Show { get; set; }

        /// <summary>Gets or sets the season sync toggles.</summary>
        public TraktPlexSeasonSyncToggles? Season { get; set; }

        /// <summary>Gets or sets the episode sync toggles.</summary>
        public TraktPlexEpisodeSyncToggles? Episode { get; set; }
    }

    /// <summary>Represents the movie batch-sync toggles.</summary>
    public record class TraktPlexMovieSyncToggles
    {
        /// <summary>Gets or sets a value indicating whether to sync watching status.</summary>
        public bool Watching { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync watched status.</summary>
        public bool Watched { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync ratings.</summary>
        public bool Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync collected status.</summary>
        public bool Collected { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync watchlist.</summary>
        public bool Watchlist { get; set; }
    }

    /// <summary>Represents the show batch-sync toggles.</summary>
    public record class TraktPlexShowSyncToggles
    {
        /// <summary>Gets or sets a value indicating whether to sync ratings.</summary>
        public bool Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync watchlist.</summary>
        public bool Watchlist { get; set; }
    }

    /// <summary>Represents the season batch-sync toggles.</summary>
    public record class TraktPlexSeasonSyncToggles
    {
        /// <summary>Gets or sets a value indicating whether to sync ratings.</summary>
        public bool Rated { get; set; }
    }

    /// <summary>Represents the episode batch-sync toggles.</summary>
    public record class TraktPlexEpisodeSyncToggles
    {
        /// <summary>Gets or sets a value indicating whether to sync watching status.</summary>
        public bool Watching { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync watched status.</summary>
        public bool Watched { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync ratings.</summary>
        public bool Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to sync collected status.</summary>
        public bool Collected { get; set; }
    }

    /// <summary>Represents the Plex scrobbler details.</summary>
    public record class TraktPlexScrobbler
    {
        /// <summary>Gets or sets the scrobbler toggles.</summary>
        public TraktPlexScrobblerToggles? Toggles { get; set; }
    }

    /// <summary>Represents the scrobbler toggles.</summary>
    public record class TraktPlexScrobblerToggles
    {
        /// <summary>Gets or sets the movie scrobbler toggles.</summary>
        public TraktPlexMovieScrobblerToggles? Movie { get; set; }

        /// <summary>Gets or sets the show scrobbler toggles.</summary>
        public TraktPlexShowScrobblerToggles? Show { get; set; }

        /// <summary>Gets or sets the season scrobbler toggles.</summary>
        public TraktPlexSeasonScrobblerToggles? Season { get; set; }

        /// <summary>Gets or sets the episode scrobbler toggles.</summary>
        public TraktPlexEpisodeScrobblerToggles? Episode { get; set; }
    }

    /// <summary>Represents the movie scrobbler toggles.</summary>
    public record class TraktPlexMovieScrobblerToggles
    {
        /// <summary>Gets or sets a value indicating whether to scrobble watching status.</summary>
        public bool Watching { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble watched status.</summary>
        public bool Watched { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble ratings.</summary>
        public bool Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble collected status.</summary>
        public bool Collected { get; set; }
    }

    /// <summary>Represents the show scrobbler toggles.</summary>
    public record class TraktPlexShowScrobblerToggles
    {
        /// <summary>Gets or sets a value indicating whether to scrobble ratings.</summary>
        public bool Rated { get; set; }
    }

    /// <summary>Represents the season scrobbler toggles.</summary>
    public record class TraktPlexSeasonScrobblerToggles
    {
        /// <summary>Gets or sets a value indicating whether to scrobble ratings.</summary>
        public bool Rated { get; set; }
    }

    /// <summary>Represents the episode scrobbler toggles.</summary>
    public record class TraktPlexEpisodeScrobblerToggles
    {
        /// <summary>Gets or sets a value indicating whether to scrobble watching status.</summary>
        public bool Watching { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble watched status.</summary>
        public bool Watched { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble ratings.</summary>
        public bool Rated { get; set; }

        /// <summary>Gets or sets a value indicating whether to scrobble collected status.</summary>
        public bool Collected { get; set; }
    }
}
