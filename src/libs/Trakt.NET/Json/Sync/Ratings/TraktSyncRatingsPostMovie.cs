using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post movie, containing the required movie ids,
    /// a rating and an optional datetime, when the movie was rated.
    /// </summary>
    public record class TraktSyncRatingsPostMovie : TraktSyncRemovePostMovie
    {
        /// <summary>Gets or sets the rating for the movie.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was rated.</summary>
        public DateTime? RatedAt { get; set; }

        public void Validate()
        {
            if (Rating == null || (Rating < 1 || Rating > 10))
            {
                throw new TraktPostValidationException(nameof(Rating), "Rating must be between 1 and 10.");
            }
        }
    }
}
