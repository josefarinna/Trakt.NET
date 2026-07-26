namespace TraktNET
{
    public sealed partial class TraktMoviesModule
    {
        /// <summary>Gets watch now sources for a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktMovieIDOrSlug">The movie's Trakt-ID or -Slug.</param>
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
        /// <para>Note: Provided for API visibility and completeness; availability depends on Trakt.tv API backend support.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getmovieswatchnow">
        /// Trakt API Documentation: Movies: Watch Now - Get movie watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetMovieWatchnowAsync(
            string traktMovieIDOrSlug, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieWatchnowImplAsync(traktMovieIDOrSlug, country, links, extendedInfo, cancellationToken);

        /// <summary>Gets watch now sources for a <see cref="TraktMovie" /> with the specified Trakt-ID.</summary>
        /// <param name="traktMovieID">The movie's Trakt-ID.</param>
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
        /// <para>Note: Provided for API visibility and completeness; availability depends on Trakt.tv API backend support.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getmovieswatchnow">
        /// Trakt API Documentation: Movies: Watch Now - Get movie watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetMovieWatchnowAsync(
            uint traktMovieID, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieWatchnowAsync(traktMovieID.ToInvariantCultureString(), country, links, extendedInfo, cancellationToken);

        /// <summary>Gets watch now sources for a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIDs" />.</summary>
        /// <param name="movieIDs">The movie's IDs. See also <seealso cref="TraktMovieIDs" />.</param>
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
        /// <para>Note: Provided for API visibility and completeness; availability depends on Trakt.tv API backend support.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getmovieswatchnow">
        /// Trakt API Documentation: Movies: Watch Now - Get movie watch now sources
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIDs" /> is null.</exception>
        public Task<TraktResponse<Dictionary<string, TraktWatchnowSources>>> GetMovieWatchnowAsync(
            TraktMovieIDs movieIDs, string country, bool? links = null, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIDs);

            if (!movieIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIDs)} has not any IDs set", nameof(movieIDs));
            }

            return GetMovieWatchnowAsync(movieIDs.BestID, country, links, extendedInfo, cancellationToken);
        }

        /// <summary>Gets JustWatch links for a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktMovieIDOrSlug">The movie's Trakt-ID or -Slug.</param>
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
        /// <para>Note: Provided for API visibility and completeness; availability depends on Trakt.tv API backend support.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getmoviesjustwatchlink">
        /// Trakt API Documentation: Movies: Watch Now - Get movie JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetMovieJustwatchLinksAsync(
            string traktMovieIDOrSlug, string country, CancellationToken cancellationToken = default)
            => GetMovieJustwatchLinksImplAsync(traktMovieIDOrSlug, country, cancellationToken);

        /// <summary>Gets JustWatch links for a <see cref="TraktMovie" /> with the specified Trakt-ID.</summary>
        /// <param name="traktMovieID">The movie's Trakt-ID.</param>
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
        /// <para>Note: Provided for API visibility and completeness; availability depends on Trakt.tv API backend support.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getmoviesjustwatchlink">
        /// Trakt API Documentation: Movies: Watch Now - Get movie JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetMovieJustwatchLinksAsync(
            uint traktMovieID, string country, CancellationToken cancellationToken = default)
            => GetMovieJustwatchLinksAsync(traktMovieID.ToInvariantCultureString(), country, cancellationToken);

        /// <summary>Gets JustWatch links for a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIDs" />.</summary>
        /// <param name="movieIDs">The movie's IDs. See also <seealso cref="TraktMovieIDs" />.</param>
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
        /// <para>Note: Provided for API visibility and completeness; availability depends on Trakt.tv API backend support.</para>
        /// <para><see href="https://docs.trakt.tv/reference/getmoviesjustwatchlink">
        /// Trakt API Documentation: Movies: Watch Now - Get movie JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="movieIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIDs" /> is null.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetMovieJustwatchLinksAsync(
            TraktMovieIDs movieIDs, string country, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIDs);

            if (!movieIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIDs)} has not any IDs set", nameof(movieIDs));
            }

            return GetMovieJustwatchLinksAsync(movieIDs.BestID, country, cancellationToken);
        }
    }
}
