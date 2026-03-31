namespace TraktNET
{
    /// <summary>
    /// Represents the response for a favorites remove post. See also <see cref="TraktSyncFavoritesRemovePostResponse" />.
    /// <para>Contains the number of deleted movies and shows and not found movies and shows.</para>
    /// </summary>
    public record class TraktSyncFavoritesRemovePostResponse
    {
        /// <summary>A collection containing the number of deleted movies and shows.</summary>
        public TraktSyncFavoritesPostResponseGroup? Deleted { get; set; }

        /// <summary>A collection containing the ids of movies and shows, which were not found.</summary>
        public TraktSyncFavoritesPostResponseNotFoundGroup? NotFound { get; set; }

        /// <summary>Information about the updated list.</summary>
        public TraktPostResponseListData? List { get; set; }
    }
}
