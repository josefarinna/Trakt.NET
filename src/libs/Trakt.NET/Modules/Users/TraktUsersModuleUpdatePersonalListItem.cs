using System.Net.Http.Json;

namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Update the notes on a single list item.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list item should be updated.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the item should be updated.</param>
        /// <param name="listItemId">The id of the list item which should be updated.</param>
        /// <param name="notes">The new list item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/update-list-item/update-a-list-item">
        /// Trakt API Documentation - Users: Update List Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UpdatePersonalListItemAsync(string usernameOrSlug, string listIdOrSlug,
            uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
            => UpdatePersonalListItemImplAsync(usernameOrSlug, listIdOrSlug, listItemId, notes, cancellationToken);

        /// <summary>Update the notes on a single list item.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list item should be updated.</param>
        /// <param name="traktListId">The Trakt-ID of the list, for which the item should be updated.</param>
        /// <param name="listItemId">The id of the list item which should be updated.</param>
        /// <param name="notes">The new list item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/update-list-item/update-a-list-item">
        /// Trakt API Documentation - Users: Update List Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse> UpdatePersonalListItemAsync(string usernameOrSlug, uint traktListId,
            uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return UpdatePersonalListItemAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), listItemId, notes, cancellationToken);
        }

        /// <summary>Update the notes on a single list item.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list item should be updated.</param>
        /// <param name="listIds">The ids of the list, for which the item should be updated.</param>
        /// <param name="listItemId">The id of the list item which should be updated.</param>
        /// <param name="notes">The new list item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/update-list-item/update-a-list-item">
        /// Trakt API Documentation - Users: Update List Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse> UpdatePersonalListItemAsync(string usernameOrSlug, TraktListIDs listIds,
            uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return UpdatePersonalListItemAsync(usernameOrSlug, listIds.BestID, listItemId, notes, cancellationToken);
        }

        /// <summary>Update the notes on a single list item.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list item should be updated.</param>
        /// <param name="list">The list, for which the item should be updated.</param>
        /// <param name="listItemId">The id of the list item which should be updated.</param>
        /// <param name="notes">The new list item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/update-list-item/update-a-list-item">
        /// Trakt API Documentation - Users: Update List Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse> UpdatePersonalListItemAsync(string usernameOrSlug, TraktList list,
            uint listItemId, string? notes = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return UpdatePersonalListItemAsync(usernameOrSlug, list.IDs!, listItemId, notes, cancellationToken);
        }
    }
}
