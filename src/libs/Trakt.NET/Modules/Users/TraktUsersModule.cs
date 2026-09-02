namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to users.
    /// <para>This module contains all methods of the "Trakt API Documentation - Users" section.</para>
    /// </summary>
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets the user's settings.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the user's settings.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserSettings" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssettings">
        /// Trakt API Documentation: Users: Retrieve settings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<TraktUserSettings>> GetSettingsAsync(CancellationToken cancellationToken = default)
            => GetSettingsImplAsync(cancellationToken);

        /// <summary>Updates/saves the user's settings.</summary>
        /// <param name="settings">The settings to update. See also <seealso cref="TraktUserSettingsPost" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the updated user's settings.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserSettings" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putuserssavesettings">
        /// Trakt API Documentation: Users: Update settings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserSettings>> UpdateSettingsAsync(TraktUserSettingsPost settings, CancellationToken cancellationToken = default)
            => UpdateSettingsImplAsync(settings, cancellationToken);

        /// <summary>Gets the user's pending follow requests.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the follow request users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried user pending follow request.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollowRequest" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getusersrequestsfollow">
        /// Trakt API Documentation: Users: Follower Requests
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktUserFollowRequest>> GetFollowRequestsAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetFollowRequestsImplAsync(extendedInfo, cancellationToken);

        /// <summary>Gets the user's pending following requests.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the following request users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried user pending following requests.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollowRequest" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getusersrequestsfollowing">
        /// Trakt API Documentation: Users: Following Requests
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktUserFollowRequest>> GetPendingFollowingRequestsAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetPendingFollowingRequestsImplAsync(extendedInfo, cancellationToken);

        /// <summary>Gets the user's hidden items, like movies, shows and / or seasons.</summary>
        /// <param name="hiddenItemsSection">Determines, from which section the hidden items should be queried. See also <seealso cref="TraktHiddenItemsSection" />.</param>
        /// <param name="hiddenItemType">Determines, which type of hidden items should be queried. See also <seealso cref="TraktHiddenItemType" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the hidden items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried hidden items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserHiddenItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getusershiddenget">
        /// Trakt API Documentation: Users: Hidden Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktUserHiddenItem>> GetHiddenItemsAsync(TraktHiddenItemsSection hiddenItemsSection,
            TraktHiddenItemType? hiddenItemType = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetHiddenItemsImplAsync(hiddenItemsSection, hiddenItemType, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets the saved filters a user has created.</summary>
        /// <param name="section">Determines, from which section the saved filters should be queried. See also <seealso cref="TraktFilterSection" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried saved filters.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserSavedFilter" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getusersfilterssaved">
        /// Trakt API Documentation: Users: Saved Filters
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktUserSavedFilter>> GetSavedFiltersAsync(TraktFilterSection? section = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetSavedFiltersImplAsync(section, page, limit, cancellationToken);

        /// <summary>Adds items to an user's hidden list. Accepts shows, seasons and movies.</summary>
        /// <param name="hiddenItemsPost">An <see cref="TraktUserHiddenItemsPost" /> instance containing all shows, seasons and movies, which should be added.</param>
        /// <param name="hiddenItemsSection">Determines, which type of hidden items section should be queried. <see cref="TraktHiddenItemsSection "/></param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were added and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserHiddenItemsPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postusershiddenadd">
        /// Trakt API Documentation: Users: Add Hidden Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserHiddenItemsPostResponse>> AddHiddenItemsAsync(TraktUserHiddenItemsPost hiddenItemsPost,
            TraktHiddenItemsSection hiddenItemsSection, CancellationToken cancellationToken = default)
            => AddHiddenItemsImplAsync(hiddenItemsPost, hiddenItemsSection, cancellationToken);

        /// <summary>Removes items from an user's hidden list. Accepts shows, seasons and movies.</summary>
        /// <param name="hiddenItemsRemovePost">An <see cref="TraktUserHiddenItemsRemovePost" /> instance containing all shows, seasons and movies, which should be removed.</param>
        /// <param name="hiddenItemsSection">Determines, which type of hidden items section should be queried. <see cref="TraktHiddenItemsSection "/></param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserHiddenItemsRemovePostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postusershiddenremovesection">
        /// Trakt API Documentation: Users: Remove Hidden Items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserHiddenItemsRemovePostResponse>> RemoveHiddenItemsAsync(TraktUserHiddenItemsRemovePost hiddenItemsRemovePost,
            TraktHiddenItemsSection hiddenItemsSection, CancellationToken cancellationToken = default)
            => RemoveHiddenItemsImplAsync(hiddenItemsRemovePost, hiddenItemsSection, cancellationToken);

        /// <summary>Gets the items (movies, shows, seasons, episodes, persons, comments, lists) the user likes.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the likes should be queried.</param>
        /// <param name="likeType">Determines, which type of objects liked should be queried. See also <seealso cref="TraktUserLikeType" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried like items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserLikeItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslikes">
        /// Trakt API Documentation: Users: Likes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktUserLikeItem>> GetLikesAsync(string usernameOrSlug, TraktUserLikeType? likeType = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetLikesImplAsync(usernameOrSlug, likeType, page, limit, cancellationToken);

        /// <summary>Gets an user's profile information.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the profile should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the user's profile.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the user's profile information.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersprofile">
        /// Trakt API Documentation: Users: Profile
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUser>> GetUserProfileAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetUserProfileImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets all collected movies in an user's collection.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the collected movies should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the collected movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containingall collected movies in a user collection.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktCollectionMovie" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserscollection">
        /// Trakt API Documentation: Users: Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktCollectionMovie>> GetCollectionMoviesAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetCollectionMoviesImplAsync(usernameOrSlug, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all collected shows in an user's collection.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the collected shows should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the collected shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containingall collected shows in a user collection.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktCollectionShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserscollection">
        /// Trakt API Documentation: Users: Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktCollectionShow>> GetCollectionShowsAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetCollectionShowsImplAsync(usernameOrSlug, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all comments an user has posted, sorted by most recent.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the comments should be queried.</param>
        /// <param name="type">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="objectType">Determines, for which object types comments should be queried. See also <seealso cref="TraktCommentObjectType" />.</param>
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the commented objects.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserscomments">
        /// Trakt API Documentation: Users: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktUserComment>> GetCommentsAsync(string usernameOrSlug, TraktCommentType? type = null,
            TraktCommentObjectType? objectType = null, TraktIncludeReplies? includeReplies = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetCommentsImplAsync(usernameOrSlug, type, objectType, includeReplies, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets an user's personal lists.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal lists should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried personal lists.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistslistsummary">
        /// Trakt API Documentation: Users: Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktList>> GetPersonalListsAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
            => GetPersonalListsImplAsync(usernameOrSlug, cancellationToken);

        /// <summary>Creates a new personal list.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be created.</param>
        /// <param name="personalListPost">An <see cref="TraktUserPersonalListPost" /> instance containing the data about the to be created list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully created personal list.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistscreate">
        /// Trakt API Documentation: Users: Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktList>> CreatePersonalListAsync(string usernameOrSlug, TraktUserPersonalListPost personalListPost,
           CancellationToken cancellationToken = default)
            => CreatePersonalListImplAsync(usernameOrSlug, personalListPost, cancellationToken);

        /// <summary>Reorders an user's personal lists.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal lists should be reordered.</param>
        /// <param name="reorderedListsRank">A collection of list ids. Represents the new order of an user's personal lists.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal lists order.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktListItemsReorderPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postuserslistsreorder">
        /// Trakt API Documentation: Users: Reorder Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktListItemsReorderPostResponse>> ReorderPersonalListsAsync(string usernameOrSlug, List<uint> reorderedListsRank,
            CancellationToken cancellationToken = default)
            => ReorderPersonalListsImplAsync(usernameOrSlug, reorderedListsRank, cancellationToken);

        /// <summary>Gets all lists a user can collaborate on.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the collaborations should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried lists.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserslistscollaborations">
        /// Trakt API Documentation: Users: Collaborations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktList>> GetListCollaborationsAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
            => GetListCollaborationsImplAsync(usernameOrSlug, cancellationToken);

        /// <summary>Gets an user's followers.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the followers should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the follower users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried followers.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollower" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersfollowers">
        /// Trakt API Documentation: Users: Followers
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktUserFollower>> GetFollowersAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetFollowersImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets users an user is following.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the following users should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the following users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried following users.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollower" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersfollowing">
        /// Trakt API Documentation: Users: Following
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktUserFollower>> GetFollowingAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetFollowingImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets an user's friends.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the friends should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the friend users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried friend users.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFriend" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersfriends">
        /// Trakt API Documentation: Users: Friends
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktUserFriend>> GetFriendsAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetFriendsImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Sends a follow request for an user with the given username.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be followed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information whether the request was successful.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollowUserPostResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postusersfollow">
        /// Trakt API Documentation: Users: Follow
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserFollowUserPostResponse>> FollowUserAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
            => FollowUserImplAsync(usernameOrSlug, cancellationToken);

        /// <summary>Sends an unfollow request for an user with the given username.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be unfollowed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteusersunfollow">
        /// Trakt API Documentation: Users: Follow
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UnfollowUserAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
            => UnfollowUserImplAsync(usernameOrSlug, cancellationToken);

        /// <summary>Approves a follower request with the given id.</summary>
        /// <param name="followerRequestId">The id of the follower request, which should be approved.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the approved user.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollower" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postusersrequestsapprove">
        /// Trakt API Documentation: Users: Approve or Deny Follower Requests
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserFollower>> ApproveFollowRequestAsync(uint followerRequestId, CancellationToken cancellationToken = default)
            => ApproveFollowRequestImplAsync(followerRequestId, cancellationToken);

        /// <summary>Denies a follower request with the given id.</summary>
        /// <param name="followerRequestId">The id of the follower request, which should be denied.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteusersrequestsdeny">
        /// Trakt API Documentation: Users: Approve or Deny Follower Requests
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> DenyFollowRequestAsync(uint followerRequestId, CancellationToken cancellationToken = default)
            => DenyFollowRequestImplAsync(followerRequestId, cancellationToken);

        /// <summary>Gets all movies, shows, seasons and / or episodes an user has watched, sorted by most recent.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watched history should be queried.</param>
        /// <param name="historyItemType">Determines, which type of history items should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
        /// <param name="itemId">The Trakt Id for the item, which should be specifically queried. Will be ignored, if <paramref name="historyItemType" /> is not set or unspecified.</param>
        /// <param name="startAt">The datetime, after which history items should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="endAt">The datetime, until which history items should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried history items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktHistoryItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusershistoryall">
        /// Trakt API Documentation: Users: History
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktHistoryItem>> GetWatchedHistoryAsync(string usernameOrSlug, TraktSyncItemType? historyItemType = null,
            uint? itemId = null, DateTime? startAt = null, DateTime? endAt = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchedHistoryImplAsync(usernameOrSlug, historyItemType, itemId, startAt, endAt, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets an user's favorite movies and / or shows.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the favorites should be queried.</param>
        /// <param name="favoriteObjectType">Determines, which type of favorites items should be queried. See also <seealso cref="TraktFavoriteObjectType" />.</param>
        /// <param name="sortBy">Sort by value for the favorited items.</param>
        /// <param name="sortHow">Sort how value for the favorited items.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the favorited items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried favorite items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktFavorite" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getusersfavoritesmedia">
        /// Trakt API Documentation: Users: Favorites
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktFavorite>> GetFavoritesAsync(string usernameOrSlug, TraktFavoriteObjectType? favoriteObjectType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetFavoritesImplAsync(usernameOrSlug, favoriteObjectType, sortBy, sortHow, extendedInfo, page, limit, cancellationToken);

        /// <summary>Returns all top level comments for the favorites.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the favorites comments should be queried.</param>
        /// <param name="sortOrder">Determines the sort order of the returned favorites comments. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried favorites comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersfavoritescomments">
        /// Trakt API Documentation: Users: Favorites Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetFavoritesCommentsAsync(string usernameOrSlug, TraktCommentSortOrder? sortOrder = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetFavoritesCommentsImplAsync(usernameOrSlug, sortOrder, page, limit, cancellationToken);

        /// <summary>Gets an user's ratings for movies, shows, seasons and / or episodes.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the ratings should be queried.</param>
        /// <param name="ratingsItemType">Determines, which type of rating items should be queried. See also <seealso cref="TraktRatingsItemType" />.</param>
        /// <param name="ratingsFilter">
        /// An array of numbers. Numbers should be between 1 and 10.
        /// Will be ignored, if the given array contains a number higher than 10 or below 1 or if it contains more than ten numbers.
        /// Will be ignored, if the given <paramref name="ratingsItemType" /> is null or unspecified.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the rating items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried rating items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktRatingsItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersratingsall">
        /// Trakt API Documentation: Users: Ratings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktRatingsItem>> GetRatingsAsync(string usernameOrSlug, TraktRatingsItemType? ratingsItemType = null,
            uint[]? ratingsFilter = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetRatingsImplAsync(usernameOrSlug, ratingsItemType, ratingsFilter, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all items in an user's watchlist.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watchlist items should be queried.</param>
        /// <param name="watchlistItemType">Determines, which type of items in the watchlist should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
        /// <param name="sortBy">Sort by value for the watchlist items.</param>
        /// <param name="sortHow">Sort how value for the watchlist items.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watchlist items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watchlist items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchlistItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getuserswatchlist">
        /// Trakt API Documentation: Users: Watchlist
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktWatchlistItem>> GetWatchlistAsync(string usernameOrSlug, TraktSyncItemType? watchlistItemType = null,
            TraktSortBy? sortBy = null, TraktSortHow? sortHow = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetWatchlistImplAsync(usernameOrSlug, watchlistItemType, sortBy, sortHow, extendedInfo, page, limit, cancellationToken);

        /// <summary>Returns all top level comments for the watchlist.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watchlist comments should be queried.</param>
        /// <param name="sortOrder">Determines the sort order of the returned watchlist comments. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watchlist comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserswatchlistcomments">
        /// Trakt API Documentation: Users: Watchlist Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetWatchlistCommentsAsync(string usernameOrSlug, TraktCommentSortOrder? sortOrder = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchlistCommentsImplAsync(usernameOrSlug, sortOrder, page, limit, cancellationToken);

        /// <summary>Gets the movie or episode an user is currently watching.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the currently watching item should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the currently watching items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the movie or episode an user is currently watching.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserWatchingItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserswatching">
        /// Trakt API Documentation: Users: Watching
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserWatchingItem>> GetWatchingAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetWatchingImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets all movies an user has watched, sorted by most plays.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watched movies should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watched movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watched movies.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedMovie" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserswatched">
        /// Trakt API Documentation: Users: Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktWatchedMovie>> GetWatchedMoviesAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchedMoviesImplAsync(usernameOrSlug, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all shows an user has watched, sorted by most plays.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watched shows should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watched shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watched shows.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedShow" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserswatched">
        /// Trakt API Documentation: Users: Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktWatchedShow>> GetWatchedShowsAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchedShowsImplAsync(usernameOrSlug, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all episodes an user has watched, sorted by most plays.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watched episodes should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episodes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Number of page of items to be queried. Will be applied only, if limit is also set.</param>
        /// <param name="limit">Number of items per page to be queried. Will be applied only, if page is also set.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watched episodes.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedEpisode" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getuserswatched">
        /// Trakt API Documentation: Users: Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktWatchedEpisode>> GetWatchedEpisodesAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetWatchedEpisodesImplAsync(usernameOrSlug, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets statistics about the movies, shows and episodes an user has watched.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the statistics should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing statistics about movies, shows and episodes.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserStatistics" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersstats">
        /// Trakt API Documentation: Users: Stats
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserStatistics>> GetStatisticsAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
            => GetStatisticsImplAsync(usernameOrSlug, cancellationToken);

        /// <summary>Gets the most recently notes for a user.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the notes should be queried.</param>
        /// <param name="notesObjectType">Determines, which type of notes should be queried. See also <seealso cref="TraktNotesObjectType" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the notes media items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried notes items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktNoteItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersnotes">
        /// Trakt API Documentation: Users: Notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktNoteItem>> GetUserNotesAsync(string usernameOrSlug, TraktNotesObjectType? notesObjectType = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetUserNotesImplAsync(usernameOrSlug, notesObjectType, extendedInfo, page, limit, cancellationToken);

        /// <summary>Reports a user for moderator review with the given id.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be reported.</param>
        /// <param name="reason">The reason for reporting the user. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">The message for additional context.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postusersreport">
        /// Trakt API Documentation: Users: Report a User
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> ReportUserAsync(string usernameOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportUserImplAsync(usernameOrSlug, reason, message, cancellationToken);

        /// <summary>Gets a list of users you have blocked.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the blocked users.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserBlockedUser" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getusersblocked">
        /// Trakt API Documentation: Users: Get blocked users
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktUserBlockedUser>> GetBlockedUsersAsync(CancellationToken cancellationToken = default)
            => GetBlockedUsersImplAsync(cancellationToken);

        /// <summary>Blocks a user.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user to block.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postusersblock">
        /// Trakt API Documentation: Users: Block this user
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> BlockUserAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
            => BlockUserImplAsync(usernameOrSlug, cancellationToken);

        /// <summary>Unblocks a user.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user to unblock.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteusersunblock">
        /// Trakt API Documentation: Users: Unblock this user
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UnblockUserAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
            => UnblockUserImplAsync(usernameOrSlug, cancellationToken);

        /// <summary>Updates the authenticated user's avatar.</summary>
        /// <param name="avatar">The avatar image data in base64.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putusersavatar">
        /// Trakt API Documentation: Users: Update avatar
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UpdateAvatarAsync(string avatar, CancellationToken cancellationToken = default)
            => UpdateAvatarImplAsync(avatar, cancellationToken);

        /// <summary>Updates the authenticated user's cover image.</summary>
        /// <param name="coverType">The type of the cover image. See also <seealso cref="TraktCoverType" />.</param>
        /// <param name="coverId">The Trakt ID of the movie, show, or episode.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putuserscover">
        /// Trakt API Documentation: Users: Update cover image
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UpdateCoverImageAsync(TraktCoverType coverType, uint coverId, CancellationToken cancellationToken = default)
            => UpdateCoverImageImplAsync(coverType, coverId, cancellationToken);

        /// <summary>Gets recent activity for an user's social graph.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the activities should be queried, or "me" for the authenticated user.</param>
        /// <param name="activityType">Determines the type of social activity to query. See also <seealso cref="TraktUserSocialActivityType" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the activity items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="filter">
        /// Optional filters for refining results.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried user activities.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserActivity" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getusersactivities">
        /// Trakt API Documentation: Users: Get social activity
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktUserActivity>> GetActivitiesAsync(string usernameOrSlug,
            TraktUserSocialActivityType activityType, TraktExtendedInfo? extendedInfo = null, TraktFilter? filter = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetActivitiesImplAsync(usernameOrSlug, activityType, extendedInfo, filter, page, limit, cancellationToken);

        /// <summary>Gets data syncs for the authenticated user across all connected apps.</summary>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried user data syncs.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserSync" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssyncs">
        /// Trakt API Documentation: Users: Get data syncs
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktUserSync>> GetSyncsAsync(uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetSyncsImplAsync(page, limit, cancellationToken);

        /// <summary>Gets data syncs for the authenticated user filtered by app type.</summary>
        /// <param name="syncType">The sync type filter. See also <seealso cref="TraktUserSyncType" />.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried user data syncs.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserSync" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssyncstype">
        /// Trakt API Documentation: Users: Get data syncs by type
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktUserSync>> GetSyncsByTypeAsync(TraktUserSyncType syncType,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetSyncsByTypeImplAsync(syncType, page, limit, cancellationToken);

        /// <summary>Gets details for a single data sync.</summary>
        /// <param name="syncId">The numeric ID of the data sync.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried user data sync.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserSync" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssyncsid">
        /// Trakt API Documentation: Users: Get data sync
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserSync>> GetSyncDetailsAsync(ulong syncId,
            CancellationToken cancellationToken = default)
            => GetSyncDetailsImplAsync(syncId, cancellationToken);

        /// <summary>Undoes a data sync for the authenticated user.</summary>
        /// <param name="syncId">The numeric ID of the data sync to undo.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />.
        /// <para>See also <seealso cref="TraktResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deleteuserssyncsid">
        /// Trakt API Documentation: Users: Undo data sync
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UndoSyncAsync(ulong syncId, CancellationToken cancellationToken = default)
            => UndoSyncImplAsync(syncId, cancellationToken);

        /// <summary>Gets paused items for a data sync.</summary>
        /// <param name="syncId">The numeric ID of the data sync.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried paused sync items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserSyncItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssyncspaused">
        /// Trakt API Documentation: Users: Get paused items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktUserSyncItem>> GetSyncPausedItemsAsync(ulong syncId,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetSyncPausedItemsImplAsync(syncId, page, limit, cancellationToken);

        /// <summary>Gets skipped items for a data sync.</summary>
        /// <param name="syncId">The numeric ID of the data sync.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried skipped sync items.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserSyncItem" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getuserssyncsskipped">
        /// Trakt API Documentation: Users: Get skipped items
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktUserSyncItem>> GetSyncSkippedItemsAsync(ulong syncId,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetSyncSkippedItemsImplAsync(syncId, page, limit, cancellationToken);

        /// <summary>Gets month in review stats for a user.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which month in review should be queried, or "me" for the authenticated user.</param>
        /// <param name="year">The 4-digit year.</param>
        /// <param name="month">The month number (1-12).</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing month in review details.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserMonthInReview" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getusersmonth_in_review">
        /// Trakt API Documentation: Users: Get month in review
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserMonthInReview>> GetMonthInReviewAsync(string usernameOrSlug, uint year, uint month,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetMonthInReviewImplAsync(usernameOrSlug, year, month, extendedInfo, cancellationToken);

        /// <summary>Gets year in review stats for a user.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which year in review should be queried, or "me" for the authenticated user.</param>
        /// <param name="year">The 4-digit year.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing year in review details.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserYearInReview" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getusersyear_in_review">
        /// Trakt API Documentation: Users: Get year in review
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserYearInReview>> GetYearInReviewAsync(string usernameOrSlug, uint year,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetYearInReviewImplAsync(usernameOrSlug, year, extendedInfo, cancellationToken);

        /// <summary>Gets comment reactions for the authenticated user.</summary>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing comment reactions.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktCommentReaction" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getusersreactionscomments">
        /// Trakt API Documentation: Users: Get comment reactions
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktCommentReaction>> GetCommentReactionsAsync(uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetCommentReactionsImplAsync(page, limit, cancellationToken);

        /// <summary>Adds a saved filter for the authenticated user.</summary>
        /// <param name="savedFilterPost">A <see cref="TraktUserSavedFilterPost" /> instance containing section, name, path, and query.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created saved filter.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserSavedFilter" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/postusersfilters">
        /// Trakt API Documentation: Users: Add saved filter
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktUserSavedFilter>> AddSavedFilterAsync(TraktUserSavedFilterPost savedFilterPost,
            CancellationToken cancellationToken = default)
            => AddSavedFilterImplAsync(savedFilterPost, cancellationToken);

        /// <summary>Deletes a saved filter for the authenticated user.</summary>
        /// <param name="filterId">The numeric ID of the saved filter to delete.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />.
        /// <para>See also <seealso cref="TraktResponse" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://docs.trakt.tv/reference/deleteusersfiltersid">
        /// Trakt API Documentation: Users: Delete saved filter
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> DeleteSavedFilterAsync(uint filterId, CancellationToken cancellationToken = default)
            => DeleteSavedFilterImplAsync(filterId, cancellationToken);
    }
}
