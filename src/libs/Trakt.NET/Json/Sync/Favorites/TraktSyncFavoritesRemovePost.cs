namespace TraktNET
{
    /// <summary>A Trakt favorites remove post, containing movie and show favorites, which should be removed.</summary>
    public record class TraktSyncFavoritesRemovePost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncRemovePostMovie" />s.
        /// <para>Each <see cref="TraktSyncRemovePostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRemovePostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRemovePostShow" />s.
        /// <para>Each <see cref="TraktSyncRemovePostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRemovePostShow>? Shows { get; set; }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;

            if (bHasNoMovies && bHasNoShows)
                throw new TraktPostValidationException("no favorite items set");
        }
    }
}
