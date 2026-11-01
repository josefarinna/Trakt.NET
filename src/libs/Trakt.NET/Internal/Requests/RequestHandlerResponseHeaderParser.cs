using System.Globalization;
using System.Net.Http.Headers;

namespace TraktNET
{
    internal static partial class RequestHandler
    {
        private static async Task<TraktResponseHeaders> ParseTraktResponseHeadersAsync(HttpResponseHeaders responseHeaders,
            CancellationToken cancellationToken = default)
        {
            var headers = new TraktResponseHeaders
            {
                Page = GetUIntHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_PAGINATION_PAGE_KEY),
                Limit = GetUIntHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_PAGINATION_LIMIT_KEY),
                PageCount = GetUIntHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_PAGINATION_PAGE_COUNT_KEY),
                ItemCount = GetUIntHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_PAGINATION_ITEM_COUNT_KEY),
                TrendingUserCount = GetUIntHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_TRENDING_USER_COUNT_KEY),
                SortBy = GetHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_SORT_BY_KEY)?.ToTraktSortBy(),
                AppliedSortBy = GetHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_APPLIED_SORT_BY)?.ToTraktSortBy(),
                SortHow = GetHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_SORT_HOW_KEY)?.ToTraktSortHow(),
                AppliedSortHow = GetHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_APPLIED_SORT_HOW)?.ToTraktSortHow(),
                StartDate = GetUtcDateTimeHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_STARTDATE_KEY),
                EndDate = GetUtcDateTimeHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_ENDDATE_KEY),
                IsPrivateUser = GetBoolHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_PRIVATE_USER_KEY),
                ItemID = GetUIntHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_ITEM_ID),
                ItemType = GetHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_ITEM_TYPE),
                RateLimit = await GetRateLimitHeaderValueAsync(responseHeaders, cancellationToken).ConfigureAwait(false),
                RetryAfter = GetUIntHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_RETRY_AFTER),
                UpgradeURL = GetHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_UPGRADE_URL),
                IsVIPUser = GetBoolHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_VIP_USER),
                AccountLimit = GetUIntHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_ACCOUNT_LIMIT),
                IsAccountLocked = GetBoolHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_ACCOUNT_LOCKED),
                IsAccountDeactivated = GetBoolHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_ACCOUNT_DEACTIVATED)
            };

            return headers;
        }

        private static string? GetHeaderValue(HttpResponseHeaders responseHeaders, string headerName)
            => responseHeaders.TryGetValues(headerName, out IEnumerable<string>? values) ? values.First() : null;

        private static uint? GetUIntHeaderValue(HttpResponseHeaders responseHeaders, string headerName)
            => uint.TryParse(GetHeaderValue(responseHeaders, headerName), out uint value) ? value : null;

        private static bool? GetBoolHeaderValue(HttpResponseHeaders responseHeaders, string headerName)
            => bool.TryParse(GetHeaderValue(responseHeaders, headerName), out bool value) ? value : null;

        private static DateTime? GetUtcDateTimeHeaderValue(HttpResponseHeaders responseHeaders, string headerName)
            => DateTime.TryParse(GetHeaderValue(responseHeaders, headerName), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime value)
                ? value.ToUniversalTime()
                : null;

        private static Task<TraktRateLimitInfo?> GetRateLimitHeaderValueAsync(HttpResponseHeaders responseHeaders, CancellationToken cancellationToken)
            => TryReadJsonAsync<TraktRateLimitInfo>(GetHeaderValue(responseHeaders, Constants.ResponseHeaders.HEADER_RATE_LIMIT), cancellationToken);
    }
}
