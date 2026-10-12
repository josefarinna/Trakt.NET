namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets a smart list draft for an user's personal list that stopped updating.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the smart list draft should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, for which the smart list draft should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list draft.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListDraft" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistsmartlistdraft">
        /// Trakt API Documentation: Users: Lists: Smart List Draft
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSmartListDraft>> GetSmartListDraftAsync(string usernameOrSlug, string listIdOrSlug,
            CancellationToken cancellationToken = default)
            => GetSmartListDraftImplAsync(usernameOrSlug, listIdOrSlug, cancellationToken);

        /// <summary>Gets a smart list draft for an user's personal list that stopped updating.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the smart list draft should be queried.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, for which the smart list draft should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list draft.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListDraft" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistsmartlistdraft">
        /// Trakt API Documentation: Users: Lists: Smart List Draft
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktSmartListDraft>> GetSmartListDraftAsync(string usernameOrSlug, uint traktListId,
            CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetSmartListDraftAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Gets a smart list draft for an user's personal list that stopped updating.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the smart list draft should be queried.</param>
        /// <param name="listIds">The ids of the personal list, for which the smart list draft should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list draft.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListDraft" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistsmartlistdraft">
        /// Trakt API Documentation: Users: Lists: Smart List Draft
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktSmartListDraft>> GetSmartListDraftAsync(string usernameOrSlug, TraktListIDs listIds,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetSmartListDraftAsync(usernameOrSlug, listIds.BestID, cancellationToken);
        }

        /// <summary>Gets a smart list draft for an user's personal list that stopped updating.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the smart list draft should be queried.</param>
        /// <param name="list">The personal list, for which the smart list draft should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list draft.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListDraft" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistsmartlistdraft">
        /// Trakt API Documentation: Users: Lists: Smart List Draft
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktSmartListDraft>> GetSmartListDraftAsync(string usernameOrSlug, TraktList list,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return GetSmartListDraftAsync(usernameOrSlug, list.IDs!, cancellationToken);
        }
    }
}
