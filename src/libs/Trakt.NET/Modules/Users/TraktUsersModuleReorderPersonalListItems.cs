using System.Net.Http.Json;

namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Reorders an user's personal list items.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be reordered.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the items should be reordered.</param>
        /// <param name="reorderedListItemsRank">A collection of list item ids. Represents the new order of an user's personal list items.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal list items order.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktListItemsReorderPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/reorder-list-items/reorder-items-on-a-list">
        /// Trakt API Documentation: Users: Reorder List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderPersonalListItemsAsync(string usernameOrSlug, string listIdOrSlug,
            List<uint> reorderedListItemsRank, CancellationToken cancellationToken = default)
            => ReorderPersonalListItemsImplAsync(usernameOrSlug, listIdOrSlug, reorderedListItemsRank, cancellationToken);

        /// <summary>Reorders an user's personal list items.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be reordered.</param>
        /// <param name="traktListId">The Trakt-ID of the list, for which the items should be reordered.</param>
        /// <param name="reorderedListItemsRank">A collection of list item ids. Represents the new order of an user's personal list items.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal list items order.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktListItemsReorderPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/reorder-list-items/reorder-items-on-a-list">
        /// Trakt API Documentation: Users: Reorder List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderPersonalListItemsAsync(string usernameOrSlug, uint traktListId,
            List<uint> reorderedListItemsRank, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));
            
            return ReorderPersonalListItemsAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), reorderedListItemsRank, cancellationToken);
        }

        /// <summary>Reorders an user's personal list items.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be reordered.</param>
        /// <param name="listIds">The ids of the list, for which the items should be reordered.</param>
        /// <param name="reorderedListItemsRank">A collection of list item ids. Represents the new order of an user's personal list items.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal list items order.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktListItemsReorderPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/reorder-list-items/reorder-items-on-a-list">
        /// Trakt API Documentation: Users: Reorder List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderPersonalListItemsAsync(string usernameOrSlug, TraktListIDs listIds,
            List<uint> reorderedListItemsRank, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return ReorderPersonalListItemsAsync(usernameOrSlug, listIds.BestID, reorderedListItemsRank, cancellationToken);
        }

        /// <summary>Reorders an user's personal list items.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be reordered.</param>
        /// <param name="list">The list, for which the items should be reordered.</param>
        /// <param name="reorderedListItemsRank">A collection of list item ids. Represents the new order of an user's personal list items.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal list items order.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktListItemsReorderPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/reorder-list-items/reorder-items-on-a-list">
        /// Trakt API Documentation: Users: Reorder List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderPersonalListItemsAsync(string usernameOrSlug, TraktList list,
            List<uint> reorderedListItemsRank, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return ReorderPersonalListItemsAsync(usernameOrSlug, list.IDs!, reorderedListItemsRank, cancellationToken);
        }
    }
}
