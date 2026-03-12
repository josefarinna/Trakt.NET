namespace TraktNET
{
    /// <summary>A checkin for a Trakt movie.</summary>
    public record class TraktMovieCheckin : TraktCheckin
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the checkin.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public required TraktMovie Movie { get; set; }
    }
}
