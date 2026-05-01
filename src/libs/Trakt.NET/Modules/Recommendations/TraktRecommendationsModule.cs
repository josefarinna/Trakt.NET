namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to recommendations.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/recommendations">"Trakt API Documentation - Recommendations"</a> section.
    /// </summary>
    public sealed partial class TraktRecommendationsModule
    {
        /// <summary>Gets personalized movie recommendations for an user.</summary>
        /// <param name="ignoreCollected">Determines, if already collected movies should be filtered out.</param>
        /// <param name="ignoreWatchlisted">Determines, if already watchlisted movies should be filtered out.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried recommended movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktRecommendedMovie" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/recommendations/movies/get-movie-recommendations">
        /// Trakt API Documentation: Recommendations: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktRecommendedMovie>> GetMovieRecommendationsAsync(bool? ignoreCollected = null, bool? ignoreWatchlisted = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetMovieRecommendationsImplAsync(ignoreCollected, ignoreWatchlisted, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets personalized show recommendations for an user.</summary>
        /// <param name="ignoreCollected">Determines, if already collected movies should be filtered out.</param>
        /// <param name="ignoreWatchlisted">Determines, if already watchlisted movies should be filtered out.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried recommended movies.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktRecommendedShow" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="http://trakt.docs.apiary.io/#reference/recommendations/shows/get-show-recommendations">
        /// Trakt API Documentation: Recommendations: Shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktRecommendedShow>> GetShowRecommendationsAsync(bool? ignoreCollected = null, bool? ignoreWatchlisted = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetShowRecommendationsImplAsync(ignoreCollected, ignoreWatchlisted, extendedInfo, page, limit, cancellationToken);
    }
}
