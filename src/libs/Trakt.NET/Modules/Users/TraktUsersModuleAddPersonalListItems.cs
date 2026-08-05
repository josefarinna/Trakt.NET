using System.Net.Http.Json;

namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Adds items to an user's personal list. Accepts shows, seasons, episodes, movies and people.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be added to a personal list.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, to which items should be added.</param>
        /// <param name="listItemsPost">An <see cref="TraktUserPersonalListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing  information about which items were added, existing and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserPersonalListItemsPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/add-list-items/add-items-to-personal-list">
        /// Trakt API Documentation: Users: List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserPersonalListItemsPostResponse>> AddPersonalListItemsAsync(string usernameOrSlug, string listIdOrSlug,
            TraktUserPersonalListItemsPost listItemsPost, CancellationToken cancellationToken = default)
            => AddPersonalListItemsImplAsync(usernameOrSlug, listIdOrSlug, listItemsPost, cancellationToken);

        /// <summary>Adds items to an user's personal list. Accepts shows, seasons, episodes, movies and people.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be added to a personal list.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, to which items should be added.</param>
        /// <param name="listItemsPost">An <see cref="TraktUserPersonalListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing  information about which items were added, existing and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserPersonalListItemsPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/add-list-items/add-items-to-personal-list">
        /// Trakt API Documentation: Users: List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktUserPersonalListItemsPostResponse>> AddPersonalListItemsAsync(string usernameOrSlug, uint traktListId,
            TraktUserPersonalListItemsPost listItemsPost, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return AddPersonalListItemsAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), listItemsPost, cancellationToken);
        }

        /// <summary>Adds items to an user's personal list. Accepts shows, seasons, episodes, movies and people.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be added to a personal list.</param>
        /// <param name="listIds">The ids of the personal list, to which items should be added.</param>
        /// <param name="listItemsPost">An <see cref="TraktUserPersonalListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing  information about which items were added, existing and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserPersonalListItemsPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/add-list-items/add-items-to-personal-list">
        /// Trakt API Documentation: Users: List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktUserPersonalListItemsPostResponse>> AddPersonalListItemsAsync(string usernameOrSlug, TraktListIDs listIds,
            TraktUserPersonalListItemsPost listItemsPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return AddPersonalListItemsAsync(usernameOrSlug, listIds.BestID, listItemsPost, cancellationToken);
        }

        /// <summary>Adds items to an user's personal list. Accepts shows, seasons, episodes, movies and people.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be added to a personal list.</param>
        /// <param name="list">The personal list, to which items should be added.</param>
        /// <param name="listItemsPost">An <see cref="TraktUserPersonalListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing  information about which items were added, existing and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserPersonalListItemsPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/add-list-items/add-items-to-personal-list">
        /// Trakt API Documentation: Users: List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktUserPersonalListItemsPostResponse>> AddPersonalListItemsAsync(string usernameOrSlug, TraktList list,
            TraktUserPersonalListItemsPost listItemsPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return AddPersonalListItemsAsync(usernameOrSlug, list.IDs!, listItemsPost, cancellationToken);
        }
    }
}
