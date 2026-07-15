namespace TraktNET
{
    public sealed partial class TraktListsModule
    {
        /// <summary>Reports a list for moderator review with the specified Trakt-ID or -Slug.</summary>
        /// <param name="listIdOrSlug">The id or slug of the list, which should be reported. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="reason">The reason for reporting the list. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postlistsreport">
        /// Trakt API Documentation: Lists: Report a list
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> ReportListAsync(string listIdOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportListImplAsync(listIdOrSlug, reason, message, cancellationToken);

        /// <summary>Reports a list for moderator review with the specified Trakt ID.</summary>
        /// <param name="traktListId">The Trakt ID of the list, which should be reported. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="reason">The reason for reporting the list. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postlistsreport">
        /// Trakt API Documentation: Lists: Report a list
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse> ReportListAsync(uint traktListId, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return ReportListAsync(traktListId.ToInvariantCultureString(), reason, message, cancellationToken);
        }

        /// <summary>Reports a list for moderator review with the specified <see cref="TraktListIDs" />.</summary>
        /// <param name="listIds">The ids of the list, which should be reported. See also <seealso cref="TraktListIDs" />.</param>
        /// <param name="reason">The reason for reporting the list. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postlistsreport">
        /// Trakt API Documentation: Lists: Report a list
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse> ReportListAsync(TraktListIDs listIds, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return ReportListAsync(listIds.BestID, reason, message, cancellationToken);
        }

        /// <summary>Reports a list for moderator review with the specified <see cref="TraktList" />.</summary>
        /// <param name="list">The list, which should be reported. See also <seealso cref="TraktList" />.</param>
        /// <param name="reason">The reason for reporting the list. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postlistsreport">
        /// Trakt API Documentation: Lists: Report a list
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse> ReportListAsync(TraktList list, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return ReportListAsync(list.IDs!, reason, message, cancellationToken);
        }
    }
}
