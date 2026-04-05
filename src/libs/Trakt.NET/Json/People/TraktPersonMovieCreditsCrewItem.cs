namespace TraktNET
{
    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public record class TraktPersonMovieCreditsCrewItem
    {
        /// <summary>Gets or sets the job of the crew position.</summary>
        public string? Job { get; set; }

        /// <summary>Gets or sets the jobs collection of the crew position.</summary>
        public List<string>? Jobs { get; set; }

        /// <summary>
        /// Gets or sets the movie of the crew position. See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }
    }
}
