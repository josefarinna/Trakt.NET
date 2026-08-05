namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets all <see cref="TraktSeason" /> for a specific Trakt show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the seasons.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="translationLanguageCode">
        /// An optional two letter language code to query a specific translation for the returned episodes.
        /// <para>Set this to "all" to get all available translations.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried seasons.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSeason" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasons">
        /// Trakt API Documentation: Seasons: Summary - Get all seasons for a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktSeason>> GetAllSeasonsAsync(string traktShowIDOrSlug, TraktExtendedInfo? extendedInfo = null,
             string? translationLanguageCode = null, CancellationToken cancellationToken = default)
            => GetAllSeasonsImplAsync(traktShowIDOrSlug, extendedInfo, translationLanguageCode, cancellationToken);

        /// <summary>Gets all <see cref="TraktSeason" /> for a specific Trakt show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the seasons.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="translationLanguageCode">
        /// An optional two letter language code to query a specific translation for the returned episodes.
        /// <para>Set this to "all" to get all available translations.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried seasons.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSeason" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasons">
        /// Trakt API Documentation: Seasons: Summary - Get all seasons for a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktListResponse<TraktSeason>> GetAllSeasonsAsync(uint traktShowID, TraktExtendedInfo? extendedInfo = null,
            string? translationLanguageCode = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetAllSeasonsAsync(traktShowID.ToInvariantCultureString(), extendedInfo, translationLanguageCode, cancellationToken);
        }

        /// <summary>Gets all <see cref="TraktSeason" /> for a specific Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the seasons.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="translationLanguageCode">
        /// An optional two letter language code to query a specific translation for the returned episodes.
        /// <para>Set this to "all" to get all available translations.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried seasons.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSeason" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasons">
        /// Trakt API Documentation: Seasons: Summary - Get all seasons for a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktSeason>> GetAllSeasonsAsync(TraktShowIDs showIDs, TraktExtendedInfo? extendedInfo = null,
            string? translationLanguageCode = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return GetAllSeasonsAsync(showIDs.BestID, extendedInfo, translationLanguageCode, cancellationToken);
        }

        /// <summary>Gets all <see cref="TraktSeason" /> for a specific Trakt show with the specified <see cref="TraktShow" />.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the seasons.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="translationLanguageCode">
        /// An optional two letter language code to query a specific translation for the returned episodes.
        /// <para>Set this to "all" to get all available translations.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried seasons.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSeason" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasons">
        /// Trakt API Documentation: Seasons: Summary - Get all seasons for a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktListResponse<TraktSeason>> GetAllSeasonsAsync(TraktShow show, TraktExtendedInfo? extendedInfo = null,
            string? translationLanguageCode = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetAllSeasonsAsync(show.IDs!, extendedInfo, translationLanguageCode, cancellationToken);
        }
    }
}
