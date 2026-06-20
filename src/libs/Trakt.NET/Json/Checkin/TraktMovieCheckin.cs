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

        public override void Validate()
        {
            ArgumentValidator.ThrowIfNull(Movie);
            ArgumentValidator.ThrowIfNull(Movie.IDs);
            if (!Movie.IDs!.HasAnyID)
            {
                throw new ArgumentException($"{nameof(Movie)} has not any IDs set", nameof(Movie));
            }
        }
    }
}
