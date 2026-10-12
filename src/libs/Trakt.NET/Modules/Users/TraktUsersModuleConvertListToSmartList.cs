namespace TraktNET
{
    public sealed partial class TraktUsersModule
    {
        /// <summary>Converts an user's personal list into a smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be converted.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, which should be converted.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the smart list to be created.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully converted smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistslistconvert">
        /// Trakt API Documentation: Users: Lists: Convert to Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktSmartListPostResponse>> ConvertListToSmartListAsync(string usernameOrSlug, string listIdOrSlug,
            TraktSmartListPost smartListPost, CancellationToken cancellationToken = default)
            => ConvertListToSmartListImplAsync(usernameOrSlug, listIdOrSlug, smartListPost, cancellationToken);

        /// <summary>Converts an user's personal list into a smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be converted.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, which should be converted.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the smart list to be created.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully converted smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistslistconvert">
        /// Trakt API Documentation: Users: Lists: Convert to Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<TraktSmartListPostResponse>> ConvertListToSmartListAsync(string usernameOrSlug, uint traktListId,
            TraktSmartListPost smartListPost, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return ConvertListToSmartListAsync(usernameOrSlug, traktListId.ToInvariantCultureString(), smartListPost, cancellationToken);
        }

        /// <summary>Converts an user's personal list into a smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be converted.</param>
        /// <param name="listIds">The ids of the personal list, which should be converted.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the smart list to be created.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully converted smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistslistconvert">
        /// Trakt API Documentation: Users: Lists: Convert to Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktSmartListPostResponse>> ConvertListToSmartListAsync(string usernameOrSlug, TraktListIDs listIds,
            TraktSmartListPost smartListPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listIds);

            if (!listIds.HasAnyID)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return ConvertListToSmartListAsync(usernameOrSlug, listIds.BestID, smartListPost, cancellationToken);
        }

        /// <summary>Converts an user's personal list into a smart list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be converted.</param>
        /// <param name="list">The personal list, which should be converted.</param>
        /// <param name="smartListPost">An <see cref="TraktSmartListPost" /> instance containing the data about the smart list to be created.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be caught.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully converted smart list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSmartListPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistslistconvert">
        /// Trakt API Documentation: Users: Lists: Convert to Smart List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<TraktSmartListPostResponse>> ConvertListToSmartListAsync(string usernameOrSlug, TraktList list,
            TraktSmartListPost smartListPost, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(list);

            return ConvertListToSmartListAsync(usernameOrSlug, list.IDs!, smartListPost, cancellationToken);
        }
    }
}
