namespace TraktNET
{
    /// <summary>
    /// Represents the response for a collection remove post. See also <see cref="TraktSyncCollectionRemovePost" />.
    /// <para>Contains the number of deleted movies and episodes, as well as not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public record class TraktSyncCollectionRemovePostResponse
    {
        /// <summary>A collection containing the number of deleted movies and episodes.</summary>
        public TraktSyncCollectionPostResponseGroup? Deleted { get; set; }

        /// <summary>A collection containing the movies, shows, seasons and episodes, which were not found.</summary>
        public TraktSyncCollectionRemovePostResponseNotFoundGroup? NotFound { get; set; }
    }
}
