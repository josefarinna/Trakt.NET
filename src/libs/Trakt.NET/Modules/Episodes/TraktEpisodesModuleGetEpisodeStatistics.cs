namespace TraktNET
{
    public sealed partial class TraktEpisodesModule
    {
        /// <summary>Gets the statistics for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the statistics should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the statistics should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode statistics.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeStatistics" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/stats/get-episode-stats">
        /// Trakt API Documentation: Episodes: Stats
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktEpisodeStatistics>> GetEpisodeStatisticsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
            CancellationToken cancellationToken = default)
            => GetEpisodeStatisticsImplAsync(showIdOrSlug, seasonNumber, episodeNumber, cancellationToken);

        /// <summary>Gets the statistics for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the statistics should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the statistics should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode statistics.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeStatistics" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/stats/get-episode-stats">
        /// Trakt API Documentation: Episodes: Stats
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse<TraktEpisodeStatistics>> GetEpisodeStatisticsAsync(uint traktShowID, uint seasonNumber, uint episodeNumber,
            CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetEpisodeStatisticsAsync(traktShowID.ToInvariantCultureString(), seasonNumber, episodeNumber, cancellationToken);
        }

        /// <summary>Gets the statistics for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the statistics should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the statistics should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode statistics.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeStatistics" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/stats/get-episode-stats">
        /// Trakt API Documentation: Episodes: Stats
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktResponse<TraktEpisodeStatistics>> GetEpisodeStatisticsAsync(TraktShowIDs showIds, uint seasonNumber, uint episodeNumber,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIds);

            if (!showIds.HasAnyID)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetEpisodeStatisticsAsync(showIds.BestID, seasonNumber, episodeNumber, cancellationToken);
        }

        /// <summary>Gets the statistics for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.</summary>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the statistics should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the statistics should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried episode statistics.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeStatistics" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/episodes/stats/get-episode-stats">
        /// Trakt API Documentation: Episodes: Stats
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktResponse<TraktEpisodeStatistics>> GetEpisodeStatisticsAsync(TraktShow show, uint seasonNumber, uint episodeNumber,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return GetEpisodeStatisticsAsync(show.IDs!, seasonNumber, episodeNumber, cancellationToken);
        }
    }
}
