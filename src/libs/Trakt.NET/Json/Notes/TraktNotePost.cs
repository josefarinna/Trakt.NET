namespace TraktNET
{
    /// <summary>A note post.</summary>
    public class TraktNotePost
    {
        /// <summary>
        /// Gets or sets the info to which collection, history item or rating this note is attached.
        /// See also <seealso cref="TraktNoteAttachedTo" />.
        /// </summary>
        public TraktNoteAttachedTo? AttachedTo { get; set; }

        /// <summary>Gets or sets whether the note contains any spoilers.</summary>
        public bool? Spoiler { get; set; }

        /// <summary>Gets or sets the privacy setting for the note.</summary>
        public TraktListPrivacy? Privacy { get; set; }

        /// <summary>Gets or sets the note's content.</summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the Trakt movie.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the Trakt season.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        public TraktSeason? Season { get; set; }

        /// <summary>
        /// Gets or sets the Trakt episode.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt person.
        /// See also <seealso cref="TraktPerson" />.
        /// </summary>
        public TraktPerson? Person { get; set; }

        /// <summary>
        /// Gets or sets the Trakt list.
        /// See also <seealso cref="TraktList" />.
        /// </summary>
        public TraktList? List { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Notes))
            {
                throw new TraktPostValidationException(nameof(Notes), "notes must not be null or empty");
            }

            if (IgnoreCompleteValidation)
            {
                return;
            }

            if (AttachedTo == null && Movie == null && Show == null && Season == null && Episode == null && Person == null && List == null)
            {
                throw new TraktPostValidationException("note post must contain a media object");
            }
        }

        internal bool IgnoreCompleteValidation { get; set; }
    }
}
