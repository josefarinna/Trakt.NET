using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt favorites post show, containing the required show ids and optional show title, year and notes.</summary>
    public record class TraktSyncFavoritesPostShow : TraktSyncRemovePostShow
    {
        /// <summary>Gets or sets the optional notes for the Trakt show.</summary>
        public string? Notes { get; set; }
    }
}
