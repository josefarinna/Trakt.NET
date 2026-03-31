using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection containing the ids of movies, shows, seasons, episodes and history items, which were not found.</summary>
    public record class TraktSyncHistoryRemovePostResponseNotFoundGroup : TraktSyncPostResponseNotFoundGroup
    {
        /// <summary>Gets or sets a list of Trakt history item ids, which were not found.</summary>
        [JsonPropertyName("history_ids")]
        public List<ulong>? HistoryIDs { get; set; }
    }
}
