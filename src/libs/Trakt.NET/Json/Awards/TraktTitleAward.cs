namespace TraktNET
{
    /// <summary>An award for a movie or show.</summary>
    public record class TraktTitleAward
    {
        /// <summary>Gets or sets the award. See also <seealso cref="TraktAward" />.</summary>
        public TraktAward? Award { get; set; }

        /// <summary>Gets or sets the ceremony. See also <seealso cref="TraktAwardCeremony" />.</summary>
        public TraktAwardCeremony? Ceremony { get; set; }

        /// <summary>Gets or sets the year of the award.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets whether the title won the award.</summary>
        public bool? Won { get; set; }

        /// <summary>Gets or sets the person associated with the award, if any. See also <seealso cref="TraktPerson" />.</summary>
        public TraktPerson? Person { get; set; }
    }
}
