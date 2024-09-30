namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>Gets all users watching a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktMovieIdOrSlug">The movie's Trakt-ID or -Slug.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried users.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/watching/get-users-watching-right-now">
        /// Trakt API Documentation: Movies: Watching - Get users watching right now
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktUser>> GetMovieWatchingUsersAsync(string traktMovieIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieWatchingUsersImplAsync(traktMovieIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets all users watching a <see cref="TraktMovie" /> with the specified Trakt-ID.</summary>
        /// <param name="traktMovieId">The movie's Trakt-ID.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried users.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/watching/get-users-watching-right-now">
        /// Trakt API Documentation: Movies: Watching - Get users watching right now
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktUser>> GetMovieWatchingUsersAsync(uint traktMovieId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieWatchingUsersImplAsync(traktMovieId.ToInvariantCultureString(), extendedInfo, cancellationToken);

        /// <summary>Gets all users watching a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIds" />.</summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried users.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/watching/get-users-watching-right-now">
        /// Trakt API Documentation: Movies: Watching - Get users watching right now
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIds" /> has not set any ids.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIds" /> is null.</exception>
        public Task<TraktListResponse<TraktUser>> GetMovieWatchingUsersAsync(TraktMovieIds movieIds, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIds);

            if (!movieIds.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));
            }

            return GetMovieWatchingUsersImplAsync(movieIds.BestID, extendedInfo, cancellationToken);
        }
    }
}
