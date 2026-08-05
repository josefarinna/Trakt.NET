namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to social recommendations.
    /// <para>This module contains all methods of the "Trakt API Documentation - Social Recommendations" section.</para>
    /// </summary>
    public sealed partial class TraktSocialRecommendationsModule
    {
        /// <summary>Gets movie recommendations based on the authenticated user's social graph.</summary>
        /// <param name="watchWindow">The watch window in days for the recommendations.</param>
        /// <param name="ignoreWatched">Determines, if already watched movies should be filtered out.</param>
        /// <param name="ignoreCollected">Determines, if already collected movies should be filtered out.</param>
        /// <param name="ignoreWatchlisted">Determines, if already watchlisted movies should be filtered out.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the movies.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried recommended movies.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSocialMovieRecommendation" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsocial_recommendationsmoviesrecommend">
        /// Trakt API Documentation: Social Recommendations: Movies
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktSocialMovieRecommendation>> GetMovieRecommendationsAsync(uint? watchWindow = null,
            bool? ignoreWatched = null, bool? ignoreCollected = null, bool? ignoreWatchlisted = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetMovieRecommendationsImplAsync(watchWindow, ignoreWatched, ignoreCollected, ignoreWatchlisted, extendedInfo, page, limit, cancellationToken);

        /// <summary>Gets show recommendations based on the authenticated user's social graph.</summary>
        /// <param name="watchWindow">The watch window in days for the recommendations.</param>
        /// <param name="ignoreWatched">Determines, if already watched shows should be filtered out.</param>
        /// <param name="ignoreCollected">Determines, if already collected shows should be filtered out.</param>
        /// <param name="ignoreWatchlisted">Determines, if already watchlisted shows should be filtered out.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the shows.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried recommended shows.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSocialShowRecommendation" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/getsocial_recommendationsshowsrecommend">
        /// Trakt API Documentation: Social Recommendations: Shows
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktSocialShowRecommendation>> GetShowRecommendationsAsync(uint? watchWindow = null,
            bool? ignoreWatched = null, bool? ignoreCollected = null, bool? ignoreWatchlisted = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetShowRecommendationsImplAsync(watchWindow, ignoreWatched, ignoreCollected, ignoreWatchlisted, extendedInfo, page, limit, cancellationToken);
    }
}
