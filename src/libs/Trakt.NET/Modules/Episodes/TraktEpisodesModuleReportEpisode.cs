namespace TraktNET
{
    public sealed partial class TraktEpisodesModule
    {
        /// <summary>
        /// Reports a <see cref="TraktEpisode" /> for moderator review with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktShowIDOrSlug">The show's Trakt-ID or -Slug.</param>
        /// <param name="seasonNumber">The number of the season.</param>
        /// <param name="episodeNumber">The number of the episode which should be reported.</param>
        /// <param name="reason">The reason for reporting the episode. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postepisodesreport">
        /// Trakt API Documentation: Episodes: Report an episode
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        public Task<TraktResponse> ReportEpisodeAsync(string traktShowIDOrSlug, uint seasonNumber, uint episodeNumber, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportEpisodeImplAsync(traktShowIDOrSlug, seasonNumber, episodeNumber, reason, message, cancellationToken);

        /// <summary>
        /// Reports a <see cref="TraktEpisode" /> for moderator review with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-ID.</param>
        /// <param name="seasonNumber">The number of the season.</param>
        /// <param name="episodeNumber">The number of the episode which should be reported.</param>
        /// <param name="reason">The reason for reporting the episode. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postepisodesreport">
        /// Trakt API Documentation: Episodes: Report an episode
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse> ReportEpisodeAsync(uint traktShowID, uint seasonNumber, uint episodeNumber, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return ReportEpisodeAsync(traktShowID.ToInvariantCultureString(), seasonNumber, episodeNumber, reason, message, cancellationToken);
        }

        /// <summary>
        /// Reports a <see cref="TraktEpisode" /> for moderator review with the specified <see cref="TraktShowIDs" />.
        /// </summary>
        /// <param name="showIDs">The show's IDs. See also <seealso cref="TraktShowIDs" />.</param>
        /// <param name="seasonNumber">The number of the season.</param>
        /// <param name="episodeNumber">The number of the episode which should be reported.</param>
        /// <param name="reason">The reason for reporting the episode. See also <seealso cref="TraktReason" />.</param>
        /// <param name="message">An optional message providing additional context for the report.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postepisodesreport">
        /// Trakt API Documentation: Episodes: Report an episode
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation (e.g. invalid id) of the request fails.</exception>
        /// <exception cref="ArgumentException">Throw if the given <paramref name="showIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="showIDs" /> is null.</exception>
        public Task<TraktResponse> ReportEpisodeAsync(TraktShowIDs showIDs, uint seasonNumber, uint episodeNumber, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIDs);

            if (!showIDs.HasAnyID)
                throw new ArgumentException($"{nameof(showIDs)} has not any IDs set", nameof(showIDs));

            return ReportEpisodeAsync(showIDs.BestID, seasonNumber, episodeNumber, reason, message, cancellationToken);
        }
    }
}
