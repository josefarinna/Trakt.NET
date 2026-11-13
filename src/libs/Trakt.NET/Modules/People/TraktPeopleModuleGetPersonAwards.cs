namespace TraktNET
{
    public sealed partial class TraktPeopleModule
    {
        /// <summary>Gets all awards for a <see cref="TraktPerson" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="personIDOrSlug">The person's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried person awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktPersonAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getpeopleawards">
        /// Trakt API Documentation: People: Awards - Get person awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktPersonAward>> GetPersonAwardsAsync(string personIDOrSlug, CancellationToken cancellationToken = default)
            => GetPersonAwardsImplAsync(personIDOrSlug, cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktPerson" /> with the specified Trakt-ID.</summary>
        /// <param name="traktPersonID">The person's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried person awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktPersonAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getpeopleawards">
        /// Trakt API Documentation: People: Awards - Get person awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktPersonAward>> GetPersonAwardsAsync(uint traktPersonID, CancellationToken cancellationToken = default)
            => GetPersonAwardsImplAsync(traktPersonID.ToInvariantCultureString(), cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktPerson" /> with the specified <see cref="TraktPersonIDs" />.</summary>
        /// <param name="personIDs">The person's IDs. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried person awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktPersonAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getpeopleawards">
        /// Trakt API Documentation: People: Awards - Get person awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="personIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="personIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktPersonAward>> GetPersonAwardsAsync(TraktPersonIDs personIDs, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(personIDs);

            if (!personIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(personIDs)} has not any IDs set", nameof(personIDs));
            }

            return GetPersonAwardsImplAsync(personIDs.BestID, cancellationToken);
        }

        /// <summary>Gets all awards for a <see cref="TraktPerson" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="personIDOrSlug">The person's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried person awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktPersonAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getpeopleawards">
        /// Trakt API Documentation: People: Awards - Get person awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktPersonAward>> GetAwardsAsync(string personIDOrSlug, CancellationToken cancellationToken = default)
            => GetPersonAwardsAsync(personIDOrSlug, cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktPerson" /> with the specified Trakt-ID.</summary>
        /// <param name="traktPersonID">The person's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried person awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktPersonAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getpeopleawards">
        /// Trakt API Documentation: People: Awards - Get person awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktPersonAward>> GetAwardsAsync(uint traktPersonID, CancellationToken cancellationToken = default)
            => GetPersonAwardsAsync(traktPersonID, cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktPerson" /> with the specified <see cref="TraktPersonIDs" />.</summary>
        /// <param name="personIDs">The person's IDs. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried person awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktPersonAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getpeopleawards">
        /// Trakt API Documentation: People: Awards - Get person awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="personIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="personIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktPersonAward>> GetAwardsAsync(TraktPersonIDs personIDs, CancellationToken cancellationToken = default)
            => GetPersonAwardsAsync(personIDs, cancellationToken);
    }
}
