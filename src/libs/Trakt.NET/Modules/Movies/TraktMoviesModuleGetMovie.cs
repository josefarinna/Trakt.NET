namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>Gets a <see cref="TraktMovie" /> with the specified Trakt-Id or -Slug.</summary>
        /// <param name="traktMovieIdOrSlug">The movie's Trakt-Id or -Slug.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movie.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie.
        /// <para />
        /// See also <seealso cref="TraktMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/summary/get-a-movie">
        /// Trakt API Documentation: Movies: Summary - Get a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktMovie>> GetMovieAsync(string traktMovieIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieImplAsync(traktMovieIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets a <see cref="TraktMovie" /> with the specified Trakt-Id or -Slug.</summary>
        /// <param name="traktMovieId">The movie's Trakt-Id.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movie.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie.
        /// <para />
        /// See also <seealso cref="TraktMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/summary/get-a-movie">
        /// Trakt API Documentation: Movies: Summary - Get a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktMovie>> GetMovieAsync(uint traktMovieId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieImplAsync(traktMovieId.ToInvariantCultureString(), extendedInfo, cancellationToken);

        /// <summary>Gets a <see cref="TraktMovie" /> with the specified Trakt-Id or -Slug.</summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movie.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie.
        /// <para />
        /// See also <seealso cref="TraktMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/summary/get-a-movie">
        /// Trakt API Documentation: Movies: Summary - Get a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIds" /> has not set any ids.</exception>
        public Task<TraktResponse<TraktMovie>> GetMovieAsync(TraktMovieIds movieIds, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            if (!movieIds.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));
            }

            return GetMovieImplAsync(movieIds.BestID, extendedInfo, cancellationToken);
        }
    }
}
