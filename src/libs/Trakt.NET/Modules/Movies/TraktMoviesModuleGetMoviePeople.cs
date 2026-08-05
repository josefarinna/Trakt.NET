namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>Gets all people for a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktMovieIDOrSlug">The movie's Trakt-ID or -Slug.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the people.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie people.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCastAndCrew" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getmoviespeople">
        /// Trakt API Documentation: Movies: People - Get all people for a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktCastAndCrew>> GetMoviePeopleAsync(string traktMovieIDOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMoviePeopleImplAsync(traktMovieIDOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets all people for a <see cref="TraktMovie" /> with the specified Trakt-ID.</summary>
        /// <param name="traktMovieID">The movie's Trakt-ID.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the people.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie people.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCastAndCrew" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getmoviespeople">
        /// Trakt API Documentation: Movies: People - Get all people for a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktCastAndCrew>> GetMoviePeopleAsync(uint traktMovieID, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMoviePeopleImplAsync(traktMovieID.ToInvariantCultureString(), extendedInfo, cancellationToken);

        /// <summary>Gets all people for a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIDs" />.</summary>
        /// <param name="movieIDs">The movie's IDs. See also <seealso cref="TraktMovieIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the people.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie people.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCastAndCrew" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getmoviespeople">
        /// Trakt API Documentation: Movies: People - Get all people for a movie
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIDs" /> is null.</exception>
        public Task<TraktResponse<TraktCastAndCrew>> GetMoviePeopleAsync(TraktMovieIDs movieIDs, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIDs);

            if (!movieIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIDs)} has not any IDs set", nameof(movieIDs));
            }

            return GetMoviePeopleImplAsync(movieIDs.BestID, extendedInfo, cancellationToken);
        }
    }
}
