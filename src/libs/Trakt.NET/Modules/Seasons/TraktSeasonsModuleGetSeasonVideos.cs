namespace TraktNET
{
    public sealed partial class TraktSeasonsModule
    {
        /// <summary>Gets all videos for a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID or -Slug.</summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season for which the videos should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the people.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried season videos.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktVideo" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/videos/get-all-videos">
        /// Trakt API Documentation: Seasons: Videos - Get all videos
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktVideo>> GetSeasonVideosAsync(string traktShowIDOrSlug, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetSeasonVideosImplAsync(traktShowIDOrSlug, seasonNumber, extendedInfo, cancellationToken);

        /// <summary>Gets all videos for a specific <see cref="TraktSeason" /> of a Trakt show with the specified Trakt-ID.</summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season for which the videos should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the people.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried season videos.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktVideo" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/videos/get-all-videos">
        /// Trakt API Documentation: Seasons: Videos - Get all videos
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktListResponse<TraktVideo>> GetSeasonVideosAsync(uint traktShowID, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetSeasonVideosImplAsync(traktShowID.ToInvariantCultureString(), seasonNumber, extendedInfo, cancellationToken);

        /// <summary>Gets all videos for a specific <see cref="TraktSeason" /> of a Trakt show with the specified <see cref="TraktShowIDs" />.</summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season for which the videos should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the people.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A list response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried season videos.
        /// <para />
        /// See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktVideo" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/seasons/videos/get-all-videos">
        /// Trakt API Documentation: Seasons: Videos - Get all videos
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktListResponse<TraktVideo>> GetSeasonVideosAsync(TraktShowIDs showIDs, uint seasonNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
            {
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));
            }

            return GetSeasonVideosImplAsync(showIDs.BestID, seasonNumber, extendedInfo, cancellationToken);
        }
    }
}
