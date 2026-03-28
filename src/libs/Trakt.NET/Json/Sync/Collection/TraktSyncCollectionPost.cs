namespace TraktNET
{
    /// <summary>
    /// A Trakt collection post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's collection.
    /// </summary>
    public record class TraktSyncCollectionPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostMovie" />s.
        /// <para>Each <see cref="TraktSyncCollectionPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncCollectionPostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostShow" />s.
        /// <para>Each <see cref="TraktSyncCollectionPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncCollectionPostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostSeason" />s.
        /// <para>Each <see cref="TraktSyncCollectionPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncCollectionPostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncCollectionPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncCollectionPostEpisode>? Episodes { get; set; }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoSeasons = Seasons == null || Seasons.Count == 0;
            bool bHasNoEpisodes = Episodes == null || Episodes.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes)
                throw new TraktPostValidationException("no collection items set");
        }
    }
}
