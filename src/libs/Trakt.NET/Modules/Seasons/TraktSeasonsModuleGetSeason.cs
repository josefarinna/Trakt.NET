namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season which should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the season.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episodes.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSeason" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/season/get-single-seasons-for-a-show">
        /// Trakt API Documentation: Seasons: Season - Get single seasons for a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktSeason>> GetSeasonAsync(string traktShowIDOrSlug, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetSeasonImplAsync(traktShowIDOrSlug, seasonNumber, extendedInfo, cancellationToken);

        /// <summary>Gets a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season which should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the season.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried season.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSeason" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/season/get-single-seasons-for-a-show">
        /// Trakt API Documentation: Seasons: Season - Get single seasons for a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse<TraktSeason>> GetSeasonAsync(uint traktShowID, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetSeasonImplAsync(traktShowID.ToInvariantCultureString(), seasonNumber, extendedInfo, cancellationToken);

        /// <summary>Gets a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season which should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the season.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried season.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktSeason" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/season/get-single-seasons-for-a-show">
        /// Trakt API Documentation: Seasons: Season - Get single seasons for a show
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse<TraktSeason>> GetSeasonAsync(TraktShowIDs showIDs, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetSeasonImplAsync(showIDs.BestID, seasonNumber, extendedInfo, cancellationToken);
        }
    }
}
