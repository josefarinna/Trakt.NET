namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to countries.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/countries">"Trakt API Documentation - Countries"</a> section.
    /// </summary>
    public sealed partial class TraktCountriesModule
    {
        /// <summary>Gets a list of all movie countries.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried countries.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCountry" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcountrieslist">
        /// Trakt API Documentation: Countries: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktCountry>> GetMovieCountriesAsync(CancellationToken cancellationToken = default)
            => GetMovieCountriesImplAsync(cancellationToken);

        /// <summary>Gets a list of all show countries.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried countries.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCountry" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcountrieslist">
        /// Trakt API Documentation: Countries: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktCountry>> GetShowCountriesAsync(CancellationToken cancellationToken = default)
            => GetShowCountriesImplAsync(cancellationToken);
    }
}
