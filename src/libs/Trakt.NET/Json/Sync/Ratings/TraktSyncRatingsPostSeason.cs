using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post season, containing the required season ids,
    /// a rating and an optional datetime, when the season was rated.
    /// </summary>
    public record class TraktSyncRatingsPostSeason : TraktSyncRemovePostSeason
    {
        /// <summary>Gets or sets the rating for the season.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was rated.</summary>
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
