namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to genres.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/genres">"Trakt API Documentation - Genres"</a> section.
    /// </summary>
    public sealed partial class TraktGenresModule
    {
        /// <summary>Gets a list of all movie genres.</summary>
        /// <param name="extendedInfo">
        /// Specifies if you want to get the subgenre.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried genres.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktGenre" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getgenreslist">
        /// Trakt API Documentation: Genres: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktGenre>> GetMovieGenresAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieGenresImplAsync(extendedInfo, cancellationToken);

        /// <summary>Gets a list of all show genres.</summary>
        /// <param name="extendedInfo">
        /// Specifies if you want to get the subgenre.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried genres.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktGenre" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getgenreslist">
        /// Trakt API Documentation: Genres: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktGenre>> GetShowGenresAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetShowGenresImplAsync(extendedInfo, cancellationToken);
    }
}
