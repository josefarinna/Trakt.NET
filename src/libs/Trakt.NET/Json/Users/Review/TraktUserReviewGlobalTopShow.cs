namespace TraktNET
{
    /// <summary>Represents a globally most played show on Trakt in an all-time review.</summary>
    public record class TraktUserReviewGlobalTopShow
    {
        /// <summary>Gets or sets the global watchers count.</summary>
        public uint? Watchers { get; set; }

        /// <summary>Gets or sets whether this user watched the show.</summary>
        public bool? Watched { get; set; }

        /// <summary>Gets or sets the show details. See also <seealso cref="TraktShow" />.</summary>
        public TraktShow? Show { get; set; }
    }
}
