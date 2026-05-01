namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets all lists containing a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season for which the lists should be queried.</param>
        /// <param name="listType">
        /// The type of lists that should be queried. Defaults to personal lists.
        /// <para>See also <seealso cref="TraktListType" />.</para>
        /// </param>
        /// <param name="listSortOrder">
        /// The list sort order. Defaults to sorted by popularity.
        /// <para>See also <seealso cref="TraktListSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the season lists.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried season lists.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/lists/get-lists-containing-this-season">
        /// Trakt API Documentation: Seasons: Lists - Get lists containing this season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktPagedResponse<TraktList>> GetSeasonListsAsync(string traktShowIDOrSlug, uint seasonNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetSeasonListsImplAsync(traktShowIDOrSlug, seasonNumber, listType, listSortOrder, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all lists containing a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season for which the lists should be queried.</param>
        /// <param name="listType">
        /// The type of lists that should be queried. Defaults to personal lists.
        /// <para>See also <seealso cref="TraktListType" />.</para>
        /// </param>
        /// <param name="listSortOrder">
        /// The list sort order. Defaults to sorted by popularity.
        /// <para>See also <seealso cref="TraktListSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the season lists.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried season lists.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/lists/get-lists-containing-this-season">
        /// Trakt API Documentation: Seasons: Lists - Get lists containing this season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktPagedResponse<TraktList>> GetSeasonListsAsync(uint traktShowID, uint seasonNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetSeasonListsImplAsync(traktShowID.ToInvariantCultureString(), seasonNumber, listType, listSortOrder, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets all lists containing a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season for which the lists should be queried.</param>
        /// <param name="listType">
        /// The type of lists that should be queried. Defaults to personal lists.
        /// <para>See also <seealso cref="TraktListType" />.</para>
        /// </param>
        /// <param name="listSortOrder">
        /// The list sort order. Defaults to sorted by popularity.
        /// <para>See also <seealso cref="TraktListSortOrder" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the season lists.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried season lists.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/lists/get-lists-containing-this-season">
        /// Trakt API Documentation: Seasons: Lists - Get lists containing this season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktPagedResponse<TraktList>> GetSeasonListsAsync(TraktShowIDs showIDs, uint seasonNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetSeasonListsImplAsync(showIDs.BestID, seasonNumber, listType, listSortOrder, extendedInfo, page, limit, cancellationToken);
        }
    }
}
