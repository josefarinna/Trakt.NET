namespace TraktNET
{
    /// <summary>A Trakt paged list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public partial class TraktPagedResponse<TResponseContentType> : TraktListResponse<TResponseContentType>, ITraktPagedResponseHeaders
    {
        private const string MISSING_REQUEST_CONTEXT_MESSAGE = "paged response has no request context to retrieve another page";

        /// <summary>The Trakt "X-Pagination-Page-Count" header.</summary>
        public uint? PageCount => TraktHeaders?.PageCount;

        /// <summary>The Trakt "X-Pagination-Item-Count" header.</summary>
        public uint? ItemCount => TraktHeaders?.ItemCount;

        /// <summary>Returns whether the response can retrieve the previous page.</summary>
        public bool HasPreviousPage => Page.HasValue && PageCount.HasValue && Page.Value > 1;

        /// <summary>Returns whether the response can retrieve the next page.</summary>
        public bool HasNextPage => Page.HasValue && PageCount.HasValue && Page.Value < PageCount.Value;

        /// <summary>Implicit conversion to bool for this response.</summary>
        /// <param name="response">The <see cref="TraktPagedResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktPagedResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;

        /// <summary>
        /// Gets the previous retrievable page for this response, if <see cref="HasPreviousPage" /> is true.
        /// <para>
        /// If this response is already the first page response or if there are no more previous pages to retrieve,
        /// this response instance will be returned.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the items of the previous page.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// </returns>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown if this response was not created by a request and therefore cannot retrieve another page.</exception>
        public Task<TraktPagedResponse<TResponseContentType>> GetPreviousPageAsync(CancellationToken cancellationToken = default)
            => HasPreviousPage ? GetPageAsync(Page.GetValueOrDefault() - 1, cancellationToken) : Task.FromResult(this);

        /// <summary>
        /// Gets the next retrievable page for this response, if <see cref="HasNextPage" /> is true.
        /// <para>
        /// If this response is already the last page response or if there are no more next pages to retrieve,
        /// this response instance will be returned.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the items of the next page.
        /// <para>The response also contains information about the queried page number, the page's item count, maximum page count</para>
        /// and maximum item count.
        /// </returns>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown if this response was not created by a request and therefore cannot retrieve another page.</exception>
        public Task<TraktPagedResponse<TResponseContentType>> GetNextPageAsync(CancellationToken cancellationToken = default)
            => HasNextPage ? GetPageAsync(Page.GetValueOrDefault() + 1, cancellationToken) : Task.FromResult(this);

        private Task<TraktPagedResponse<TResponseContentType>> GetPageAsync(uint page, CancellationToken cancellationToken)
        {
            if (Context is not TraktContext context || RequestBuilder is not Func<uint?, uint?, RequestBase> requestBuilder)
                throw new InvalidOperationException(MISSING_REQUEST_CONTEXT_MESSAGE);

            RequestBase request = requestBuilder(page, Limit);
            return RequestHandler.ExecutePagedListRequestAsync<TResponseContentType>(context, request, requestBuilder, cancellationToken);
        }
    }
}
