using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection containing the number of movies, shows, seasons, episodes and history item ids.</summary>
    public record class TraktSyncHistoryRemovePostResponseGroup : TraktSyncPostResponseGroup
    {
        /// <summary>Gets or sets the number of history item ids.</summary>
        [JsonPropertyName("history_ids")]
        public int? HistoryIDs { get; set; }
    }
}
