namespace TraktNET
{
    /// <summary>A checkin for a Trakt movie.</summary>
    public record class TraktMovieCheckin : TraktCheckin
    {
#if NET5_0 || NET6_0 || NET7_0
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public TraktMovieCheckin() => Movie = default!;
#endif

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
                throw new TraktPostValidationException(nameof(Movie), $"{nameof(Movie)} has not any IDs set");
            }
        }
    }
}
