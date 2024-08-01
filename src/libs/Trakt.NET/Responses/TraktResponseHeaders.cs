namespace TraktNET
{
    public sealed class TraktResponseHeaders : ITraktResponseHeaders, ITraktPagedResponseHeaders
    {
        public TraktSortBy? SortBy { get; internal set; }

        public TraktSortHow? SortHow { get; internal set; }

        public TraktSortBy? AppliedSortBy { get; internal set; }

        public TraktSortHow? AppliedSortHow { get; internal set; }

        public DateTime? StartDate { get; internal set; }

        public DateTime? EndDate { get; internal set; }

        public uint? TrendingUserCount { get; internal set; }

        public uint? Page { get; internal set; }

        public uint? Limit { get; internal set; }

        public uint? PageCount { get; internal set; }

        public uint? ItemCount { get; internal set; }

        public bool? IsPrivateUser { get; internal set; }

        public uint? ItemID { get; internal set; }

        public string? ItemType { get; internal set; }

        public string? RateLimit { get; internal set; }

        public uint? RetryAfter { get; internal set; }

        public string? UpgradeURL { get; internal set; }

        public bool? IsVIPUser { get; internal set; }

        public uint? AccountLimit { get; internal set; }

        public bool? IsAccountLocked { get; internal set; }

        public bool? IsAccountDeactivated { get; internal set; }
    }
}
