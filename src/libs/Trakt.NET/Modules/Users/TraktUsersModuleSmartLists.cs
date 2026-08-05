namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets a user's smart lists.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart lists should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried smart lists.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssmartlistspersonal">
        /// Trakt API Documentation: Users: Smart Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktSmartList>> GetSmartListsAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
            => GetSmartListsImplAsync(usernameOrSlug, cancellationToken);

        /// <summary>Creates a new smart list for a user.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be created.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the list to be created.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully created smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserssmartlistscreate">
        /// Trakt API Documentation: Users: Smart Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSmartListPostResponse>> CreateSmartListAsync(string usernameOrSlug, TraktSmartListPost smartListPost,
            CancellationToken cancellationToken = default)
            => CreateSmartListImplAsync(usernameOrSlug, smartListPost, cancellationToken);

        /// <summary>Gets a user's single smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the smart list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssmartlistssmartlistsummary">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSmartList>> GetSmartListAsync(string usernameOrSlug, string listIdOrSlug,
            CancellationToken cancellationToken = default)
            => GetSmartListImplAsync(usernameOrSlug, listIdOrSlug, cancellationToken);

        /// <summary>Gets a user's single smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be queried.</param>
        /// <param name="traktListId">The Trakt-ID of the smart list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssmartlistssmartlistsummary">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktSmartList>> GetSmartListAsync(string usernameOrSlug, uint traktListId,
            CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetSmartListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Gets a user's single smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be queried.</param>
        /// <param name="listIds">The ids of the smart list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssmartlistssmartlistsummary">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktSmartList>> GetSmartListAsync(string usernameOrSlug, TraktListIDs listIds,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetSmartListAsync(usernameOrSlug, listIds.BestID, cancellationToken);
        }

        /// <summary>Gets a user's single smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be queried.</param>
        /// <param name="list">The smart list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssmartlistssmartlistsummary">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktSmartList>> GetSmartListAsync(string usernameOrSlug, TraktSmartList list,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);
            return GetSmartListAsync(usernameOrSlug, list.IDs!, cancellationToken);
        }

        /// <summary>Updates a user's smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be updated.</param>
        /// <param name="listIdOrSlug">The id or slug of the smart list, which should be updated.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the list to be updated.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putuserssmartlistssmartlistupdate">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSmartList>> UpdateSmartListAsync(string usernameOrSlug, string listIdOrSlug,
            TraktSmartListPost smartListPost, CancellationToken cancellationToken = default)
            => UpdateSmartListImplAsync(usernameOrSlug, listIdOrSlug, smartListPost, cancellationToken);

        /// <summary>Updates a user's smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be updated.</param>
        /// <param name="traktListId">The Trakt-ID of the smart list, which should be updated.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the list to be updated.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putuserssmartlistssmartlistupdate">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktSmartList>> UpdateSmartListAsync(string usernameOrSlug, uint traktListId,
            TraktSmartListPost smartListPost, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return UpdateSmartListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), smartListPost, cancellationToken);
        }

        /// <summary>Updates a user's smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be updated.</param>
        /// <param name="listIds">The ids of the smart list, which should be updated.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the list to be updated.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putuserssmartlistssmartlistupdate">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktSmartList>> UpdateSmartListAsync(string usernameOrSlug, TraktListIDs listIds,
            TraktSmartListPost smartListPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return UpdateSmartListAsync(usernameOrSlug, listIds.BestID, smartListPost, cancellationToken);
        }

        /// <summary>Updates a user's smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be updated.</param>
        /// <param name="list">The smart list, which should be updated.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the list to be updated.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putuserssmartlistssmartlistupdate">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktSmartList>> UpdateSmartListAsync(string usernameOrSlug, TraktSmartList list,
            TraktSmartListPost smartListPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);
            return UpdateSmartListAsync(usernameOrSlug, list.IDs!, smartListPost, cancellationToken);
        }

        /// <summary>Deletes a user's smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be deleted.</param>
        /// <param name="listIdOrSlug">The id or slug of the smart list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>A response containing no content.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserssmartlistssmartlistdelete">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> DeleteSmartListAsync(string usernameOrSlug, string listIdOrSlug,
            CancellationToken cancellationToken = default)
            => DeleteSmartListImplAsync(usernameOrSlug, listIdOrSlug, cancellationToken);

        /// <summary>Deletes a user's smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be deleted.</param>
        /// <param name="traktListId">The Trakt-ID of the smart list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>A response containing no content.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserssmartlistssmartlistdelete">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse> DeleteSmartListAsync(string usernameOrSlug, uint traktListId,
            CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return DeleteSmartListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Deletes a user's smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be deleted.</param>
        /// <param name="listIds">The ids of the smart list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>A response containing no content.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserssmartlistssmartlistdelete">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse> DeleteSmartListAsync(string usernameOrSlug, TraktListIDs listIds,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return DeleteSmartListAsync(usernameOrSlug, listIds.BestID, cancellationToken);
        }

        /// <summary>Deletes a user's smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for whom the smart list should be deleted.</param>
        /// <param name="list">The smart list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>A response containing no content.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserssmartlistssmartlistdelete">
        /// Trakt API Documentation: Users: Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse> DeleteSmartListAsync(string usernameOrSlug, TraktSmartList list,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);
            return DeleteSmartListAsync(usernameOrSlug, list.IDs!, cancellationToken);
        }
    }
}
