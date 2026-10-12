namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets a summary of an user's lists that are ready to become smart lists.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the smart list drafts summary should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list drafts summary.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListDraftsSummary" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssmartlistdrafts">
        /// Trakt API Documentation: Users: Smart List Drafts
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSmartListDraftsSummary>> GetSmartListDraftsSummaryAsync(string usernameOrSlug,
            CancellationToken cancellationToken = default)
            => GetSmartListDraftsSummaryImplAsync(usernameOrSlug, cancellationToken);
    }
}
