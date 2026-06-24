namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to episodes.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/episodes">"Trakt API Documentation - Episodes"</a> section.
    /// </summary>
    public sealed partial class TraktEpisodesModule
    {
        /// <summary>Gets a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, which should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, which should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episode.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisode" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">
        /// Trakt API Documentation: Episodes: Summary
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        public Task<TraktResponse<TraktEpisode>> GetEpisodeAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
            => GetEpisodeImplAsync(showIdOrSlug, seasonNumber, episodeNumber, extendedInfo, cancellationToken);

        /// <summary>Gets a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, which should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, which should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episode.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisode" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">
        /// Trakt API Documentation: Episodes: Summary
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse<TraktEpisode>> GetEpisodeAsync(uint traktShowID, uint seasonNumber, uint episodeNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetEpisodeAsync(traktShowID.ToInvariantCultureString(), seasonNumber, episodeNumber, extendedInfo, cancellationToken);
        }

        /// <summary>Gets a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, which should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, which should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episode.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisode" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">
        /// Trakt API Documentation: Episodes: Summary
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktEpisode>> GetEpisodeAsync(TraktShowIDs showIds, uint seasonNumber, uint episodeNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIds);

            if (!showIds.HasAnyID)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetEpisodeAsync(showIds.BestID, seasonNumber, episodeNumber, extendedInfo, cancellationToken);
        }

        /// <summary>Gets a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="show">The show. See also <seealso cref="TraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, which should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, which should be queried.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the episode.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisode" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">
        /// Trakt API Documentation: Episodes: Summary
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="show"/> is null.</exception>
        public Task<TraktResponse<TraktEpisode>> GetEpisodeAsync(TraktShow show, uint seasonNumber, uint episodeNumber,
            TraktExtendedInfo? extendedInfo = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetEpisodeAsync(show.IDs!, seasonNumber, episodeNumber, extendedInfo, cancellationToken);
        }
    }
}
