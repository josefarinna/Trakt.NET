namespace TraktNET
{
    /// <summary>
    /// An user personal list items post, containing all movies, shows, seasons, episodes and / or people,
    /// which should be removed from an user's personal list.
    /// </summary>
    public record class TraktUserPersonalListItemsRemovePost
    {
        /// <summary>
        /// An optional list of <see cref="TraktUserRemovePostMovie" />s.
        /// <para>Each <see cref="TraktUserRemovePostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserRemovePostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserRemovePostShow" />s.
        /// <para>Each <see cref="TraktUserRemovePostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserRemovePostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserRemovePostSeason" />s.
        /// <para>Each <see cref="TraktUserRemovePostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserRemovePostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserRemovePostEpisode" />s.
        /// <para>Each <see cref="TraktUserRemovePostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserRemovePostEpisode>? Episodes { get; set; }

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
