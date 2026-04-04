using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt favorites post movie, containing the required movie ids and optional movie title, year and notes.</summary>
    public record class TraktSyncFavoritesPostMovie : TraktSyncRemovePostMovie
    {
        /// <summary>Gets or sets the optional notes for the Trakt movie.</summary>
        public string? Notes { get; set; }
    }
}
