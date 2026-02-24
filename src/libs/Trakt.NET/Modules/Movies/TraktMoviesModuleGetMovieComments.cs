namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>Gets all top level comments for a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktMovieIDOrSlug">The movie's Trakt-ID or -Slug.</param>
        /// <param name="commentSortOrder">
        /// The comment sort order. Defaults to sorted by newest first.
        /// <para>See also <seealso cref="TraktCommentSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
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
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/comments/get-all-movie-comments">
        /// Trakt API Documentation: Movies: Comments - Get all movie comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetMovieCommentsAsync(string traktMovieIDOrSlug, TraktCommentSortOrder? commentSortOrder = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetMovieCommentsImplAsync(traktMovieIDOrSlug, commentSortOrder, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all top level comments for a <see cref="TraktMovie" /> with the specified Trakt-ID.</summary>
        /// <param name="traktMovieID">The movie's Trakt-ID.</param>
        /// <param name="commentSortOrder">
        /// The comment sort order. Defaults to sorted by newest first.
        /// <para>See also <seealso cref="TraktCommentSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
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
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/comments/get-all-movie-comments">
        /// Trakt API Documentation: Movies: Comments - Get all movie comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetMovieCommentsAsync(uint traktMovieID, TraktCommentSortOrder? commentSortOrder = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetMovieCommentsImplAsync(traktMovieID.ToInvariantCultureString(), commentSortOrder, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all top level comments for a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIDs" />.</summary>
        /// <param name="movieIDs">The movie's IDs. See also <seealso cref="TraktMovieIDs" />.</param>
        /// <param name="commentSortOrder">
        /// The comment sort order. Defaults to sorted by newest first.
        /// <para>See also <seealso cref="TraktCommentSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the comments.
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
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktComment" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is optional.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/movies/comments/get-all-movie-comments">
        /// Trakt API Documentation: Movies: Comments - Get all movie comments
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIDs" /> is null.</exception>
        public Task<TraktPagedResponse<TraktComment>> GetMovieCommentsAsync(TraktMovieIDs movieIDs, TraktCommentSortOrder? commentSortOrder = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIDs);

            if (!movieIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIDs)} has not any IDs set", nameof(movieIDs));
            }

            return GetMovieCommentsImplAsync(movieIDs.BestID, commentSortOrder, extendedInfo, page, limit, cancellationToken);
        }
    }
}
