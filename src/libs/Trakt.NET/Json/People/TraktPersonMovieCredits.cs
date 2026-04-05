namespace TraktNET
{
    /// <summary>Contains all Trakt movies where a Trakt person is in the cast or crew.</summary>
    public record class TraktPersonMovieCredits
    {
        /// <summary>
        /// Gets or sets a list of cast positions, in which a person is.
        /// See also <seealso cref="TraktPersonMovieCreditsCastItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCastItem>? Cast { get; set; }

        /// <summary>
        /// Gets or sets a collection of crew positions, which a person has.
        /// See also <seealso cref="TraktPersonMovieCreditsCrew" />.
        /// </summary>
        public TraktPersonMovieCreditsCrew? Crew { get; set; }
    }
}
