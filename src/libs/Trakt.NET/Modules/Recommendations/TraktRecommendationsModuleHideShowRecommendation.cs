namespace TraktNET
{
    public sealed partial class TraktRecommendationsModule
    {
        /// <summary>Hides a show with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.</summary>
        /// <param name="showIdOrSlug">The Trakt-Id or -Slug or an IMDB-Id of the show, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/hide-show/hide-a-show-recommendation">
        /// Trakt API Documentation - Recommendations: Shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> HideShowRecommendationAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
            => HideShowRecommendationImplAsync(showIdOrSlug, cancellationToken);

        /// <summary>Hides a show with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.</summary>
        /// <param name="traktShowId">The Trakt-Id of the show, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/hide-show/hide-a-show-recommendation">
        /// Trakt API Documentation - Recommendations: Shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowId"/> is 0.</exception>
        public Task<TraktResponse> HideShowRecommendationAsync(uint traktShowId, CancellationToken cancellationToken = default)
        {
            if (traktShowId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktShowId));

            return HideShowRecommendationAsync(traktShowId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Hides a show with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.</summary>
        /// <param name="showIds">The ids of the show, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/hide-show/hide-a-show-recommendation">
        /// Trakt API Documentation - Recommendations: Shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktResponse> HideShowRecommendationAsync(TraktShowIDs showIds, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showIds);

            if (!showIds.HasAnyID)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return HideShowRecommendationAsync(showIds.BestID, cancellationToken);
        }

        /// <summary>Hides a show with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.</summary>
        /// <param name="show">The show, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/hide-show/hide-a-show-recommendation">
        /// Trakt API Documentation - Recommendations: Shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktResponse> HideShowRecommendationAsync(TraktShow show, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            return HideShowRecommendationAsync(show.IDs!, cancellationToken);
        }
    }
}
