namespace TraktNET
{
    /// <summary>A Trakt cast member.</summary>
    public record class TraktCastMember
    {
        /// <summary>The character of the cast member.</summary>
        public string? Character { get; set; }

        /// <summary>The characters collection of the cast member.</summary>
        public List<string>? Characters { get; set; }

        /// <summary>The number of appearances of the cast member.</summary>
        public uint? EpisodeCount { get; set; }

        /// <summary>The cast member. See also <seealso cref="TraktPerson" />.</summary>
        public TraktPerson? Person { get; set; }
    }
}
