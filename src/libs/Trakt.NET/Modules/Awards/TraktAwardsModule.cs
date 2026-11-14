namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to awards.
    /// <para>This module contains all methods of the "Trakt API Documentation - Awards" section.</para>
    /// </summary>
    public sealed partial class TraktAwardsModule
    {
        /// <summary>Gets the award catalog containing all awards grouped by ceremony.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the award catalog ceremonies.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktAwardCatalogCeremony" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getawardscatalog">
        /// Trakt API Documentation: Awards: Catalog - Get the award catalog
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktAwardCatalogCeremony>> GetAwardCatalogAsync(CancellationToken cancellationToken = default)
            => GetAwardCatalogImplAsync(cancellationToken);

        /// <summary>Gets the award catalog containing all awards grouped by ceremony.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the award catalog ceremonies.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktAwardCatalogCeremony" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getawardscatalog">
        /// Trakt API Documentation: Awards: Catalog - Get the award catalog
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktAwardCatalogCeremony>> GetCatalogAsync(CancellationToken cancellationToken = default)
            => GetAwardCatalogAsync(cancellationToken);

        /// <summary>Gets upcoming award ceremonies that are currently open for voting or have scheduled dates.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried upcoming ceremonies.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUpcomingCeremony" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getawardsceremonies">
        /// Trakt API Documentation: Awards: Ceremonies - Get upcoming award ceremonies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktUpcomingCeremony>> GetCeremoniesAsync(CancellationToken cancellationToken = default)
            => GetCeremoniesImplAsync(cancellationToken);

        /// <summary>Gets upcoming award ceremonies that are currently open for voting or have scheduled dates.</summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried upcoming ceremonies.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktUpcomingCeremony" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getawardsceremonies">
        /// Trakt API Documentation: Awards: Ceremonies - Get upcoming award ceremonies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktUpcomingCeremony>> GetUpcomingCeremoniesAsync(CancellationToken cancellationToken = default)
            => GetCeremoniesAsync(cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktMovie" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktMovieIDOrSlug">The movie's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried movie awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktTitleAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getmoviesawards">
        /// Trakt API Documentation: Movies: Awards - Get movie awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktTitleAward>> GetMovieAwardsAsync(string traktMovieIDOrSlug, CancellationToken cancellationToken = default)
            => GetMovieAwardsImplAsync(traktMovieIDOrSlug, cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktMovie" /> with the specified Trakt-ID.</summary>
        /// <param name="traktMovieID">The movie's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried movie awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktTitleAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getmoviesawards">
        /// Trakt API Documentation: Movies: Awards - Get movie awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktTitleAward>> GetMovieAwardsAsync(uint traktMovieID, CancellationToken cancellationToken = default)
            => GetMovieAwardsImplAsync(traktMovieID.ToInvariantCultureString(), cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktMovie" /> with the specified <see cref="TraktMovieIDs" />.</summary>
        /// <param name="movieIDs">The movie's IDs. See also <seealso cref="TraktMovieIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried movie awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktTitleAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getmoviesawards">
        /// Trakt API Documentation: Movies: Awards - Get movie awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="movieIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="movieIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktTitleAward>> GetMovieAwardsAsync(TraktMovieIDs movieIDs, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIDs);

            if (!movieIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieIDs)} has not any IDs set", nameof(movieIDs));
            }

            return GetMovieAwardsImplAsync(movieIDs.BestID, cancellationToken);
        }

        /// <summary>Gets all awards for a <see cref="TraktShow" /> with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried show awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktTitleAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsawards">
        /// Trakt API Documentation: Shows: Awards - Get show awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktTitleAward>> GetShowAwardsAsync(string traktShowIDOrSlug, CancellationToken cancellationToken = default)
            => GetShowAwardsImplAsync(traktShowIDOrSlug, cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktShow" /> with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried show awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktTitleAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsawards">
        /// Trakt API Documentation: Shows: Awards - Get show awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktTitleAward>> GetShowAwardsAsync(uint traktShowID, CancellationToken cancellationToken = default)
            => GetShowAwardsImplAsync(traktShowID.ToInvariantCultureString(), cancellationToken);

        /// <summary>Gets all awards for a <see cref="TraktShow" /> with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried show awards.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktTitleAward" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getshowsawards">
        /// Trakt API Documentation: Shows: Awards - Get show awards
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktTitleAward>> GetShowAwardsAsync(TraktShowIDs showIDs, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetShowAwardsImplAsync(showIDs.BestID, cancellationToken);
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
    }
}
