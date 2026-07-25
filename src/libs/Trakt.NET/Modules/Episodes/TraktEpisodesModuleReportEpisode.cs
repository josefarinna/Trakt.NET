namespace TraktNET
{
    public sealed partial class TraktEpisodesModule
    {
        /// <summary>
        /// Reports a <see cref="TraktEpisode" /> for moderator review with the specified Trakt-ID or -Slug.
        /// </summary>
        /// <param name="traktEpisodeIDOrSlug">The episode's Trakt-ID or -Slug.</param>
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
        public Task<TraktResponse> ReportEpisodeAsync(string traktEpisodeIDOrSlug, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
            => ReportEpisodeImplAsync(traktEpisodeIDOrSlug, reason, message, cancellationToken);

        /// <summary>
        /// Reports a <see cref="TraktEpisode" /> for moderator review with the specified Trakt-ID.
        /// </summary>
        /// <param name="traktEpisodeID">The episode's Trakt-ID.</param>
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
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktEpisodeID"/> is 0.</exception>
        public Task<TraktResponse> ReportEpisodeAsync(uint traktEpisodeID, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            if (traktEpisodeID == 0)
                throw new ArgumentException("episode id must not be 0", nameof(traktEpisodeID));

            return ReportEpisodeAsync(traktEpisodeID.ToInvariantCultureString(), reason, message, cancellationToken);
        }

        /// <summary>
        /// Reports a <see cref="TraktEpisode" /> for moderator review with the specified <see cref="TraktEpisodeIDs" />.
        /// </summary>
        /// <param name="episodeIDs">The episode's IDs. See also <seealso cref="TraktEpisodeIDs" />.</param>
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
        /// <exception cref="ArgumentException">Throw if the given <paramref name="episodeIDs" /> has not set any IDs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="episodeIDs" /> is null.</exception>
        public Task<TraktResponse> ReportEpisodeAsync(TraktEpisodeIDs episodeIDs, TraktReason reason, string? message = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(episodeIDs);

            if (!episodeIDs.HasAnyID)
                throw new ArgumentException($"{nameof(episodeIDs)} has not any IDs set", nameof(episodeIDs));

            return ReportEpisodeAsync(episodeIDs.BestID, reason, message, cancellationToken);
        }
    }
}
