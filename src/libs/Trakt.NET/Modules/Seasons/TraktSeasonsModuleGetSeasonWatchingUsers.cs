namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets all users watching a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried users.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasonwatching">
        /// Trakt API Documentation: Seasons: Watching - Get users watching right now
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktUser>> GetSeasonWatchingUsersAsync(string traktShowIDOrSlug, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetSeasonWatchingUsersImplAsync(traktShowIDOrSlug, seasonNumber, extendedInfo, cancellationToken);

        /// <summary>Gets all users watching a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried users.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasonwatching">
        /// Trakt API Documentation: Seasons: Watching - Get users watching right now
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktListResponse<TraktUser>> GetSeasonWatchingUsersAsync(uint traktShowID, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetSeasonWatchingUsersAsync(traktShowID.ToInvariantCultureString(), seasonNumber, extendedInfo, cancellationToken);
        }

        /// <summary>Gets all users watching a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried users.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasonwatching">
        /// Trakt API Documentation: Seasons: Watching - Get users watching right now
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktUser>> GetSeasonWatchingUsersAsync(TraktShowIDs showIDs, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return GetSeasonWatchingUsersAsync(showIDs.BestID, seasonNumber, extendedInfo, cancellationToken);
        }

        /// <summary>Gets all users watching a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the users.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried users.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUser" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasonwatching">
        /// Trakt API Documentation: Seasons: Watching - Get users watching right now
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktListResponse<TraktUser>> GetSeasonWatchingUsersAsync(TraktShow show, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetSeasonWatchingUsersAsync(show.IDs!, seasonNumber, extendedInfo, cancellationToken);
        }
    }
}
