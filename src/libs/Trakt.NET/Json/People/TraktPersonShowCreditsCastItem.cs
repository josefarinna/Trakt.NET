namespace TraktNET
{
    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public record class TraktPersonShowCreditsCastItem
    {
        /// <summary>Gets or sets the character of the cast position.</summary>
        public string? Character { get; set; }

        /// <summary>Gets or sets the characters collection of the cast position.</summary>
        public List<string>? Characters { get; set; }

        /// <summary>Gets or sets the episode count of the cast position.</summary>
        public uint? EpisodeCount { get; set; }

        /// <summary>Gets or sets the series regular value of the cast position.</summary>
        public bool? SeriesRegular { get; set; }

        /// <summary>
        /// Gets or sets the show of the cast position. See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }
    }
}
