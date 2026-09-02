namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets all top level comments for a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season for which the comments should be queried.</param>
        /// <param name="commentSortOrder">
        /// The comment sort order. Defaults to sorted by newest first.
        /// <para>See also <seealso cref="TraktCommentSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="language">An optional 2-character language code to filter comments by.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried season comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasoncomments">
        /// Trakt API Documentation: Seasons: Comments - Get all season comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetSeasonCommentsAsync(string traktShowIDOrSlug, uint seasonNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, string? language = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetSeasonCommentsImplAsync(traktShowIDOrSlug, seasonNumber, commentSortOrder, extendedInfo, language, page, limit, cancellationToken);

        /// <summary>Gets all top level comments for a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season for which the comments should be queried.</param>
        /// <param name="commentSortOrder">
        /// The comment sort order. Defaults to sorted by newest first.
        /// <para>See also <seealso cref="TraktCommentSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="language">An optional 2-character language code to filter comments by.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried season comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasoncomments">
        /// Trakt API Documentation: Seasons: Comments - Get all season comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetSeasonCommentsAsync(uint traktShowID, uint seasonNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, string? language = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetSeasonCommentsImplAsync(traktShowID.ToInvariantCultureString(), seasonNumber, commentSortOrder, extendedInfo, language, page, limit, cancellationToken);
        }

        /// <summary>Gets all top level comments for a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season for which the comments should be queried.</param>
        /// <param name="commentSortOrder">
        /// The comment sort order. Defaults to sorted by newest first.
        /// <para>See also <seealso cref="TraktCommentSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="language">An optional 2-character language code to filter comments by.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried season comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasoncomments">
        /// Trakt API Documentation: Seasons: Comments - Get all season comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetSeasonCommentsAsync(TraktShowIDs showIDs, uint seasonNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, string? language = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return GetSeasonCommentsImplAsync(showIDs.BestID, seasonNumber, commentSortOrder, extendedInfo, language, page, limit, cancellationToken);
        }

        /// <summary>Gets all top level comments for a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShow" />.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season for which the comments should be queried.</param>
        /// <param name="commentSortOrder">
        /// The comment sort order. Defaults to sorted by newest first.
        /// <para>See also <seealso cref="TraktCommentSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="language">An optional 2-character language code to filter comments by.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried season comments.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasoncomments">
        /// Trakt API Documentation: Seasons: Comments - Get all season comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetSeasonCommentsAsync(TraktShow show, uint seasonNumber,
            TraktCommentSortOrder? commentSortOrder = null, TraktExtendedInfo? extendedInfo = null, string? language = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetSeasonCommentsAsync(show.IDs!, seasonNumber, commentSortOrder, extendedInfo, language, page, limit, cancellationToken);
        }
    }
}
