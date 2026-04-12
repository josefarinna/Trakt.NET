namespace TraktNET
{
    /// <summary>
    /// An user hidden items post, containing all movies, shows, seasons and / or users,
    /// which should be added to an user's hidden items list.
    /// </summary>
    public record class TraktUserHiddenItemsPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktUserHiddenItemsPostMovie" />s.
        /// <para>Each <see cref="TraktUserHiddenItemsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserHiddenItemsPostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserHiddenItemsPostShow" />s.
        /// <para>Each <see cref="TraktUserHiddenItemsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktUserHiddenItemsPostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserHiddenItemsPostSeason" />s.
        /// <para>Each <see cref="TraktUserHiddenItemsPostSeason" /> must have at least a valid Trakt id and a name.</para>
        /// </summary>
        public List<TraktUserHiddenItemsPostSeason>? Seasons { get; set; }

        /// <summary>An optional list of <see cref="TraktUser" />s.</summary>
        public List<TraktUser>? Users { get; set; }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoPeople = Seasons == null || Seasons.Count == 0;
            bool bHasNoUsers = Users == null || Users.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoPeople && bHasNoUsers)
                throw new TraktPostValidationException("no hidden items set");
        }
    }
}
