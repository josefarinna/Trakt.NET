namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>
        /// Refreshs a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.
        /// <para>Queues a movie for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="traktMovieIdOrSlug">The movie's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
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
        public Task<TraktResponse> RefreshMovieAsync(string traktMovieIdOrSlug, CancellationToken cancellationToken = default)
            => RefreshMovieImplAsync(traktMovieIdOrSlug, cancellationToken);

        /// <summary>
        /// Refreshs a <see cref="TraktMovie" /> with the specified Trakt-ID.
        /// <para>Queues a movie for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="traktMovieId">The movie's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
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
        public Task<TraktResponse> RefreshMovieAsync(uint traktMovieId, CancellationToken cancellationToken = default)
            => RefreshMovieImplAsync(traktMovieId.ToInvariantCultureString(), cancellationToken);

        /// <summary>
        /// Refreshs a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIds" />.
        /// <para>Queues a movie for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
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
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIds" /> has not set any ids.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIds" /> is null.</exception>
        public Task<TraktResponse> RefreshMovieAsync(TraktMovieIds movieIds, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIds);

            if (!movieIds.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));
            }

            return RefreshMovieImplAsync(movieIds.BestID, cancellationToken);
        }
    }
}
