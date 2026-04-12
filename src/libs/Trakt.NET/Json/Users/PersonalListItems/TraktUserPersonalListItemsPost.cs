namespace TraktNET
{
    /// <summary>
    /// An user personal list items post, containing all movies, shows, seasons, episodes and / or people,
    /// which should be added to an user's personal list.
    /// </summary>
    public record class TraktUserPersonalListItemsPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktUserPersonalListItemsPostMovie" />s.
        /// <para>Each <see cref="TraktUserPersonalListItemsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserPersonalListItemsPostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserPersonalListItemsPostShow" />s.
        /// <para>Each <see cref="TraktUserPersonalListItemsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserPersonalListItemsPostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserPersonalListItemsPostSeason" />s.
        /// <para>Each <see cref="TraktUserPersonalListItemsPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserPersonalListItemsPostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserPersonalListItemsPostEpisode" />s.
        /// <para>Each <see cref="TraktUserPersonalListItemsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserPersonalListItemsPostEpisode>? Episodes { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserPersonalListItemsPostPerson" />s.
        /// <para>Each <see cref="TraktUserPersonalListItemsPostPerson" /> must have at least a valid Trakt id and a name.</para>
        /// </summary>
        public List<TraktUserPersonalListItemsPostPerson>? People { get; set; }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoSeasons = Seasons == null || Seasons.Count == 0;
            bool bHasNoEpisodes = Episodes == null || Episodes.Count == 0;
            bool bHasNoPeople = People == null || People.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes && bHasNoPeople)
                throw new TraktPostValidationException("no personal list items set");
        }
    }
}
