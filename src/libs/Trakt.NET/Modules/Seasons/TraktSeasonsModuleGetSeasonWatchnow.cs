namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets JustWatch links for a season of a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season.</param>
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
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasonjustwatchlink">
        /// Trakt API Documentation: Seasons: Watch Now - Get season JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetSeasonJustwatchLinksAsync(
            string traktShowIDOrSlug, uint seasonNumber, string country, CancellationToken cancellationToken = default)
            => GetSeasonJustwatchLinksImplAsync(traktShowIDOrSlug, seasonNumber, country, cancellationToken);

        /// <summary>Gets JustWatch links for a season of a <see cref="TraktShow" /> with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season.</param>
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
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasonjustwatchlink">
        /// Trakt API Documentation: Seasons: Watch Now - Get season JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetSeasonJustwatchLinksAsync(
            uint traktShowID, uint seasonNumber, string country, CancellationToken cancellationToken = default)
            => GetSeasonJustwatchLinksAsync(traktShowID.ToInvariantCultureString(), seasonNumber, country, cancellationToken);

        /// <summary>Gets JustWatch links for a season of a <see cref="TraktShow" /> with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season.</param>
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
        /// <para><see href="https://docs.trakt.tv/reference/getshowsseasonjustwatchlink">
        /// Trakt API Documentation: Seasons: Watch Now - Get season JustWatch links
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse<Dictionary<string, string>>> GetSeasonJustwatchLinksAsync(
            TraktShowIDs showIDs, uint seasonNumber, string country, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetSeasonJustwatchLinksAsync(showIDs.BestID, seasonNumber, country, cancellationToken);
        }
    }
}
