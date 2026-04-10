namespace TraktNET
{
    public sealed partial class TraktPeopleModule
    {
        /// <summary>
        /// Refreshs a <see cref="TraktPerson" /> with the specified Trakt-ID or -Slug.
        /// <para>Queues a person for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="traktPersonIDOrSlug">The person's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/refresh/refresh-person-metadata">
        /// Trakt API Documentation: People: Refresh - Refresh person metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> RefreshPersonAsync(string traktPersonIDOrSlug, CancellationToken cancellationToken = default)
            => RefreshPersonImplAsync(traktPersonIDOrSlug, cancellationToken);

        /// <summary>
        /// Refreshs a <see cref="TraktMovie" /> with the specified Trakt-ID.
        /// <para>Queues a person for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="traktPersonId">The person's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/refresh/refresh-person-metadata">
        /// Trakt API Documentation: People: Refresh - Refresh person metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktPersonId"/> is 0.</exception>
        public Task<TraktResponse> RefreshPersonAsync(uint traktPersonId, CancellationToken cancellationToken = default)
        {
            if (traktPersonId == 0)
                throw new ArgumentException("traktPersonID must not be 0", nameof(traktPersonId));

            return RefreshPersonAsync(traktPersonId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>
        /// Refreshs a <see cref="TraktPerson" /> with the specified <see cref="TraktPersonIDs" />.
        /// <para>Queues a person for full metadata and image refresh, which might take up to 8 hours for the updated metadata to be available.</para>
        /// </summary>
        /// <param name="personIds">The person's id's. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para>VIP only.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/refresh/refresh-person-metadata">
        /// Trakt API Documentation: People: Refresh - Refresh person metadata
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="personIds" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="personIds" /> is null.</exception>
        public Task<TraktResponse> RefreshPersonAsync(TraktPersonIDs personIds, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(personIds);

            if (!personIds.HasAnyID)
                throw new ArgumentException($"{nameof(personIds)} has not any IDs set", nameof(personIds));

            return RefreshPersonAsync(personIds.BestID, cancellationToken);
        }
    }
}
