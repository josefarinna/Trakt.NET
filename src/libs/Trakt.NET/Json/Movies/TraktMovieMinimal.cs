namespace TraktNET
{
    /// <summary>A Trakt movie.</summary>
    public record class TraktMovieMinimal
    {
        /// <summary>The movie title.</summary>
        public string? Title { get; set; }

        /// <summary>The movie release year.</summary>
        public uint? Year { get; set; }

        /// <summary>
        /// The collection of IDs for the movie for various web services.
        /// See also <seealso cref="TraktMovieIds" />.
        /// </summary>
        public TraktMovieIds? Ids { get; set; }
    }
}
