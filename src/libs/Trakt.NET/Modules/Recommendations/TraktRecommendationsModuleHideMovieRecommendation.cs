namespace TraktNET
{
    public sealed partial class TraktRecommendationsModule
    {
        /// <summary>Hides a movie with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.</summary>
        /// <param name="movieIdOrSlug">The Trakt-Id or -Slug or an IMDB-Id of the movie, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/hide-movie/hide-a-movie-recommendation">
        /// Trakt API Documentation: Recommendations: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> HideMovieRecommendationAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
            => HideMovieRecommendationImplAsync(movieIdOrSlug, cancellationToken);

        /// <summary>Hides a movie with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.</summary>
        /// <param name="traktMovieId">The Trakt-Id of the movie, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/hide-movie/hide-a-movie-recommendation">
        /// Trakt API Documentation: Recommendations: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktResponse> HideMovieRecommendationAsync(uint traktMovieId, CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return HideMovieRecommendationAsync(traktMovieId.ToInvariantCultureString(), cancellationToken);
        }

        /// <summary>Hides a movie with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.</summary>
        /// <param name="movieIds">The ids of the movie, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/hide-movie/hide-a-movie-recommendation">
        /// Trakt API Documentation: Recommendations: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="movieIds"/> has not any ids set.</exception>
        public Task<TraktResponse> HideMovieRecommendationAsync(TraktMovieIDs movieIds, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieIds);

            if (!movieIds.HasAnyID)
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));

            return HideMovieRecommendationAsync(movieIds.BestID, cancellationToken);
        }

        /// <summary>Hides a movie with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.</summary>
        /// <param name="movie">The movie, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/hide-movie/hide-a-movie-recommendation">
        /// Trakt API Documentation: Recommendations: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        public Task<TraktResponse> HideMovieRecommendationAsync(TraktMovie movie, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movie);

            return HideMovieRecommendationAsync(movie.IDs!, cancellationToken);
        }
    }
}
