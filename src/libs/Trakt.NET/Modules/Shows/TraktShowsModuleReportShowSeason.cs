namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>
        /// Reports a <see cref="TraktSeason" /> for moderator review with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season which should be reported.</param>
        /// <param name="reason">The reason for reporting the season. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postshowsseasonreport">
        /// Trakt API Documentation: Shows: Report a season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> ReportShowSeasonAsync(string traktShowIDOrSlug, uint seasonNumber, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportShowSeasonImplAsync(traktShowIDOrSlug, seasonNumber, reason, message, cancellationToken);

        /// <summary>
        /// Reports a <see cref="TraktSeason" /> for moderator review with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season which should be reported.</param>
        /// <param name="reason">The reason for reporting the season. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postshowsseasonreport">
        /// Trakt API Documentation: Shows: Report a season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse> ReportShowSeasonAsync(uint traktShowID, uint seasonNumber, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return ReportShowSeasonAsync(traktShowID.ToInvariantCultureString(), seasonNumber, reason, message, cancellationToken);
        }

        /// <summary>
        /// Reports a <see cref="TraktSeason" /> for moderator review with the specified <see cref="TraktShowIDs" />.
        /// </summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season which should be reported.</param>
        /// <param name="reason">The reason for reporting the season. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postshowsseasonreport">
        /// Trakt API Documentation: Shows: Report a season
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse> ReportShowSeasonAsync(TraktShowIDs showIDs, uint seasonNumber, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return ReportShowSeasonAsync(showIDs.BestID, seasonNumber, reason, message, cancellationToken);
        }
    }
}
