namespace TraktNET
{
    /// <summary>A Trakt show.</summary>
    public record class TraktShowMinimal
    {
        /// <summary>The show title.</summary>
        public string? Title { get; set; }

        /// <summary>The show release year (first episode of the first season).</summary>
        public uint? Year { get; set; }

        /// <summary>
        /// The collection of IDs for the show for various web services.
        /// See also <seealso cref="TraktShowIds" />.
        /// </summary>
        public TraktShowIds? Ids { get; set; }
    }
}
