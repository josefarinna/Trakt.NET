using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt watchlist post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public record class TraktSyncWatchlistPostShow : TraktSyncRemovePostShow
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the watchlist.
        /// Otherwise, only the specified seasons and / or episodes will be added to the watchlist.
        /// </para>
        /// </summary>
        public new List<TraktSyncWatchlistPostShowSeason>? Seasons { get; set; }

        /// <summary>Gets or sets the show notes.</summary>
        public string? Notes { get; set; }
    }
}
