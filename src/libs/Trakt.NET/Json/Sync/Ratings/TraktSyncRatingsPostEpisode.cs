using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post episode, containing the required episode ids,
    /// a rating and an optional datetime, when the episode was rated.
    /// </summary>
    public record class TraktSyncRatingsPostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }

        /// <summary>Gets or sets the rating for the episode.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was rated.</summary>
        public DateTime? RatedAt { get; set; }

        public void Validate()
        {
            if (Rating != null && (Rating < 1 || Rating > 10))
            {
                throw new ArgumentOutOfRangeException(nameof(Rating), "Rating must be between 1 and 10.");
            }
        }
    }
}
