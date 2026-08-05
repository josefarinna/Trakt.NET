namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to people.
    /// <para>This module contains all methods of the "Trakt API Documentation - People" section.</para>
    /// </summary>
    public sealed partial class TraktPeopleModule
    {
        /// <summary>Gets recently updated people ids since the given <paramref name="startDate" />.</summary>
        /// <param name="startDate">The start date, after which updated people ids should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried updated people ids.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="uint" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getpeopleupdatedids">
        /// Trakt API Documentation: People: Updated Ids
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<uint>> GetRecentlyUpdatedPeopleIDsAsync(DateTime? startDate = null, uint? page = null, uint? limit = null,
            CancellationToken cancellationToken = default)
            => GetRecentlyUpdatedPeopleIDsImplAsync(startDate, page, limit, cancellationToken);

        /// <summary>Gets updated people since the given <paramref name="startDate" />.</summary>
        /// <param name="startDate">The start date, after which updated people should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the people.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the queried updated people.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// <para>See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktRecentlyUpdatedPerson" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getpeopleupdates">
        /// Trakt API Documentation: People: Updates
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TraktRecentlyUpdatedPerson>> GetRecentlyUpdatedPeopleAsync(DateTime? startDate = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetRecentlyUpdatedPeopleImplAsync(startDate, extendedInfo, page, limit, cancellationToken);
    }
}
