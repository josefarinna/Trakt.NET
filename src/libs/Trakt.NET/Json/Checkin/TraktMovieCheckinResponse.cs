namespace TraktNET
{
    /// <summary>Represents a movie checkin response.</summary>
    public record class TraktMovieCheckinResponse : TraktCheckinResponse
    {
        /// <summary>
        /// Gets or sets the Trakt movie, which was checked in.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }
    }
}
