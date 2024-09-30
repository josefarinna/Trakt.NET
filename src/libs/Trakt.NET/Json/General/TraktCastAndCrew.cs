namespace TraktNET
{
    /// <summary>A collection of cast- and crew-members.</summary>
    public record class TraktCastAndCrew
    {
        /// <summary>A list of cast members. See also <seealso cref="TraktCastMember" />.</summary>
        public List<TraktCastMember>? Cast { get; set; }

        /// <summary>A collection of crew members. See also <seealso cref="TraktCrew" />.</summary>
        public TraktCrew? Crew { get; set; }
    }
}
