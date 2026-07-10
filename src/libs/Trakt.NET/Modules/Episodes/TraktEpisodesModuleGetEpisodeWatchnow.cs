namespace TraktNET
{
    public sealed partial class TraktEpisodesModule
    {
        /// <summary>Gets watch now sources for a <see cref="TraktEpisode" /> of a show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season containing the episode.</param>
        /// <param name="episodeNumber">The number of the episode.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="links">
        /// Use to include provider links when available.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watch now sources.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried watch now sources.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktWatchnowSources" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodewatchnow">
        /// Trakt API Documentation: Episodes: Watch Now - Get episode watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetEpisodeWatchnowAsync(
            string traktShowIDOrSlug, uint seasonNumber, uint episodeNumber, string country, bool? links = null,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetEpisodeWatchnowImplAsync(traktShowIDOrSlug, seasonNumber, episodeNumber, country, links, extendedInfo, cancellationToken);

        /// <summary>Gets watch now sources for a <see cref="TraktEpisode" /> of a show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season containing the episode.</param>
        /// <param name="episodeNumber">The number of the episode.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="links">
        /// Use to include provider links when available.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watch now sources.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried watch now sources.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktWatchnowSources" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodewatchnow">
        /// Trakt API Documentation: Episodes: Watch Now - Get episode watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetEpisodeWatchnowAsync(
            uint traktShowID, uint seasonNumber, uint episodeNumber, string country, bool? links = null,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetEpisodeWatchnowAsync(traktShowID.ToInvariantCultureString(), seasonNumber, episodeNumber, country, links, extendedInfo, cancellationToken);

        /// <summary>Gets watch now sources for a <see cref="TraktEpisode" /> of a show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode.</param>
        /// <param name="episodeNumber">The number of the episode.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="links">
        /// Use to include provider links when available.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watch now sources.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried watch now sources.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktWatchnowSources" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsepisodewatchnow">
        /// Trakt API Documentation: Episodes: Watch Now - Get episode watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetEpisodeWatchnowAsync(
            TraktShowIDs showIDs, uint seasonNumber, uint episodeNumber, string country, bool? links = null,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetEpisodeWatchnowAsync(showIDs.BestID, seasonNumber, episodeNumber, country, links, extendedInfo, cancellationToken);
        }

        /// <summary>Gets watch now sources for a <see cref="TraktEpisode" /> with the specified global Trakt-ID or unique ID.</summary>
        /// <param name="traktEpisodeIDOrUniqueId">The episode's global Trakt-ID or unique ID.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="links">
        /// Use to include provider links when available.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watch now sources.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried watch now sources.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktWatchnowSources" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getepisodeswatchnow">
        /// Trakt API Documentation: Episodes: Watch Now - Get episode watch now sources by global ID
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetEpisodeByIdWatchnowAsync(
            string traktEpisodeIDOrUniqueId, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetEpisodeByIdWatchnowImplAsync(traktEpisodeIDOrUniqueId, country, links, extendedInfo, cancellationToken);

        /// <summary>Gets watch now sources for a <see cref="TraktEpisode" /> with the specified global Trakt-ID.</summary>
        /// <param name="traktEpisodeID">The episode's global Trakt-ID.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="links">
        /// Use to include provider links when available.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watch now sources.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried watch now sources.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktWatchnowSources" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getepisodeswatchnow">
        /// Trakt API Documentation: Episodes: Watch Now - Get episode watch now sources by global ID
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetEpisodeByIdWatchnowAsync(
            uint traktEpisodeID, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
                => GetEpisodeByIdWatchnowAsync(traktEpisodeID.ToInvariantCultureString(), country, links, extendedInfo, cancellationToken);

        /// <summary>Gets watch now sources for a <see cref="TraktEpisode" /> with the specified <see cref="TraktEpisodeIDs" />.</summary>
        /// <param name="episodeIDs">The episode's IDs. See also <seealso cref="TraktEpisodeIDs" />.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="links">
        /// Use to include provider links when available.
        /// </param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the watch now sources.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried watch now sources.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktWatchnowSources" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getepisodeswatchnow">
        /// Trakt API Documentation: Episodes: Watch Now - Get episode watch now sources by global ID
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="episodeIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="episodeIDs" /> is null.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetEpisodeByIdWatchnowAsync(
            TraktEpisodeIDs episodeIDs, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(episodeIDs);

            if (!episodeIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(episodeIDs)} has not any IDs set", nameof(episodeIDs));
            }

            return GetEpisodeByIdWatchnowAsync(episodeIDs.BestID, country, links, extendedInfo, cancellationToken);
        }
    }
}
