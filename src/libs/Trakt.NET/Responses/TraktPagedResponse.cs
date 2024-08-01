namespace TraktNET
{
    public partial class TraktPagedResponse<T> : TraktListResponse<T>, ITraktPagedResponseHeaders
    {
        public uint? PageCount => TraktHeaders?.PageCount;

        public uint? ItemCount => TraktHeaders?.ItemCount;

        public bool HasPreviousPage => Page.HasValue && PageCount.HasValue && Page.Value > 1;

        public bool HasNextPage => Page.HasValue && PageCount.HasValue && Page.Value < PageCount.Value;

        public static implicit operator bool(TraktPagedResponse<T> response) => response.IsSuccess && response.HasValue;
    }
}
