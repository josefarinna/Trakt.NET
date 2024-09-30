namespace TraktNET
{
    /// <summary>A Trakt crew member.</summary>
    public record class TraktCrewMember
    {
        /// <summary>The jobs collection of the crew member.</summary>
        public List<string>? Jobs { get; set; }

        /// <summary>The crew member. See also <seealso cref="TraktPerson" />.</summary>
        public TraktPerson? Person { get; set; }
    }
}
