namespace TraktNET
{
    /// <summary>An alias for a Trakt movie.</summary>
    public record class TraktMovieAlias
    {
        /// <summary>The title of the movie alias.</summary>
        public string? Title { get; set; }

        /// <summary>The two letter country code for the movie alias.</summary>
        public string? Country { get; set; }
    }
}
