using System.Diagnostics;

namespace TraktNET
{
    public partial class TraktPagedResponse<TResponseContentType> : TraktListResponse<TResponseContentType>, ITraktPagedResponseHeaders
        where TResponseContentType : class
    {
        public uint? PageCount => TraktHeaders?.PageCount;

        public uint? ItemCount => TraktHeaders?.ItemCount;

        public bool HasPreviousPage => Page.HasValue && PageCount.HasValue && Page.Value > 1;

        public bool HasNextPage => Page.HasValue && PageCount.HasValue && Page.Value < PageCount.Value;

        public static implicit operator bool(TraktPagedResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;

        public Task<TraktPagedResponse<TResponseContentType>> GetPreviousPageAsync(CancellationToken cancellationToken = default)
        {
            if (HasPreviousPage)
            {
                Debug.Assert(Context != null);
                Debug.Assert(RequestBuilder != null);

                if (Page.HasValue && Page.Value > 1)
                {
                    RequestBase request = RequestBuilder!(Page.Value - 1, Limit);
                    return RequestHandler.ExecutePagedListRequestAsync<TResponseContentType>(Context!, request, RequestBuilder, cancellationToken);
                }
            }

            return Task.FromResult(this);
        }

        public Task<TraktPagedResponse<TResponseContentType>> GetNextPageAsync(CancellationToken cancellationToken = default)
        {
            if (HasNextPage)
            {
                Debug.Assert(Context != null);
                Debug.Assert(RequestBuilder != null);

                if (Page.HasValue && PageCount.HasValue && Page.Value < PageCount.Value)
                {
                    RequestBase request = RequestBuilder!(Page.Value + 1, Limit);
                    return RequestHandler.ExecutePagedListRequestAsync<TResponseContentType>(Context!, request, RequestBuilder, cancellationToken);
                }
            }

            return Task.FromResult(this);
        }
    }
}
