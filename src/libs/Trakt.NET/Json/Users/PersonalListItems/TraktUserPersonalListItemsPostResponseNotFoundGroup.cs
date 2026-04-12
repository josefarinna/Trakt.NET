namespace TraktNET
{
    /// <summary>A collection containing the ids of movies, shows, seasons, episodes and people, which were not found.</summary>
    public record class TraktUserPersonalListItemsPostResponseNotFoundGroup
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

        /// <summary>
        /// A list of <see cref="TraktPostResponseNotFoundPerson" />, containing the ids of people, which were not found.
        /// </summary>
        public List<TraktPostResponseNotFoundPerson>? People { get; set; }
    }
}
