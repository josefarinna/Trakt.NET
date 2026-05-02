namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets all episodes for a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season for which the episodes should be queried.</param>
        /// <param name="translations">The 2 digit country language code or all for all translations.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episodes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried episodes.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktEpisode" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/episodes/get-all-episodes-for-a-single-season">
        /// Trakt API Documentation: Seasons: Episodes - Get all episodes for a single season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktEpisode>> GetSeasonEpisodesAsync(string traktShowIDOrSlug, uint seasonNumber,
            string? translations = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetSeasonEpisodesImplAsync(traktShowIDOrSlug, seasonNumber, translations, extendedInfo, cancellationToken);

        /// <summary>Gets all episodes for a specific season of a Trakt show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season for which the episodes should be queried.</param>
        /// <param name="translations">The 2 digit country language code or all for all translations.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episodes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried episodes.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktEpisode" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/episodes/get-all-episodes-for-a-single-season">
        /// Trakt API Documentation: Seasons: Episodes - Get all episodes for a single season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktListResponse<TraktEpisode>> GetSeasonEpisodesAsync(uint traktShowID, uint seasonNumber,
            string? translations = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetSeasonEpisodesAsync(traktShowID.ToInvariantCultureString(), seasonNumber, translations, extendedInfo, cancellationToken);
        }

        /// <summary>Gets all episodes for a specific season of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season for which the episodes should be queried.</param>
        /// <param name="translations">The 2 digit country language code or all for all translations.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episodes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried episodes.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktEpisode" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/episodes/get-all-episodes-for-a-single-season">
        /// Trakt API Documentation: Seasons: Episodes - Get all episodes for a single season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktEpisode>> GetSeasonEpisodesAsync(TraktShowIDs showIDs, uint seasonNumber,
            string? translations = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return GetSeasonEpisodesAsync(showIDs.BestID, seasonNumber, translations, extendedInfo, cancellationToken);
        }

        /// <summary>Gets all episodes for a specific season of a Trakt show with the specified <see cref="TraktShow" />.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season for which the episodes should be queried.</param>
        /// <param name="translations">The 2 digit country language code or all for all translations.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episodes.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried episodes.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktEpisode" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/episodes/get-all-episodes-for-a-single-season">
        /// Trakt API Documentation: Seasons: Episodes - Get all episodes for a single season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktListResponse<TraktEpisode>> GetSeasonEpisodesAsync(TraktShow show, uint seasonNumber,
            string? translations = null, TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetSeasonEpisodesAsync(show.IDs!, seasonNumber, translations, extendedInfo, cancellationToken);
        }
    }
}
