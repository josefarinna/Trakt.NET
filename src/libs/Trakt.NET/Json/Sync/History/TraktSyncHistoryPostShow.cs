using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt history post show, containing the required show ids
    /// and an optional datetime, when the show was watched.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public record class TraktSyncHistoryPostShow : TraktSyncRemovePostShow
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt show was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the history.
        /// Otherwise, only the specified seasons and / or episodes will be added to the history.
        /// </para>
        /// </summary>
        public new List<TraktSyncHistoryPostShowSeason>? Seasons { get; set; }
    }
}
