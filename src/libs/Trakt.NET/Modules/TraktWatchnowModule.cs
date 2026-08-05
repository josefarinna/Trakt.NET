namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to watch now sources.
    /// <para>This module contains all methods of the "Trakt API Documentation - Watch Now" section.</para>
    /// <para>Note: These methods are provided for API completeness and visibility; functionality or data availability may vary depending on Trakt.tv backend support and API access tier.</para>
    /// </summary>
    public sealed partial class TraktWatchnowModule
    {
        /// <summary>Gets all watch now sources supported by Trakt.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing all watch now sources.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktWatchnowSource" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para>Note: Provided for API visibility and completeness; availability depends on Trakt.tv API backend support.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getwatchnowsourcesall">
        /// Trakt API Documentation: Watch Now - Get watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>> GetWatchnowSourcesAsync(CancellationToken cancellationToken = default)
            => GetWatchnowSourcesImplAsync(cancellationToken);

        /// <summary>Gets watch now sources available in a country.</summary>
        /// <param name="countryCode">The 2-character country code (e.g. "us").</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the watch now sources for the specified country.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktWatchnowSource" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para>Note: Provided for API visibility and completeness; availability depends on Trakt.tv API backend support.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getwatchnowsourcescountry">
        /// Trakt API Documentation: Watch Now - Get watch now sources by country
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid country code) of the request fails.</exception>
        public Task<TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>> GetWatchnowSourcesAsync(string countryCode, CancellationToken cancellationToken = default)
            => GetWatchnowSourcesCountryImplAsync(countryCode, cancellationToken);
    }
}
