namespace TraktNET
{
    /// <summary>Represents a most watched show in a review period.</summary>
    public record class TraktUserReviewMostWatchedShow
    {
        /// <summary>Gets or sets the number of plays.</summary>
        public uint? Plays { get; set; }

        /// <summary>Gets or sets the watched minutes.</summary>
        public uint? Minutes { get; set; }

        /// <summary>Gets or sets the show details. See also <seealso cref="TraktShow" />.</summary>
        public TraktShow? Show { get; set; }
    }
}
