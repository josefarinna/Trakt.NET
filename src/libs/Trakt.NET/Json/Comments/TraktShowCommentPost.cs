namespace TraktNET
{
    /// <summary>A show comment post.</summary>
    public record class TraktShowCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt show for the show comment post.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (Show == null)
                throw new TraktPostValidationException(nameof(Show), "show must not be null");

            if (Show.IDs == null)
                throw new TraktPostValidationException(nameof(Show.IDs), "show ids must not be null");

            if (!Show.IDs.HasAnyID)
                throw new TraktPostValidationException("show ids have no valid id", nameof(Show.IDs));
        }
    }
}
