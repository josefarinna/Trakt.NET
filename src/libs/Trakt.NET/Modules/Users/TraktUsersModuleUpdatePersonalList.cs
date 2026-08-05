using System.Net.Http.Json;

namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Updates an user's personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be updated.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, which should be updated.</param>
        /// <param name="personalListPost">An <see cref="TraktUserPersonalListPost" /> instance containing the data about the to be updated list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list/update-personal-list">
        /// Trakt API Documentation: Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktList>> UpdatePersonalListAsync(string usernameOrSlug, string listIdOrSlug,
            TraktUserPersonalListPost personalListPost, CancellationToken cancellationToken = default)
            => UpdatePersonalListImplAsync(usernameOrSlug, listIdOrSlug, personalListPost, cancellationToken);

        /// <summary>Updates an user's personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be updated.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, which should be updated.</param>
        /// <param name="personalListPost">An <see cref="TraktUserPersonalListPost" /> instance containing the data about the to be updated list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list/update-personal-list">
        /// Trakt API Documentation: Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktList>> UpdatePersonalListAsync(string usernameOrSlug, uint traktListId,
            TraktUserPersonalListPost personalListPost, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return UpdatePersonalListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), personalListPost, cancellationToken);
        }

        /// <summary>Updates an user's personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be updated.</param>
        /// <param name="listIds">The ids of the personal list, which should be updated.</param>
        /// <param name="personalListPost">An <see cref="TraktUserPersonalListPost" /> instance containing the data about the to be updated list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list/update-personal-list">
        /// Trakt API Documentation: Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktList>> UpdatePersonalListAsync(string usernameOrSlug, TraktListIDs listIds,
            TraktUserPersonalListPost personalListPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return UpdatePersonalListAsync(usernameOrSlug, listIds.BestID, personalListPost, cancellationToken);
        }

        /// <summary>Updates an user's personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be updated.</param>
        /// <param name="list">The personal list, which should be updated.</param>
        /// <param name="personalListPost">An <see cref="TraktUserPersonalListPost" /> instance containing the data about the to be updated list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/list/update-personal-list">
        /// Trakt API Documentation: Users: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktList>> UpdatePersonalListAsync(string usernameOrSlug, TraktList list,
            TraktUserPersonalListPost personalListPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return UpdatePersonalListAsync(usernameOrSlug, list.IDs!, personalListPost, cancellationToken);
        }
    }
}
