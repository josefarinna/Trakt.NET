namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>
        /// Reports a <see cref="TraktMovie" /> for moderator review with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktMovieIDOrSlug">The movie's Trakt-ID or -Slug.</param>
        /// <param name="reason">The reason for reporting the movie. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postmoviesreport">
        /// Trakt API Documentation: Movies: Report a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> ReportMovieAsync(string traktMovieIDOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportMovieImplAsync(traktMovieIDOrSlug, reason, message, cancellationToken);

        /// <summary>
        /// Reports a <see cref="TraktMovie" /> for moderator review with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktMovieId">The movie's Trakt-ID.</param>
        /// <param name="reason">The reason for reporting the movie. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postmoviesreport">
        /// Trakt API Documentation: Movies: Report a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktResponse> ReportMovieAsync(uint traktMovieId, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return ReportMovieAsync(traktMovieId.ToInvariantCultureString(), reason, message, cancellationToken);
        }

        /// <summary>
        /// Reports a <see cref="TraktMovie" /> for moderator review with the specified <see cref="TraktMovieIDs" />.
        /// </summary>
        /// <param name="movieIds">The movie's IDs. See also <seealso cref="TraktMovieIDs" />.</param>
        /// <param name="reason">The reason for reporting the movie. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postmoviesreport">
        /// Trakt API Documentation: Movies: Report a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIds" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIds" /> is null.</exception>
        public Task<TraktResponse> ReportMovieAsync(TraktMovieIDs movieIds, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIds);

            if (!movieIds.HasAnyID)
                throw new ArgumentException($"{nameof(movieIds)} has not any IDs set", nameof(movieIds));

            return ReportMovieAsync(movieIds.BestID, reason, message, cancellationToken);
        }
    }
}
