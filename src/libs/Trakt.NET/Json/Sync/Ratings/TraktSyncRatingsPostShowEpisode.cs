namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post episode, containing the required episode number,
    /// a rating and an optional datetime, when the episode was rated.
    /// </summary>
    public record class TraktSyncRatingsPostShowEpisode : TraktSyncRemovePostShowEpisode
    {
        /// <summary>Gets or sets the rating for the episode.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was rated.</summary>
        public DateTime? RatedAt { get; set; }
    }
}
