namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to certifications.
    /// <para>This module contains all methods of the "Trakt API Documentation - Certification" section.</para>
    /// </summary>
    public sealed partial class TraktCertificationsModule
    {
        /// <summary>Gets all movie certifications.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried movie certifications.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCertifications" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcertificationsmovies">
        /// Trakt API Documentation: Certifications: List - Get certifications
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktResponse<TraktCertifications>> GetMovieCertificationsAsync(CancellationToken cancellationToken = default)
            => GetMovieCertificationsImplAsync(cancellationToken);

        /// <summary>Gets all show certifications.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried show certifications.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCertifications" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcertificationsshows">
        /// Trakt API Documentation: Certifications: List - Get certifications
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktResponse<TraktCertifications>> GetShowCertificationsAsync(CancellationToken cancellationToken = default)
            => GetShowCertificationsImplAsync(cancellationToken);
    }
}
