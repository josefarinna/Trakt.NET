namespace TraktNET
{
    public sealed partial class TraktEpisodesModule
    {
        /// <summary>Gets all translations for a <see cref="TraktEpisode" /> with the given Trakt-Id or -Slug.</summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the translations should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the translations should be queried.</param>
        /// <param name="language">An optional two letter language code to query a specific translation language.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried episode translations.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeTranslation" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodetranslations">
        /// Trakt API Documentation: Episodes: Translations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<TraktEpisodeTranslation>> GetEpisodeTranslationsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            string? language = null, CancellationToken cancellationToken = default)
            => GetEpisodeTranslationsImplAsync(showIdOrSlug, seasonNumber, episodeNumber, language, cancellationToken);

        /// <summary>Gets all translations for a <see cref="TraktEpisode" /> with the given Trakt-Id or -Slug.</summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the translations should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the translations should be queried.</param>
        /// <param name="language">An optional two letter language code to query a specific translation language.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried episode translations.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeTranslation" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodetranslations">
        /// Trakt API Documentation: Episodes: Translations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktListResponse<TraktEpisodeTranslation>> GetEpisodeTranslationsAsync(uint traktShowID, uint seasonNumber, uint episodeNumber,
            string? language = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetEpisodeTranslationsAsync(traktShowID.ToInvariantCultureString(), seasonNumber, episodeNumber, language, cancellationToken);
        }

        /// <summary>Gets all translations for a <see cref="TraktEpisode" /> with the given Trakt-Id or -Slug.</summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the translations should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the translations should be queried.</param>
        /// <param name="language">An optional two letter language code to query a specific translation language.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried episode translations.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeTranslation" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodetranslations">
        /// Trakt API Documentation: Episodes: Translations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktListResponse<TraktEpisodeTranslation>> GetEpisodeTranslationsAsync(TraktShowIDs showIds, uint seasonNumber, uint episodeNumber,
            string? language = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIds);

            if (!showIds.HasAnyID)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetEpisodeTranslationsAsync(showIds.BestID, seasonNumber, episodeNumber, language, cancellationToken);
        }

        /// <summary>Gets all translations for a <see cref="TraktEpisode" /> with the given Trakt-Id or -Slug.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the translations should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the translations should be queried.</param>
        /// <param name="language">An optional two letter language code to query a specific translation language.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried episode translations.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeTranslation" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodetranslations">
        /// Trakt API Documentation: Episodes: Translations
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktListResponse<TraktEpisodeTranslation>> GetEpisodeTranslationsAsync(TraktShow show, uint seasonNumber, uint episodeNumber,
            string? language = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetEpisodeTranslationsAsync(show.IDs!, seasonNumber, episodeNumber, language, cancellationToken);
        }
    }
}
