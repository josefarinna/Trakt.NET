namespace TraktNET
{
    public sealed partial class TraktEpisodesModule
    {
        /// <summary>Gets top level comments for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the comments should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried episode comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodecomments">
        /// Trakt API Documentation: Episodes: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetEpisodeCommentsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetEpisodeCommentsImplAsync(showIdOrSlug, seasonNumber, episodeNumber, commentSortOrder, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets top level comments for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the comments should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried episode comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodecomments">
        /// Trakt API Documentation: Episodes: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetEpisodeCommentsAsync(uint traktShowID, uint seasonNumber, uint episodeNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetEpisodeCommentsAsync(traktShowID.ToInvariantCultureString(), seasonNumber, episodeNumber, commentSortOrder,
                                           extendedInfo, page, limit, cancellationToken);
        }

        /// <summary>Gets top level comments for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the comments should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried episode comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodecomments">
        /// Trakt API Documentation: Episodes: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetEpisodeCommentsAsync(TraktShowIDs showIds, uint seasonNumber, uint episodeNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIds);
            if (!showIds.HasAnyID)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetEpisodeCommentsAsync(showIds.BestID, seasonNumber, episodeNumber, commentSortOrder,
                                           extendedInfo, page, limit, cancellationToken);
        }

        /// <summary>Gets top level comments for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the comments should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried episode comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodecomments">
        /// Trakt API Documentation: Episodes: Comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetEpisodeCommentsAsync(TraktShow show, uint seasonNumber, uint episodeNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetEpisodeCommentsAsync(show.IDs!, seasonNumber, episodeNumber, commentSortOrder,
                                           extendedInfo, page, limit, cancellationToken);
        }
    }
}
