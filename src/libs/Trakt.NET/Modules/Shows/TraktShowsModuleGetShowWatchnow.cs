namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>Gets watch now sources for a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
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
        /// <para><see href="https://docs.trakt.tv/reference/getshowswatchnow.md">
        /// Trakt API Documentation: Shows: Watch Now - Get show watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetShowWatchnowAsync(
            string traktShowIDOrSlug, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
                => GetShowWatchnowImplAsync(traktShowIDOrSlug, country, links, extendedInfo, cancellationToken);

        /// <summary>Gets watch now sources for a <see cref="TraktShow" /> with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
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
        /// <para><see href="https://docs.trakt.tv/reference/getshowswatchnow.md">
        /// Trakt API Documentation: Shows: Watch Now - Get show watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetShowWatchnowAsync(
            uint traktShowID, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetShowWatchnowAsync(traktShowID.ToInvariantCultureString(), country, links, extendedInfo, cancellationToken);

        /// <summary>Gets watch now sources for a <see cref="TraktShow" /> with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
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
        /// <para><see href="https://docs.trakt.tv/reference/getshowswatchnow.md">
        /// Trakt API Documentation: Shows: Watch Now - Get show watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetShowWatchnowAsync(
            TraktShowIDs showIDs, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetShowWatchnowAsync(showIDs.BestID, country, links, extendedInfo, cancellationToken);
        }

        /// <summary>Gets JustWatch links for a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried JustWatch links.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowswatchnow.md">
        /// Trakt API Documentation: Shows: Watch Now - Get show JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetShowJustwatchLinksAsync(
            string traktShowIDOrSlug, string country, CancellationToken cancellationToken = default)
            => GetShowJustwatchLinksImplAsync(traktShowIDOrSlug, country, cancellationToken);

        /// <summary>Gets JustWatch links for a <see cref="TraktShow" /> with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried JustWatch links.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowswatchnow.md">
        /// Trakt API Documentation: Shows: Watch Now - Get show JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetShowJustwatchLinksAsync(
            uint traktShowID, string country, CancellationToken cancellationToken = default)
            => GetShowJustwatchLinksAsync(traktShowID.ToInvariantCultureString(), country, cancellationToken);

        /// <summary>Gets JustWatch links for a <see cref="TraktShow" /> with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="country">The 2-character country code (e.g. "us").</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried JustWatch links.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowswatchnow.md">
        /// Trakt API Documentation: Shows: Watch Now - Get show JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetShowJustwatchLinksAsync(
            TraktShowIDs showIDs, string country, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetShowJustwatchLinksAsync(showIDs.BestID, country, cancellationToken);
        }
    }
}
