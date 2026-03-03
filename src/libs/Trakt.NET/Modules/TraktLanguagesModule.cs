namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to languages.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/languages">"Trakt API Documentation - Languages"</a> section.
    /// </summary>
    public sealed partial class TraktLanguagesModule
    {
        /// <summary>Gets a list of all languages, including the 2 digit code and name.</summary>
        /// <param name="languageType">The languages type(s), which will be returned. See also <seealso cref="TraktLanguageItemType" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A response of type <see cref="TraktListResponse{TraktLanguage}" /> containing the queried languages.</returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/languages/list/get-languages">
        /// Trakt API Documentation: Languages: List - Get languages
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktLanguage>> GetLanguagesAsync(TraktLanguageItemType languageType, CancellationToken cancellationToken = default)
            => GetLanguagesImplAsync(languageType, cancellationToken);
    }
}
