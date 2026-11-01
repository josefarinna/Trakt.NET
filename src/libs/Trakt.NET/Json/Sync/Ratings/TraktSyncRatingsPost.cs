namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's ratings.
    /// </summary>
    public record class TraktSyncRatingsPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostMovie" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsPostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostShow" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsPostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostSeason" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsPostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsPostEpisode>? Episodes { get; set; }

        public void Validate()
        {
            bool anyItemPresent = ValidateItems(Movies, movie => movie.Validate());
            anyItemPresent |= ValidateItems(Shows, show => show.Validate());
            anyItemPresent |= ValidateItems(Seasons, season => season.Validate());
            anyItemPresent |= ValidateItems(Episodes, episode => episode.Validate());

            if (!anyItemPresent)
                throw new TraktPostValidationException("no ratings items set");
        }

        private static bool ValidateItems<T>(List<T>? items, Action<T> validate)
        {
            if (items == null || items.Count == 0)
                return false;

            foreach (T item in items)
                validate(item);

            return true;
        }
    }
}
