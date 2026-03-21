namespace TraktNET
{
    /// <summary>A season comment post.</summary>
    public record class TraktSeasonCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt season for the season comment post.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        public TraktSeason? Season { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (Season == null)
                throw new TraktPostValidationException(nameof(Season), "season must not be null");

            if (Season.IDs == null)
                throw new TraktPostValidationException(nameof(Season.IDs), "season ids must not be null");

            if (!Season.IDs.HasAnyID)
                throw new TraktPostValidationException("season ids have no valid id", nameof(Season.IDs));
        }
    }
}
