namespace TraktNET
{
    /// <summary>A Trakt user note item containing the note including the media object to which the note is attached.</summary>
    public class TraktNoteItem
    {
        /// <summary>
        /// Gets or sets information to which this note item is attached.
        /// If it is attached to an history item, this property contains the history item id.
        /// See also <seealso cref="TraktNoteAttachedTo" />.
        /// </summary>
        public TraktNoteAttachedTo? AttachedTo { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this note item contains.
        /// See also <seealso cref="TraktListItemType" />.
        /// </summary>
        public TraktListItemType? Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktListItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktListItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" /> or
        /// <see cref="TraktListItemType.Season" />.
        /// <para>See also <seealso cref="TraktShow" />.</para>
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktListItemType.Season" />.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        public TraktSeason? Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets the person, if <see cref="Type" /> is <see cref="TraktListItemType.Person" />.
        /// See also <seealso cref="TraktPerson" />.
        /// </summary>
        public TraktPerson? Person { get; set; }

        /// <summary>
        /// Gets or sets the note content of this item.
        /// See also <seealso cref="TraktNote" />.
        /// </summary>
        public TraktNote? Note { get; set; }
    }
}
