namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Reports an user's list for moderator review.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list should be reported.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, which should be reported.</param>
        /// <param name="reason">The reason for reporting the list. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistslistreport">
        /// Trakt API Documentation: Users: Report a user's list
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> ReportPersonalListAsync(string usernameOrSlug, string listIdOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportUserListImplAsync(usernameOrSlug, listIdOrSlug, reason, message, cancellationToken);

        /// <summary>Reports an user's list for moderator review.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list should be reported.</param>
        /// <param name="traktListId">The Trakt-ID of the list, which should be reported.</param>
        /// <param name="reason">The reason for reporting the list. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistslistreport">
        /// Trakt API Documentation: Users: Report a user's list
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse> ReportPersonalListAsync(string usernameOrSlug, uint traktListId, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return ReportPersonalListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), reason, message, cancellationToken);
        }

        /// <summary>Reports an user's list for moderator review.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list should be reported.</param>
        /// <param name="listIds">The ids of the list, which should be reported.</param>
        /// <param name="reason">The reason for reporting the list. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistslistreport">
        /// Trakt API Documentation: Users: Report a user's list
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse> ReportPersonalListAsync(string usernameOrSlug, TraktListIDs listIds, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return ReportPersonalListAsync(usernameOrSlug, listIds.BestID, reason, message, cancellationToken);
        }

        /// <summary>Reports an user's list for moderator review.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list should be reported.</param>
        /// <param name="list">The list, which should be reported.</param>
        /// <param name="reason">The reason for reporting the list. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistslistreport">
        /// Trakt API Documentation: Users: Report a user's list
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse> ReportPersonalListAsync(string usernameOrSlug, TraktList list, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return ReportPersonalListAsync(usernameOrSlug, list.IDs!, reason, message, cancellationToken);
        }
    }
}
