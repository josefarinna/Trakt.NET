namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets all translations for a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season for which the translations should be queried.</param>
        /// <param name="language">An optional two-character language code to filter the translations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried season translations.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSeasonTranslation" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/translations/get-all-season-translations">
        /// Trakt API Documentation: Seasons: Translations - Get all season translations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktSeasonTranslation>> GetSeasonTranslationsAsync(string traktShowIDOrSlug, uint seasonNumber,
            string? language = null, CancellationToken cancellationToken = default)
            => GetSeasonTranslationsImplAsync(traktShowIDOrSlug, seasonNumber, language, cancellationToken);

        /// <summary>Gets all translations for a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season for which the translations should be queried.</param>
        /// <param name="language">An optional two-character language code to filter the translations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried season translations.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSeasonTranslation" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/translations/get-all-season-translations">
        /// Trakt API Documentation: Seasons: Translations - Get all season translations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktListResponse<TraktSeasonTranslation>> GetSeasonTranslationsAsync(uint traktShowID, uint seasonNumber,
            string? language = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetSeasonTranslationsAsync(traktShowID.ToInvariantCultureString(), seasonNumber, language, cancellationToken);
        }

        /// <summary>Gets all translations for a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season for which the translations should be queried.</param>
        /// <param name="language">An optional two-character language code to filter the translations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried season translations.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSeasonTranslation" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/translations/get-all-season-translations">
        /// Trakt API Documentation: Seasons: Translations - Get all season translations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktSeasonTranslation>> GetSeasonTranslationsAsync(TraktShowIDs showIDs, uint seasonNumber,
            string? language = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return GetSeasonTranslationsAsync(showIDs.BestID, seasonNumber, language, cancellationToken);
        }

        /// <summary>Gets all translations for a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season for which the translations should be queried.</param>
        /// <param name="language">An optional two-character language code to filter the translations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried season translations.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktSeasonTranslation" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/translations/get-all-season-translations">
        /// Trakt API Documentation: Seasons: Translations - Get all season translations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktListResponse<TraktSeasonTranslation>> GetSeasonTranslationsAsync(TraktShow show, uint seasonNumber,
            string? language = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetSeasonTranslationsAsync(show.IDs!, seasonNumber, language, cancellationToken);
        }
    }
}
