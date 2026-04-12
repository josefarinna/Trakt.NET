namespace TraktNET
{
    /// <summary>
    /// An user hidden items post, containing all movies, shows, seasons and / or users,
    /// which should be remove from an user's hidden items list.
    /// </summary>
    public record class TraktUserHiddenItemsRemovePost
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
        /// <para>Each <see cref="TraktUserRemovePostSeason" /> must have at least a valid Trakt id and a name.</para>
        /// </summary>
        public List<TraktUserRemovePostSeason>? Seasons { get; set; }

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
