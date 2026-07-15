namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>
        /// Refreshs the JustWatch links of a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktMovieIDOrSlug">The movie's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postmoviesjustwatchrefresh">
        /// Trakt API Documentation: Movies: Refresh - Refresh movie JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> RefreshMovieJustWatchLinksAsync(string traktMovieIDOrSlug, CancellationToken cancellationToken = default)
            => RefreshMovieJustWatchLinksImplAsync(traktMovieIDOrSlug, cancellationToken);

        /// <summary>
        /// Refreshs the JustWatch links of a <see cref="TraktMovie" /> with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktMovieID">The movie's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postmoviesjustwatchrefresh">
        /// Trakt API Documentation: Movies: Refresh - Refresh movie JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieID"/> is 0.</exception>
        public Task<TraktResponse> RefreshMovieJustWatchLinksAsync(uint traktMovieID, CancellationToken cancellationToken = default)
        {
            if (traktMovieID == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieID));

            return RefreshMovieJustWatchLinksAsync(traktMovieID.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>
        /// Refreshs the JustWatch links of a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIDs" />.
        /// </summary>
        /// <param name="movieIDs">The movie's IDs. See also <seealso cref="TraktMovieIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postmoviesjustwatchrefresh">
        /// Trakt API Documentation: Movies: Refresh - Refresh movie JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIDs" /> is null.</exception>
        public Task<TraktResponse> RefreshMovieJustWatchLinksAsync(TraktMovieIDs movieIDs, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIDs);

            if (!movieIDs.HasAnyID)
                throw new ArgumentException($"{nameof(movieIDs)} has not any IDs set", nameof(movieIDs));

            return RefreshMovieJustWatchLinksAsync(movieIDs.BestID, cancellationToken);
        }
    }
}
