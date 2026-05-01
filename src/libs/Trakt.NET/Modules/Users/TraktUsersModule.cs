namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to users.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/users">"Trakt API Documentation - Users"</a> section.
    /// </summary>
    public sealed partial class TraktUsersModule
    {
        /// <summary>Gets the user's settings.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the user's settings.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserSettings" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/settings/retrieve-settings">
        /// Trakt API Documentation: Users: Settings
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<TraktUserSettings>> GetSettingsAsync(CancellationToken cancellationToken = default)
            => GetSettingsImplAsync(cancellationToken);

        /// <summary>Gets the user's pending follow requests.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the follow request users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried user pending follow request.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollowRequest" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/follower-requests/get-follow-requests">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried user pending following requests.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollowRequest" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/following-requests/get-pending-following-requests">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried hidden items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserHiddenItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/hidden-items/get-hidden-items">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried saved filters.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserSavedFilter" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/saved-filters/get-saved-filters">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were added and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserHiddenItemsPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/add-hidden-items/add-hidden-items">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about which items were deleted and not found.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserHiddenItemsRemovePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/remove-hidden-items/remove-hidden-items">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried like items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserLikeItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/likes/get-likes">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the user's profile information.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/profile/get-user-profile">
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing all collected movies in a user collection.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktCollectionMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/collection/get-collection">
        /// Trakt API Documentation: Users: Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktCollectionMovie>> GetCollectionMoviesAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetCollectionMoviesImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets all collected shows in an user's collection.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the collected shows should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the collected shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing all collected shows in a user collection.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktCollectionShow" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/collection/get-collection">
        /// Trakt API Documentation: Users: Collection
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktCollectionShow>> GetCollectionShowsAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetCollectionShowsImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets all comments an user has posted, sorted by most recent.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the comments should be queried.</param>
        /// <param name="type">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="objectType">Determines, for which object types comments should be queried. See also <seealso cref="TraktObjectType" />.</param>
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the commented objects.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried comments.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/comments/get-comments">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried personal lists.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/lists/get-a-user's-personal-lists">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully created personal list.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/lists/create-personal-list">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the successfully updated personal lists order.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktListItemsReorderPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/reorder-lists/reorder-a-user's-lists">
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried lists.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/collaborations/get-all-lists-a-user-can-collaborate-on">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried followers.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollower" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/followers/get-followers">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried following users.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollower" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/following/get-following">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried friend users.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUserFriend" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/friends/get-friends">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information whether the request was successful.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollowUserPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/follow/follow-this-user">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/follow/unfollow-this-user">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing information about the approved user.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserFollower" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/approve-or-deny-follower-requests/approve-follow-request">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/approve-or-deny-follower-requests/deny-follow-request">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried history items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktHistoryItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/history/get-watched-history">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried favorite items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktFavorite" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/favorites/get-favorites">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried favorites comments.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/favorites-comments/get-all-favorites-comments">
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
        /// <remarks>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the rating items.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried rating items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktRatingsItem" />.
        /// </returns>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/ratings/get-ratings">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watchlist items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktWatchlistItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/watchlist/get-watchlist">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried watchlist comments.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/watchlist-comments/get-all-watchlist-comments">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the movie or episode an user is currently watching.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserWatchingItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/watching/get-watching">
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried watched movies.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/watched/get-watched">
        /// Trakt API Documentation: Users: Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktWatchedMovie>> GetWatchedMoviesAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetWatchedMoviesImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets all shows an user has watched, sorted by most plays.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watched shows should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watched shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried watched shows.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktWatchedShow" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/watched/get-watched">
        /// Trakt API Documentation: Users: Watched
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktWatchedShow>> GetWatchedShowsAsync(string usernameOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetWatchedShowsImplAsync(usernameOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets statistics about the movies, shows and episodes an user has watched.</summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the statistics should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing statistics about movies, shows and episodes.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktUserStatistics" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/stats/get-stats">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried notes items.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktNoteItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/notes/get-notes">
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
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/users/watched/report-a-user">
        /// Trakt API Documentation: Users: Report a User
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> ReportUserAsync(string usernameOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportUserImplAsync(usernameOrSlug, reason, message, cancellationToken);
    }
}
