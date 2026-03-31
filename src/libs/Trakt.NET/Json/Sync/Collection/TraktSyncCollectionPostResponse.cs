namespace TraktNET
{
    /// <summary>
    /// Represents the response for a collection post. See also <see cref="TraktSyncCollectionPost" />.
    /// <para>Contains the number of added, updated, existing and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public record class TraktSyncCollectionPostResponse
    {
        /// <summary>A collection containing the number of added movies, shows, seasons and episodes.</summary>
        public TraktSyncPostResponseGroup? Added { get; set; }

        /// <summary>A collection containing the number of updated movies, shows, seasons and episodes.</summary>
        public TraktSyncPostResponseGroup? Updated { get; set; }

        /// <summary>A collection containing the number of existing movies, shows, seasons and episodes.</summary>
        public TraktSyncPostResponseGroup? Existing { get; set; }

        /// <summary>A collection containing the ids of movies, shows, seasons and episodes, which were not found.</summary>
        public TraktSyncPostResponseNotFoundGroup? NotFound { get; set; }
    }
}
