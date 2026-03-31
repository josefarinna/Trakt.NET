namespace TraktNET
{
    /// <summary>
    /// Represents the response for a favorites post. See also <see cref="TraktSyncFavoritesPost" />.
    /// <para>Contains the number of added, existing and not found movies and shows.</para>
    /// </summary>
    public record class TraktSyncFavoritesPostResponse
    {
        /// <summary>A collection containing the number of added movies and shows.</summary>
        public TraktSyncFavoritesPostResponseGroup? Added { get; set; }

        /// <summary>A collection containing the number of existing movies and shows.</summary>
        public TraktSyncFavoritesPostResponseGroup? Existing { get; set; }

        /// <summary>A collection containing the ids of movies and shows, which were not found.</summary>
        public TraktSyncFavoritesPostResponseNotFoundGroup? NotFound { get; set; }

        /// <summary>Information about the updated list.</summary>
        public TraktPostResponseListData? List { get; set; }
    }
}
