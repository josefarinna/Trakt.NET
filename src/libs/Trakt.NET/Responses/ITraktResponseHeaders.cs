namespace TraktNET
{
    public interface ITraktResponseHeaders
    {
        TraktSortBy? SortBy { get; }

        TraktSortHow? SortHow { get; }

        TraktSortBy? AppliedSortBy { get; }

        TraktSortHow? AppliedSortHow { get; }

        DateTime? StartDate { get; }

        DateTime? EndDate { get; }

        uint? TrendingUserCount { get; }

        uint? Page { get; }

        uint? Limit { get; }

        bool? IsPrivateUser { get; }

        uint? ItemID { get; }

        string? ItemType { get; }

        string? RateLimit { get; }

        uint? RetryAfter { get; }

        string? UpgradeURL { get; }

        bool? IsVIPUser { get; }

        uint? AccountLimit { get; }

        bool? IsAccountLocked { get; }

        bool? IsAccountDeactivated { get; }
    }
}
