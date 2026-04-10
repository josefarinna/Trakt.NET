namespace TraktNET
{
    public sealed partial class TraktPeopleModule
    {
        /// <summary>Gets a <see cref="TraktPerson" /> with the given Trakt-Id or -Slug.</summary>
        /// <param name="personIdOrSlug">The person's Trakt-Id or -Slug. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the person.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried person's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPerson" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/summary/get-a-single-person">
        /// Trakt API Documentation - People: Summary
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktPerson>> GetPersonAsync(string personIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetPersonImplAsync(personIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets a <see cref="TraktPerson" /> with the given Trakt-Id or -Slug.</summary>
        /// <param name="traktPersonId">The person's Trakt-Id. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the person.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried person's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPerson" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/summary/get-a-single-person">
        /// Trakt API Documentation - People: Summary
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktPersonId"/> is 0.</exception>
        public Task<TraktResponse<TraktPerson>> GetPersonAsync(uint traktPersonId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            if (traktPersonId == 0)
                throw new ArgumentException("person id must not be 0", nameof(traktPersonId));

            return GetPersonImplAsync(traktPersonId.ToInvariantCultureString(), extendedInfo, cancellationToken);
        }

        /// <summary>Gets a <see cref="TraktPerson" /> with the given Trakt-Id or -Slug.</summary>
        /// <param name="personIds">The person's ids. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the person.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried person's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPerson" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/summary/get-a-single-person">
        /// Trakt API Documentation - People: Summary
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="personIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktPerson>> GetPersonAsync(TraktPersonIDs personIds, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(personIds);

            if (!personIds.HasAnyID)
                throw new ArgumentException($"{nameof(personIds)} has not any ids set", nameof(personIds));

            return GetPersonImplAsync(personIds.BestID, extendedInfo, cancellationToken);
        }
    }
}
