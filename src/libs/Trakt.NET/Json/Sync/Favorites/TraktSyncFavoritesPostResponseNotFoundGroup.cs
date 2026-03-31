namespace TraktNET
{
    /// <summary>A collection containing the ids of favorited movies and shows, which were not found.</summary>
    public record class TraktSyncFavoritesPostResponseNotFoundGroup
    {
        /// <summary>A list of <see cref="TraktSyncFavoritesPostMovie" />, containing the ids of favorited movies, which were not found.</summary>
        public List<TraktSyncFavoritesPostMovie>? Movies { get; set; }

        /// <summary>A list of <see cref="TraktSyncFavoritesPostShow" />, containing the ids of favorited shows, which were not found.</summary>
        public List<TraktSyncFavoritesPostShow>? Shows { get; set; }
    }
}
