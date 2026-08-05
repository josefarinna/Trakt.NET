namespace TraktNET
{
    public sealed partial class TraktListsModule
    {
        /// <summary>Gets a <see cref="TraktList" /> with the given Trakt-ID.</summary>
        /// <param name="listIdOrSlug">The list's Trakt-ID or -Slug. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the list items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getlistssummary">
        /// Trakt API Documentation: Lists: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktList>> GetListAsync(string listIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetListImplAsync(listIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets a <see cref="TraktList" /> with the given Trakt-ID.</summary>
        /// <param name="traktListId">The list's Trakt-ID. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the list items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getlistssummary">
        /// Trakt API Documentation: Lists: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktList>> GetListAsync(uint traktListId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetListAsync(traktListId.ToInvariantCultureString(), extendedInfo, cancellationToken);
        }

        /// <summary>Gets a <see cref="TraktList" /> with the given Trakt-ID.</summary>
        /// <param name="listIds">The list's ids. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the list items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getlistssummary">
        /// Trakt API Documentation: Lists: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktList>> GetListAsync(TraktListIDs listIds, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetListAsync(listIds.BestID, extendedInfo, cancellationToken);
        }
    }
}
