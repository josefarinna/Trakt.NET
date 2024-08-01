#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

using System.Net;
using System.Net.Http.Headers;

namespace TraktNET
{
    public partial class TraktResponse : ITraktResponseHeaders
    {
        public TraktResponseHeaders? TraktHeaders { get; internal set; }

        public HttpResponseHeaders? Headers { get; internal set; }

        public HttpStatusCode StatusCode { get; internal set; }

#if NET6_0_OR_GREATER
        [MemberNotNullWhen(true, nameof(TraktHeaders))]
        [MemberNotNullWhen(true, nameof(Headers))]
#endif
        public bool IsSuccess => (int)StatusCode >= 200 && (int)StatusCode <= 299;

        public TraktSortBy? SortBy => TraktHeaders?.SortBy;

        public TraktSortHow? SortHow => TraktHeaders?.SortHow;

        public TraktSortBy? AppliedSortBy => TraktHeaders?.AppliedSortBy;

        public TraktSortHow? AppliedSortHow => TraktHeaders?.AppliedSortHow;

        public DateTime? StartDate => TraktHeaders?.StartDate;

        public DateTime? EndDate => TraktHeaders?.EndDate;

        public uint? TrendingUserCount => TraktHeaders?.TrendingUserCount;

        public uint? Page => TraktHeaders?.Page;

        public uint? Limit => TraktHeaders?.Limit;

        public bool? IsPrivateUser => TraktHeaders?.IsPrivateUser;

        public uint? ItemID => TraktHeaders?.ItemID;

        public string? ItemType => TraktHeaders?.ItemType;

        public string? RateLimit => TraktHeaders?.RateLimit;

        public uint? RetryAfter => TraktHeaders?.RetryAfter;

        public string? UpgradeURL => TraktHeaders?.UpgradeURL;

        public bool? IsVIPUser => TraktHeaders?.IsVIPUser;

        public uint? AccountLimit => TraktHeaders?.AccountLimit;

        public static implicit operator bool(TraktResponse response) => response.IsSuccess;
    }

    public partial class TraktResponse<T> : TraktResponse
    {
#if NET6_0_OR_GREATER
        [MemberNotNullWhen(true, nameof(Content))]
        [MemberNotNullWhen(true, nameof(ContentHeaders))]
#endif
        public bool HasValue => Content != null;

        public T? Content { get; internal set; }

        public HttpContentHeaders? ContentHeaders { get; internal set; }

        public static implicit operator bool(TraktResponse<T> response) => response.IsSuccess && response.HasValue;
    }
}
