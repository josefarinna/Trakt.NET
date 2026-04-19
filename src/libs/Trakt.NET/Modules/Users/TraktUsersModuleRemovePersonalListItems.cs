using System.Net.Http.Json;

namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Removes items from an user's personal list. Accepts shows, seasons, episodes, movies and people.
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be removed from a personal list.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, from which items should be removed.</param>
        /// <param name="listItemsRemovePost">An <see cref="TraktUserPersonalListItemsRemovePost" /> instance containing all shows, seasons, episodes, movies and people, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserPersonalListItemsRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/remove-list-items/remove-items-from-personal-list">
        /// Trakt API Documentation - Users: Remove List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserPersonalListItemsRemovePostResponse>> RemovePersonalListItemsAsync(string usernameOrSlug, string listIdOrSlug,
            TraktUserPersonalListItemsRemovePost listItemsRemovePost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listItemsRemovePost);
            listItemsRemovePost.Validate();

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktUserPersonalListItemsRemovePostResponse>(_context, new UserPersonalListItemsRemovePostRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug,
                Content = JsonContent.Create(listItemsRemovePost)
            },
            cancellationToken);
        }

        /// <summary>Removes items from an user's personal list. Accepts shows, seasons, episodes, movies and people.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be removed from a personal list.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, from which items should be removed.</param>
        /// <param name="listItemsRemovePost">An <see cref="TraktUserPersonalListItemsRemovePost" /> instance containing all shows, seasons, episodes, movies and people, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserPersonalListItemsRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/remove-list-items/remove-items-from-personal-list">
        /// Trakt API Documentation - Users: Remove List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktUserPersonalListItemsRemovePostResponse>> RemovePersonalListItemsAsync(string usernameOrSlug, uint traktListId,
            TraktUserPersonalListItemsRemovePost listItemsRemovePost, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return RemovePersonalListItemsAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), listItemsRemovePost, cancellationToken);
        }

        /// <summary>Removes items from an user's personal list. Accepts shows, seasons, episodes, movies and people.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be removed from a personal list.</param>
        /// <param name="listIds">The ids of the personal list, from which items should be removed.</param>
        /// <param name="listItemsRemovePost">An <see cref="TraktUserPersonalListItemsRemovePost" /> instance containing all shows, seasons, episodes, movies and people, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserPersonalListItemsRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/remove-list-items/remove-items-from-personal-list">
        /// Trakt API Documentation - Users: Remove List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktUserPersonalListItemsRemovePostResponse>> RemovePersonalListItemsAsync(string usernameOrSlug, TraktListIDs listIds,
            TraktUserPersonalListItemsRemovePost listItemsRemovePost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return RemovePersonalListItemsAsync(usernameOrSlug, listIds.BestID, listItemsRemovePost, cancellationToken);
        }

        /// <summary>Removes items from an user's personal list. Accepts shows, seasons, episodes, movies and people.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be removed from a personal list.</param>
        /// <param name="list">The personal list, from which items should be removed.</param>
        /// <param name="listItemsRemovePost">An <see cref="TraktUserPersonalListItemsRemovePost" /> instance containing all shows, seasons, episodes, movies and people, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserPersonalListItemsRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/remove-list-items/remove-items-from-personal-list">
        /// Trakt API Documentation - Users: Remove List Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktUserPersonalListItemsRemovePostResponse>> RemovePersonalListItemsAsync(string usernameOrSlug, TraktList list,
            TraktUserPersonalListItemsRemovePost listItemsRemovePost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return RemovePersonalListItemsAsync(usernameOrSlug, list.IDs!, listItemsRemovePost, cancellationToken);
        }
    }
}
