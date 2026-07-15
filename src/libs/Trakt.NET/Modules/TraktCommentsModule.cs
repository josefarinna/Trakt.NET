using System.Net.Http.Json;

namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to comments.<para />
    /// This module contains all methods of the <a href="https://docs.trakt.tv/reference/about-comments">"Trakt API Documentation - Comments"</a> section.
    /// </summary>
    public sealed partial class TraktCommentsModule
    {
        /// <summary>Gets a <see cref="TraktComment" /> or reply with the given id.</summary>
        /// <param name="commentId">The comment's id.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comment.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried comment's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcommentssummary">
        /// Trakt API Documentation: Comments: Comment
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktComment>> GetCommentAsync(uint commentId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetCommentImplAsync(commentId, extendedInfo, cancellationToken);

        /// <summary>Gets the attached media <see cref="TraktCommentItem" /> from a comment with the given id.</summary>
        /// <param name="commentId">The comment's id.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comment's item.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried comment's media item.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCommentItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcommentsitem">
        /// Trakt API Documentation: Comments: Item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktCommentItem>> GetCommentItemAsync(uint commentId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetCommentItemImplAsync(commentId, extendedInfo, cancellationToken);

        /// <summary>Gets likes for comment with the given id.</summary>
        /// <param name="commentId">The comment's id.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comment's likes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" />  containing the queried likes.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktCommentLike" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcommentslikes">
        /// Trakt API Documentation: Comments: Likes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktCommentLike>> GetCommentLikesAsync(uint commentId, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetCommentLikesImplAsync(commentId, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets recently updated comments.</summary>
        /// <param name="commentType">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="type">Determines, for which object types comments should be queried. See also <seealso cref="TraktCommentObjectType" />.</param>
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comment's likes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried recently updated comments.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcommentsupdates">
        /// Trakt API Documentation: Comments: Updates
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktUserComment>> GetRecentlyUpdatedCommentsAsync(TraktCommentType? commentType = null,
            TraktCommentObjectType? type = null, bool? includeReplies = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetRecentlyUpdatedCommentsImplAsync(commentType, type, includeReplies, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets recently created comments.</summary>
        /// <param name="commentType">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="type">Determines, for which object types comments should be queried. See also <seealso cref="TraktCommentObjectType" />.</param>
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comment's likes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried recently created comments.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcommentsrecent">
        /// Trakt API Documentation: Comments: Recent
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktUserComment>> GetRecentlyCreatedCommentsAsync(TraktCommentType? commentType = null,
            TraktCommentObjectType? type = null, bool? includeReplies = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetRecentlyCreatedCommentsImplAsync(commentType, type, includeReplies, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets trending comments.</summary>
        /// <param name="commentType">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="type">Determines, for which object types comments should be queried. See also <seealso cref="TraktCommentObjectType" />.</param>
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comment's likes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried trending comments.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktUserComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcommentstrending">
        /// Trakt API Documentation: Comments: Trending
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktPagedResponse<TraktUserComment>> GetTrendingCommentsAsync(TraktCommentType? commentType = null,
            TraktCommentObjectType? type = null, bool? includeReplies = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetTrendingCommentsImplAsync(commentType, type, includeReplies, extendedInfo, page, limit, cancellationToken);

        /// <summary>Posts a comment for the given <see cref="TraktMovie" />.</summary>
        /// <param name="movieCommentPost">An <see cref="TraktMovieCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the posted movie comment.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCommentPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcommentspost">
        /// Trakt API Documentation: Comments: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktCommentPostResponse>> PostMovieCommentAsync(TraktMovieCommentPost movieCommentPost,
            CancellationToken cancellationToken = default)
            => PostMovieCommentImplAsync(movieCommentPost, cancellationToken);

        /// <summary>Posts a comment for the given <see cref="TraktShow" />.</summary>
        /// <param name="showCommentPost">An <see cref="TraktShowCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the posted show comment.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCommentPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcommentspost">
        /// Trakt API Documentation: Comments: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktCommentPostResponse>> PostShowCommentAsync(TraktShowCommentPost showCommentPost,
            CancellationToken cancellationToken = default)
            => PostShowCommentImplAsync(showCommentPost, cancellationToken);

        /// <summary>Posts a comment for the given <see cref="TraktSeason" />.</summary>
        /// <param name="seasonCommentPost">An <see cref="TraktSeasonCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the posted season comment.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCommentPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcommentspost">
        /// Trakt API Documentation: Comments: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktCommentPostResponse>> PostSeasonCommentAsync(TraktSeasonCommentPost seasonCommentPost,
            CancellationToken cancellationToken = default)
            => PostSeasonCommentImplAsync(seasonCommentPost, cancellationToken);

        /// <summary>Posts a comment for the given <see cref="TraktEpisode" />.</summary>
        /// <param name="episodeCommentPost">An <see cref="TraktEpisodeCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the posted episode comment.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCommentPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcommentspost">
        /// Trakt API Documentation: Comments: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktCommentPostResponse>> PostEpisodeCommentAsync(TraktEpisodeCommentPost episodeCommentPost,
            CancellationToken cancellationToken = default)
            => PostEpisodeCommentImplAsync(episodeCommentPost, cancellationToken);

        /// <summary>Posts a comment for the given <see cref="TraktList" />.</summary>
        /// <param name="listCommentPost">An <see cref="TraktListCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the posted list comment.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCommentPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcommentspost">
        /// Trakt API Documentation: Comments: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktCommentPostResponse>> PostListCommentAsync(TraktListCommentPost listCommentPost,
            CancellationToken cancellationToken = default)
            => PostListCommentImplAsync(listCommentPost, cancellationToken);

        /// <summary>Updates a comment or reply with the given comment id, which was posted within the last hour.</summary>
        /// <param name="commentId">The id of the comment, which should be updated.</param>
        /// <param name="comment">The new comment's content. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the updated comment.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCommentPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/putcommentsedit">
        /// Trakt API Documentation: Comments: Comment
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktCommentPostResponse>> UpdateCommentAsync(uint commentId, string comment, bool? containsSpoiler = null,
            CancellationToken cancellationToken = default)
            => UpdateCommentImplAsync(commentId, comment, containsSpoiler, cancellationToken);

        /// <summary>Posts a reply to a comment with the given comment id.</summary>
        /// <param name="commentId">The id of the comment, which should be updated.</param>
        /// <param name="comment">The new comment's content. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the updated comment.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktCommentPostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcommentsreply">
        /// Trakt API Documentation: Comments: Replies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktCommentPostResponse>> PostCommentReplyAsync(uint commentId, string comment, bool? containsSpoiler = null,
            CancellationToken cancellationToken = default)
            => PostCommentReplyImplAsync(commentId, comment, containsSpoiler, cancellationToken);

        /// <summary>Deletes a comment with the given comment id.</summary>
        /// <param name="commentId">The id of the comment, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deletecommentsdelete">
        /// Trakt API Documentation: Comments: Comment
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> DeleteCommentAsync(uint commentId, CancellationToken cancellationToken = default)
            => DeleteCommentImplAsync(commentId, cancellationToken);

        /// <summary>Likes a comment with the given comment id.</summary>
        /// <param name="commentId">The id of the comment, which should be liked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcommentslike">
        /// Trakt API Documentation: Comments: Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> LikeCommentAsync(uint commentId, CancellationToken cancellationToken = default)
            => LikeCommentImplAsync(commentId, cancellationToken);

        /// <summary>Unlikes a comment with the given comment id.</summary>
        /// <param name="commentId">The id of the comment, which should be unliked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/deletecommentsunlike">
        /// Trakt API Documentation: Comments: Like
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> UnlikeCommentAsync(uint commentId, CancellationToken cancellationToken = default)
            => UnlikeCommentImplAsync(commentId, cancellationToken);

        /// <summary>Gets replies for comment with the given id.</summary>
        /// <param name="commentId">The comment's id.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comment's likes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" />  containing the queried replies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getcommentsreplies">
        /// Trakt API Documentation: Comments: Likes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetCommentRepliesAsync(uint commentId, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetCommentRepliesImplAsync(commentId, extendedInfo, page, limit, cancellationToken);

        /// <summary>Reports a comment for moderator review with the specified comment ID.</summary>
        /// <param name="commentId">The comment's id.</param>
        /// <param name="reason">The reason for reporting the comment. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postcommentsreport">
        /// Trakt API Documentation: Comments: Report a comment
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="commentId"/> is 0.</exception>
        public Task<TraktResponse> ReportCommentAsync(uint commentId, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (commentId == 0)
                throw new ArgumentException("commentId must not be 0", nameof(commentId));

            return ReportCommentImplAsync(commentId, reason, message, cancellationToken);
        }
    }
}
