using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt history remove post, containing all movies, shows, seasons, episodes and / or history ids,
    /// which should be removed from the user's history.
    /// </summary>
    public record class TraktSyncHistoryRemovePost
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

        /// <summary>
        /// An optional list of <see cref="TraktSyncRemovePostSeason" />s.
        /// <para>Each <see cref="TraktSyncRemovePostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRemovePostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRemovePostEpisode" />s.
        /// <para>Each <see cref="TraktSyncRemovePostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRemovePostEpisode>? Episodes { get; set; }

        /// <summary>An optional list of history ids, which should be removed.</summary>
        [JsonPropertyName("history_ids")]
        public List<ulong>? HistoryIDs { get; set; }

        public virtual void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoSeasons = Seasons == null || Seasons.Count == 0;
            bool bHasNoEpisodes = Episodes == null || Episodes.Count == 0;
            bool bHasNoHistoryIds = HistoryIDs == null || HistoryIDs.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes && bHasNoHistoryIds)
                throw new TraktPostValidationException("no history items set");
        }
    }
}
