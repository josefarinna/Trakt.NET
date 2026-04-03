namespace TraktNET
{
    /// <summary>A Trakt favorites post, containing all movies and shows, which should be favorited by an user.</summary>
    public record class TraktSyncFavoritesPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncFavoritesPostMovie" />s.
        /// <para>Each <see cref="TraktSyncFavoritesPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncFavoritesPostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncFavoritesPostShow" />s.
        /// <para>Each <see cref="TraktSyncFavoritesPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncFavoritesPostShow>? Shows { get; set; }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;

            if (bHasNoMovies && bHasNoShows)
                throw new TraktPostValidationException("no favorite items set");

            if (Movies != null && Movies.Count > 0)
            {
                foreach (TraktSyncFavoritesPostMovie postMovie in Movies)
                {
                    if (postMovie.Notes?.Length > 255)
                        throw new TraktPostValidationException($"Movies[{Movies.IndexOf(postMovie)}].Notes", "notes cannot be longer than 255 characters");
                }
            }

            if (Shows != null && Shows.Count > 0)
            {
                foreach (TraktSyncFavoritesPostShow postShow in Shows)
                {
                    if (postShow.Notes?.Length > 255)
                        throw new TraktPostValidationException($"Shows[{Shows.IndexOf(postShow)}].Notes", "notes cannot be longer than 255 characters");
                }
            }
        }
    }
}
