using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt history post show, containing the required show ids
    /// and an optional datetime, when the show was watched.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public record class TraktSyncHistoryPostShow
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt show was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt show.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktShowIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the history.
        /// Otherwise, only the specified seasons and / or episodes will be added to the history.
        /// </para>
        /// </summary>
        public List<TraktSyncHistoryPostShowSeason>? Seasons { get; set; }
    }
}
