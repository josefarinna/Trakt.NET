namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>
        /// Reports a <see cref="TraktSeason" /> for moderator review with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktSeasonIDOrSlug">The season's Trakt-ID or -Slug.</param>
        /// <param name="reason">The reason for reporting the season. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postseasonsreport">
        /// Trakt API Documentation: Seasons: Report a season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> ReportSeasonAsync(string traktSeasonIDOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportSeasonImplAsync(traktSeasonIDOrSlug, reason, message, cancellationToken);

        /// <summary>
        /// Reports a <see cref="TraktSeason" /> for moderator review with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktSeasonID">The season's Trakt-ID.</param>
        /// <param name="reason">The reason for reporting the season. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postseasonsreport">
        /// Trakt API Documentation: Seasons: Report a season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktSeasonID"/> is 0.</exception>
        public Task<TraktResponse> ReportSeasonAsync(uint traktSeasonID, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktSeasonID == 0)
                throw new ArgumentException("season id must not be 0", nameof(traktSeasonID));

            return ReportSeasonAsync(traktSeasonID.ToInvariantCultureString(), reason, message, cancellationToken);
        }

        /// <summary>
        /// Reports a <see cref="TraktSeason" /> for moderator review with the specified <see cref="TraktSeasonIDs" />.
        /// </summary>
        /// <param name="seasonIDs">The season's IDs. See also <seealso cref="TraktSeasonIDs" />.</param>
        /// <param name="reason">The reason for reporting the season. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postseasonsreport">
        /// Trakt API Documentation: Seasons: Report a season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="seasonIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="seasonIDs" /> is null.</exception>
        public Task<TraktResponse> ReportSeasonAsync(TraktSeasonIDs seasonIDs, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(seasonIDs);

            if (!seasonIDs.HasAnyID)
                throw new ArgumentException($"{nameof(seasonIDs)} has not any IDs set", nameof(seasonIDs));

            return ReportSeasonAsync(seasonIDs.BestID, reason, message, cancellationToken);
        }
    }
}
