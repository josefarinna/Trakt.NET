namespace TraktNET
{
    /// <summary>
    /// Represents the response for a watchlist post. See also <see cref="TraktSyncWatchlistPost" />.
    /// <para>Contains the number of added, existing and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public record class TraktSyncWatchlistPostResponse
    {
        /// <summary>A collection containing the number of added movies, shows, seasons and episodes.</summary>
        public TraktSyncPostResponseGroup? Added { get; set; }

        /// <summary>A collection containing the number of existing movies, shows, seasons and episodes.</summary>
        public TraktSyncPostResponseGroup? Existing { get; set; }

        /// <summary>A collection containing the ids of movies, shows, seasons and episodes, which were not found.</summary>
        public TraktSyncPostResponseNotFoundGroup? NotFound { get; set; }

        /// <summary>Information about the updated list.</summary>
        public TraktPostResponseListData? List { get; set; }
    }
}
