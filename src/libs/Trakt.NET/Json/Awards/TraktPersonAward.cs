namespace TraktNET
{
    /// <summary>An award for a person.</summary>
    public record class TraktPersonAward
    {
        /// <summary>Gets or sets the award. See also <seealso cref="TraktAward" />.</summary>
        public TraktAward? Award { get; set; }

        /// <summary>Gets or sets the ceremony. See also <seealso cref="TraktAwardCeremony" />.</summary>
        public TraktAwardCeremony? Ceremony { get; set; }

        /// <summary>Gets or sets the year of the award.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets whether the person won the award.</summary>
        public bool? Won { get; set; }

        /// <summary>Gets or sets the movie associated with the award, if any. See also <seealso cref="TraktMovie" />.</summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>Gets or sets the show associated with the award, if any. See also <seealso cref="TraktShow" />.</summary>
        public TraktShow? Show { get; set; }

        /// <summary>Gets or sets the award item type. See also <seealso cref="TraktListItemType" />.</summary>
        public TraktListItemType? Type { get; set; }
    }
}
