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

        /// <summary>Gets a string representation of the movie.</summary>
        /// <returns>A string representation of the movie.</returns>
        public override string ToString()
        {
            string title = string.Empty;

            if (!string.IsNullOrWhiteSpace(Title))
            {
                title = Title!;
            }

            if (Year.HasValue)
            {
                title = $"{title} ({Year.Value})";
            }

            return title;
        }
    }
}
