using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt favorites post show, containing the required show ids and optional show title, year and notes.</summary>
    public record class TraktSyncFavoritesPostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktShowIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }

        /// <summary>Gets or sets the optional notes for the Trakt show.</summary>
        public string? Notes { get; set; }
    }
}
