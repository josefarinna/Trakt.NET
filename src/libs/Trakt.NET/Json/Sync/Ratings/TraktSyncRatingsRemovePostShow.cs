using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public record class TraktSyncRatingsRemovePostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktShowIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryRemovePostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the history.
        /// Otherwise, only the specified seasons and / or episodes will be added to the history.
        /// </para>
        /// </summary>
        public List<TraktSyncHistoryRemovePostShowSeason>? Seasons { get; set; }
    }
}
