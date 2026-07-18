namespace TraktNET
{
    /// <summary>Represents the cover image data to update for a user.</summary>
    public record class TraktUserCoverPost
    {
#if NET5_0 || NET6_0 || NET7_0
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public TraktUserCoverPost() => CoverType = default!;
#endif

        /// <summary>Gets or sets the cover image type.</summary>
        public required TraktCoverType CoverType { get; set; }

        /// <summary>Gets or sets the cover image ID.</summary>
        public required uint CoverId { get; set; }
    }
}
