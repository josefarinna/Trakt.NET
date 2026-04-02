using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post movie, containing the required movie ids,
    /// a rating and an optional datetime, when the movie was rated.
    /// </summary>
    public record class TraktSyncRatingsPostMovie
    {
        /// <summary>Gets or sets the optional title of the Trakt movie.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktMovieIDs? IDs { get; set; }

        /// <summary>Gets or sets the rating for the movie.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was rated.</summary>
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
