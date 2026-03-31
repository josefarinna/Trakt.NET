namespace TraktNET
{
    /// <summary>
    /// Represents the response for a collection remove post. See also <see cref="TraktSyncCollectionPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public record class TraktSyncCollectionRemovePostResponse
    {
        /// <summary>A collection containing the number of deleted movies, shows, seasons and episodes.</summary>
        public TraktSyncPostResponseGroup? Deleted { get; set; }

        /// <summary>A collection containing the ids of movies, shows, seasons and episodes, which were not found.</summary>
        public TraktSyncPostResponseNotFoundGroup? NotFound { get; set; }
    }
}
