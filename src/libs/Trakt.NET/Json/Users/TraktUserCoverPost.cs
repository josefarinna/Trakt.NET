namespace TraktNET
{
    /// <summary>Represents the cover image data to update for a user.</summary>
    public record class TraktUserCoverPost
    {
        /// <summary>Gets or sets the cover image type.</summary>
        public TraktCoverType CoverType { get; set; }

        /// <summary>Gets or sets the cover image ID.</summary>
        public uint CoverID { get; set; }

        public void Validate()
        {
            if (CoverType == TraktCoverType.Unspecified)
            {
                throw new TraktPostValidationException(nameof(CoverType), "Cover type must be specified.");
            }

            if (CoverID == 0)
            {
                throw new TraktPostValidationException(nameof(CoverID), "Cover ID must be greater than 0.");
            }
        }
    }
}
