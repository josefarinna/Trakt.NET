namespace TraktNET
{
    public sealed partial class TraktEpisodesModule
    {
        /// <summary>Gets all <see cref="TraktList" />s containing the given <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the lists should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episode lists.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried episode lists.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/lists/get-lists-containing-this-episode">
        /// Trakt API Documentation: Episodes: Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        public Task<TraktPagedResponse<TraktList>> GetEpisodeListsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetEpisodeListsImplAsync(showIdOrSlug, seasonNumber, episodeNumber, listType, listSortOrder, extendedInfo, page, limit, cancellationToken);

        /// <summary>
        /// Gets all <see cref="TraktList" />s containing the given <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the lists should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episode lists.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried episode lists.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/lists/get-lists-containing-this-episode">
        /// Trakt API Documentation: Episodes: Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktPagedResponse<TraktList>> GetEpisodeListsAsync(uint traktShowID, uint seasonNumber, uint episodeNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetEpisodeListsAsync(traktShowID.ToInvariantCultureString(), seasonNumber, episodeNumber, listType, listSortOrder,
                                        extendedInfo, page, limit, cancellationToken);
        }

        /// <summary>Gets all <see cref="TraktList" />s containing the given <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the lists should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episode lists.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried episode lists.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/lists/get-lists-containing-this-episode">
        /// Trakt API Documentation: Episodes: Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktPagedResponse<TraktList>> GetEpisodeListsAsync(TraktShowIDs showIds, uint seasonNumber, uint episodeNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIds);
            if (!showIds.HasAnyID)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetEpisodeListsAsync(showIds.BestID, seasonNumber, episodeNumber, listType, listSortOrder,
                                        extendedInfo, page, limit, cancellationToken);
        }

        /// <summary>Gets all <see cref="TraktList" />s containing the given <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the lists should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episode lists.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried episode lists.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktList" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/lists/get-lists-containing-this-episode">
        /// Trakt API Documentation: Episodes: Lists
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="show"/> is null.</exception>
        public Task<TraktPagedResponse<TraktList>> GetEpisodeListsAsync(TraktShow show, uint seasonNumber, uint episodeNumber,
            TraktListType? listType = null, TraktListSortOrder? listSortOrder = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetEpisodeListsAsync(show.IDs!, seasonNumber, episodeNumber, listType, listSortOrder,
                                        extendedInfo, page, limit, cancellationToken);
        }
    }
}
