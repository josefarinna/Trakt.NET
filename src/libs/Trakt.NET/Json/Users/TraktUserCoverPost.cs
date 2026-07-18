namespace TraktNET
{
    /// <summary>Represents the cover image data to update for a user.</summary>
    public record class TraktUserCoverPost
    {
        /// <summary>Gets or sets the cover image type.</summary>
        public TraktCoverType CoverType { get; set; }

        /// <summary>Gets or sets the cover image ID.</summary>
        public uint CoverId { get; set; }

        public void Validate()
        {
            if (CoverType == TraktCoverType.Unspecified)
            {
                throw new ArgumentException("Cover type must be specified.", nameof(CoverType));
            }

            if (CoverId == 0)
            {
                throw new ArgumentException("Cover ID must be greater than 0.", nameof(CoverId));
            }
        }
    }
}
