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

            if (Movies != null)
                ValidateNotes(Movies.ConvertAll(movie => movie.Notes), nameof(Movies));

            if (Shows != null)
                ValidateNotes(Shows.ConvertAll(show => show.Notes), nameof(Shows));
        }

        private static void ValidateNotes(List<string?> notes, string collectionName)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i]?.Length > 255)
                    throw new TraktPostValidationException($"{collectionName}[{i}].Notes", "notes cannot be longer than 255 characters");
            }
        }
    }
}
