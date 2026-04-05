namespace TraktNET
{
    /// <summary>Represents a movie scrobble response.</summary>
    public record class TraktMovieScrobblePostResponse : TraktScrobblePostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt movie, which was scrobbled.
        /// See also <seealso cref="TraktMovie" />.
        public TraktMovie? Movie { get; set; }
    }
}
