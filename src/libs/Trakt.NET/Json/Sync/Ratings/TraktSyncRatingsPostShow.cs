using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post show, containing the required show ids,
    /// a rating and an optional datetime, when the show was rated.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public record class TraktSyncRatingsPostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktShowIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }

        /// <summary>Gets or sets the rating for the show.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt show was rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the ratings.
        /// Otherwise, only the specified seasons and / or episodes will be added to the ratings.
        /// </para>
        /// </summary>
        public List<TraktSyncRatingsPostShowSeason>? Seasons { get; set; }

        public void Validate()
        {
            if (Rating == null || (Rating < 1 || Rating > 10))
            {
                throw new TraktPostValidationException(nameof(Rating), "Rating must be between 1 and 10.");
            }
        }
    }
}
