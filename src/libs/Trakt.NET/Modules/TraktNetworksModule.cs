namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to networks.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/networks">"Trakt API Documentation - Networks"</a> section.
    /// </summary>
    public sealed partial class TraktNetworksModule
    {
        /// <summary>Gets a list of all networks.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried networks.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNetwork" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getnetworkslist">
        /// Trakt API Documentation: Networks: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktNetwork>> GetNetworksAsync(CancellationToken cancellationToken = default)
            => GetNetworksImplAsync(cancellationToken);
    }
}
