namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets an user's single personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried personal list informations.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list/get-personal-list">
        /// Trakt API Documentation - Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktList>> GetPersonalListAsync(string usernameOrSlug, string listIdOrSlug,
            CancellationToken cancellationToken = default)
            => GetPersonalListImplAsync(usernameOrSlug, listIdOrSlug, cancellationToken);

        /// <summary>Gets an user's single personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be queried.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried personal list informations.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list/get-personal-list">
        /// Trakt API Documentation - Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktList>> GetPersonalListAsync(string usernameOrSlug, uint traktListId,
            CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetPersonalListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Gets an user's single personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be queried.</param>
        /// <param name="listIds">The ids of the personal list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried personal list informations.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list/get-personal-list">
        /// Trakt API Documentation - Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktList>> GetPersonalListAsync(string usernameOrSlug, TraktListIDs listIds,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetPersonalListAsync(usernameOrSlug, listIds.BestID, cancellationToken);
        }
    }
}
