namespace TraktNET
{
    public sealed partial class TraktPeopleModule
    {
        /// <summary>
        /// Reports a <see cref="TraktPerson" /> for moderator review with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktPersonIDOrSlug">The person's Trakt-ID or -Slug.</param>
        /// <param name="reason">The reason for reporting the person. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postpeoplereport">
        /// Trakt API Documentation: People: Report a person
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> ReportPersonAsync(string traktPersonIDOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportPersonImplAsync(traktPersonIDOrSlug, reason, message, cancellationToken);

        /// <summary>
        /// Reports a <see cref="TraktPerson" /> for moderator review with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktPersonId">The person's Trakt-ID.</param>
        /// <param name="reason">The reason for reporting the person. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postpeoplereport">
        /// Trakt API Documentation: People: Report a person
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktPersonId"/> is 0.</exception>
        public Task<TraktResponse> ReportPersonAsync(uint traktPersonId, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktPersonId == 0)
                throw new ArgumentException("traktPersonID must not be 0", nameof(traktPersonId));

            return ReportPersonAsync(traktPersonId.ToInvariantCultureString(), reason, message, cancellationToken);
        }

        /// <summary>
        /// Reports a <see cref="TraktPerson" /> for moderator review with the specified <see cref="TraktPersonIDs" />.
        /// </summary>
        /// <param name="personIds">The person's id's. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="reason">The reason for reporting the person. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postpeoplereport">
        /// Trakt API Documentation: People: Report a person
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="personIds" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="personIds" /> is null.</exception>
        public Task<TraktResponse> ReportPersonAsync(TraktPersonIDs personIds, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(personIds);

            if (!personIds.HasAnyID)
                throw new ArgumentException($"{nameof(personIds)} has not any IDs set", nameof(personIds));

            return ReportPersonAsync(personIds.BestID, reason, message, cancellationToken);
        }
    }
}
