namespace TraktNET
{
    public sealed partial class TraktShowsModule
    {
        /// <summary>
        /// Reports a <see cref="TraktShow" /> for moderator review with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="reason">The reason for reporting the show. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postshowsreport">
        /// Trakt API Documentation: Shows: Report a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> ReportShowAsync(string traktShowIDOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportShowImplAsync(traktShowIDOrSlug, reason, message, cancellationToken);

        /// <summary>
        /// Reports a <see cref="TraktShow" /> for moderator review with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktShowId">The show's Trakt-ID.</param>
        /// <param name="reason">The reason for reporting the show. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postshowsreport">
        /// Trakt API Documentation: Shows: Report a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowId"/> is 0.</exception>
        public Task<TraktResponse> ReportShowAsync(uint traktShowId, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktShowId == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowId));

            return ReportShowAsync(traktShowId.ToInvariantCultureString(), reason, message, cancellationToken);
        }

        /// <summary>
        /// Reports a <see cref="TraktShow" /> for moderator review with the specified <see cref="TraktShowIDs" />.
        /// </summary>
        /// <param name="showIds">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="reason">The reason for reporting the show. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postshowsreport">
        /// Trakt API Documentation: Shows: Report a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIds" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIds" /> is null.</exception>
        public Task<TraktResponse> ReportShowAsync(TraktShowIDs showIds, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIds);

            if (!showIds.HasAnyID)
                throw new ArgumentException($"{nameof(showIds)} has not any IDs set", nameof(showIds));

            return ReportShowAsync(showIds.BestID, reason, message, cancellationToken);
        }
    }
}
