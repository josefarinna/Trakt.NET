namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to languages.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/languages">"Trakt API Documentation - Languages"</a> section.
    /// </summary>
    public sealed partial class TraktLanguagesModule
    {
        /// <summary>Gets a list of all movie languages, including the 2 digit code and name.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried languages.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktLanguage" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getlanguageslist">
        /// Trakt API Documentation: Languages: List - Get languages
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktLanguage>> GetMovieLanguagesAsync(CancellationToken cancellationToken = default)
            => GetMovieLanguagesImplAsync(cancellationToken);

        /// <summary>Gets a list of all show languages, including the 2 digit code and name.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried languages.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktLanguage" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getlanguageslist">
        /// Trakt API Documentation: Languages: List - Get languages
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktLanguage>> GetShowLanguagesAsync(CancellationToken cancellationToken = default)
            => GetShowLanguagesImplAsync(cancellationToken);
    }
}
