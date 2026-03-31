namespace TraktNET
{
    /// <summary>
    /// Represents the response for a watchlist remove post. See also <see cref="TraktSyncWatchlistPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public record class TraktSyncWatchlistRemovePostResponse
    {
        /// <summary>A collection containing the number of deleted movies, shows, seasons and episodes.</summary>
        public TraktSyncPostResponseGroup? Deleted { get; set; }

        /// <summary>A collection containing the ids of movies, shows, seasons and episodes, which were not found.</summary>
        public TraktSyncPostResponseNotFoundGroup? NotFound { get; set; }

        /// <summary>Information about the updated list.</summary>
        public TraktPostResponseListData? List { get; set; }
    }
}
