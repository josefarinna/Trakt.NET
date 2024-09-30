namespace TraktNET
{
    /// <summary>A Trakt cast member.</summary>
    public record class TraktCastMember
    {
        /// <summary>The characters collection of the cast member.</summary>
        public List<string>? Characters { get; set; }

        /// <summary>The cast member. See also <seealso cref="TraktPerson" />.</summary>
        public TraktPerson? Person { get; set; }
    }
}
