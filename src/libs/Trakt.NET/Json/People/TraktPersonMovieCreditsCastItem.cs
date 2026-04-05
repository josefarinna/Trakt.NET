namespace TraktNET
{
    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public record class TraktPersonMovieCreditsCastItem
    {
        /// <summary>Gets or sets the character of the cast position.</summary>
        public string? Character { get; set; }

        /// <summary>Gets or sets the characters collection of the cast position.</summary>
        public List<string>? Characters { get; set; }

        /// <summary>
        /// Gets or sets the movie of the cast position. See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }
    }
}
