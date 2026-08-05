namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>
        /// Refreshs a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.
        /// <para>Queues a movie for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="traktMovieIDOrSlug">The movie's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/refresh/refresh-movie-metadata">
        /// Trakt API Documentation: Movies: Refresh - Refresh movie metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> RefreshMovieAsync(string traktMovieIDOrSlug, CancellationToken cancellationToken = default)
            => RefreshMovieImplAsync(traktMovieIDOrSlug, cancellationToken);

        /// <summary>
        /// Refreshs a <see cref="TraktMovie" /> with the specified Trakt-ID.
        /// <para>Queues a movie for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="traktMovieID">The movie's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/refresh/refresh-movie-metadata">
        /// Trakt API Documentation: Movies: Refresh - Refresh movie metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieID"/> is 0.</exception>
        public Task<TraktResponse> RefreshMovieAsync(uint traktMovieID, CancellationToken cancellationToken = default)
        {
            if (traktMovieID == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieID));

            return RefreshMovieAsync(traktMovieID.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>
        /// Refreshs a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIDs" />.
        /// <para>Queues a movie for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="movieIDs">The movie's IDs. See also <seealso cref="TraktMovieIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/refresh/refresh-movie-metadata">
        /// Trakt API Documentation: Movies: Refresh - Refresh movie metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIDs" /> is null.</exception>
        public Task<TraktResponse> RefreshMovieAsync(TraktMovieIDs movieIDs, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIDs);

            if (!movieIDs.HasAnyID)
                throw new ArgumentException($"{nameof(movieIDs)} has not any IDs set", nameof(movieIDs));

            return RefreshMovieImplAsync(movieIDs.BestID, cancellationToken);
        }
    }
}
