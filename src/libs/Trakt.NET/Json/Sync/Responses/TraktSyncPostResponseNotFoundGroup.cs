namespace TraktNET
{
    /// <summary>A collection containing the ids of movies, shows, seasons and episodes, which were not found.</summary>
    public record class TraktSyncPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="TraktPostResponseNotFoundMovie" />, containing the ids of movies, which were not found.
        /// </summary>
        public List<TraktPostResponseNotFoundMovie>? Movies { get; set; }

        /// <summary>
        /// A list of <see cref="TraktPostResponseNotFoundShow" />, containing the ids of shows, which were not found.
        /// </summary>
        public List<TraktPostResponseNotFoundShow>? Shows { get; set; }

        /// <summary>
        /// A list of <see cref="TraktPostResponseNotFoundSeason" />, containing the ids of seasons, which were not found.
        /// </summary>
        public List<TraktPostResponseNotFoundSeason>? Seasons { get; set; }

        /// <summary>
        /// A list of <see cref="TraktPostResponseNotFoundEpisode" />, containing the ids of episodes, which were not found.
        /// </summary>
        public List<TraktPostResponseNotFoundEpisode>? Episodes { get; set; }
    }
}
