namespace TraktNET
{
    /// <summary>
    /// Represents the response for a history remove post. See also <see cref="TraktSyncHistoryRemovePost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons, episodes and history item ids.</para>
    /// </summary>
    public record class TraktSyncHistoryRemovePostResponse
    {
        /// <summary>A collection containing the number of deleted movies, shows, seasons, episodes and history item ids.</summary>
        public TraktSyncHistoryRemovePostResponseGroup? Deleted { get; set; }

        /// <summary>A collection containing the ids of movies, shows, seasons, episodes and history item ids, which were not found.</summary>
        public TraktSyncHistoryRemovePostResponseNotFoundGroup? NotFound { get; set; }
    }
}
