namespace TraktNET
{
    /// <summary>
    /// Represents the response for a collection post. See also <see cref="TraktSyncCollectionPost" />.
    /// <para>Contains the number of added, updated and existing movies and episodes, as well as not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public record class TraktSyncCollectionPostResponse
    {
        /// <summary>A collection containing the number of added movies and episodes.</summary>
        public TraktSyncCollectionPostResponseGroup? Added { get; set; }

        /// <summary>A collection containing the number of updated movies and episodes.</summary>
        public TraktSyncCollectionPostResponseGroup? Updated { get; set; }

        /// <summary>A collection containing the number of existing movies and episodes.</summary>
        public TraktSyncCollectionPostResponseGroup? Existing { get; set; }

        /// <summary>A collection containing the movies, shows, seasons and episodes, which were not found.</summary>
        public TraktSyncCollectionPostResponseNotFoundGroup? NotFound { get; set; }
    }
}
