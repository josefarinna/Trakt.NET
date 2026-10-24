namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post season, containing the required season number and optional episodes,
    /// an optional rating and an optional datetime, when the season was rated.
    /// </summary>
    public record class TraktSyncRatingsPostShowSeason : TraktSyncRemovePostShowSeason
    {
        /// <summary>Gets or sets the optional rating for the season.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the ratings.
        /// Otherwise, only the specified episodes will be added to the ratings.
        /// </para>
        /// </summary>
        public new List<TraktSyncRatingsPostShowEpisode>? Episodes { get; set; }

        public void Validate()
        {
            if (Rating != null && (Rating < 1 || Rating > 10))
            {
                throw new TraktPostValidationException(nameof(Rating), "Rating must be between 1 and 10.");
            }

            if (Episodes != null && Episodes.Count > 0)
            {
                foreach (TraktSyncRatingsPostShowEpisode episode in Episodes)
                {
                    episode.Validate();
                }
            }
        }
    }
}
