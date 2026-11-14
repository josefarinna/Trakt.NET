namespace TraktNET
{
    /// <summary>An upcoming award ceremony.</summary>
    public record class TraktUpcomingCeremony : TraktAwardCeremony
    {
        /// <summary>Gets or sets the year of the ceremony.</summary>
        public uint? Year { get; set; }
    }
}
