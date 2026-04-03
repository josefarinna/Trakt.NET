using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings remove post, containing all movies, shows, seasons and / or episodes,
    /// which should be removed from the user's ratings.
    /// </summary>
    public record class TraktSyncRatingsRemovePost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsRemovePostMovie" />s.
        /// <para>Each <see cref="TraktSyncRatingsRemovePostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsRemovePostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsRemovePostShow" />s.
        /// <para>Each <see cref="TraktSyncRatingsRemovePostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsRemovePostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsRemovePostSeason" />s.
        /// <para>Each <see cref="TraktSyncRatingsRemovePostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsRemovePostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsRemovePostEpisode" />s.
        /// <para>Each <see cref="TraktSyncRatingsRemovePostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsRemovePostEpisode>? Episodes { get; set; }

        public virtual void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoSeasons = Seasons == null || Seasons.Count == 0;
            bool bHasNoEpisodes = Episodes == null || Episodes.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes)
                throw new TraktPostValidationException("no ratings items set");
        }
    }
}
