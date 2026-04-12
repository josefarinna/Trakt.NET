using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt user post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public record class TraktUserRemovePostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktShowIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserRemovePostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added/removed from the watchlist.
        /// Otherwise, only the specified seasons and / or episodes will be added/removed from the watchlist.
        /// </para>
        /// </summary>
        public List<TraktUserRemovePostShowSeason>? Seasons { get; set; }
    }
}
