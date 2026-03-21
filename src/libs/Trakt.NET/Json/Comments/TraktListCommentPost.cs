namespace TraktNET
{
    /// <summary>A list comment post.</summary>
    public record class TraktListCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt list for the list comment post.
        /// See also <seealso cref="TraktList" />.
        /// </summary>
        public TraktList? List { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (List == null)
                throw new TraktPostValidationException(nameof(List), "list must not be null");

            if (List.IDs == null)
                throw new TraktPostValidationException(nameof(List.IDs), "list ids must not be null");

            if (!List.IDs.HasAnyID)
                throw new TraktPostValidationException("list ids have no valid id", nameof(List.IDs));
        }
    }
}
