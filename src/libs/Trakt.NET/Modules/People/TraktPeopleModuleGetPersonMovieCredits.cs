namespace TraktNET
{
    public sealed partial class TraktPeopleModule
    {
        /// <summary>Gets all movies where a person with the given Trakt-Id or -Slug is in the cast or crew.</summary>
        /// <param name="personIdOrSlug">The Trakt-Id or -Slug of the person, for which the movies should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried person's movie credits.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPersonMovieCredits" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/movies/get-movie-credits">
        /// Trakt API Documentation: People: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktPersonMovieCredits>> GetPersonMovieCreditsAsync(string personIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetPersonMovieCreditsImplAsync(personIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>Gets all movies where a person with the given Trakt-Id or -Slug is in the cast or crew.</summary>
        /// <param name="traktPersonId">The person's Trakt-Id. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried person's movie credits.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPersonMovieCredits" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/movies/get-movie-credits">
        /// Trakt API Documentation: People: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktPersonId"/> is 0.</exception>
        public Task<TraktResponse<TraktPersonMovieCredits>> GetPersonMovieCreditsAsync(uint traktPersonId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            if (traktPersonId == 0)
                throw new ArgumentException("person id must not be 0", nameof(traktPersonId));

            return GetPersonMovieCreditsAsync(traktPersonId.ToInvariantCultureString(), extendedInfo, cancellationToken);
        }

        /// <summary>Gets all movies where a person with the given Trakt-Id or -Slug is in the cast or crew.</summary>
        /// <param name="personIds">The person's ids. See also <seealso cref="TraktPersonIDs" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried person's movie credits.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPersonMovieCredits" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/movies/get-movie-credits">
        /// Trakt API Documentation: People: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="personIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktPersonMovieCredits>> GetPersonMovieCreditsAsync(TraktPersonIDs personIds, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(personIds);

            if (!personIds.HasAnyID)
                throw new ArgumentException($"{nameof(personIds)} has not any ids set", nameof(personIds));

            return GetPersonMovieCreditsAsync(personIds.BestID, extendedInfo, cancellationToken);
        }

        /// <summary>Gets all movies where a person with the given Trakt-Id or -Slug is in the cast or crew.</summary>
        /// <param name="person">The person. See also <seealso cref="TraktPerson" />.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried person's movie credits.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktPersonMovieCredits" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/people/movies/get-movie-credits">
        /// Trakt API Documentation: People: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="person"/> is null.</exception>
        public Task<TraktResponse<TraktPersonMovieCredits>> GetPersonMovieCreditsAsync(TraktPerson person, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(person);

            return GetPersonMovieCreditsAsync(person.IDs!, extendedInfo, cancellationToken);
        }
    }
}
