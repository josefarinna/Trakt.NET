namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("search", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class SearchTextQueryGetRequest
    {
        [TraktRequestParameter]
        public TraktSearchResultType Type { get; set; }

        [TraktRequestQuery("query")]
        public required string Query { get; set; }

        [TraktRequestQuery]
        public TraktSearchField? SearchField { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }

    }

    [TraktGetRequest("search", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class SearchIDLookupGetRequest
    {
        [TraktRequestParameter]
        public TraktSearchIDType IdType { get; set; }

        [TraktRequestParameter]
        public required string LookupId { get; set; }

        [TraktRequestQuery]
        public TraktSearchResultType? ResultTypes { get; set; }
    }

    [TraktGetRequest("search", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class SearchExactTextQueryGetRequest
    {
        [TraktRequestParameter]
        public TraktSearchResultType Type { get; set; }

        [TraktRequestParameter]
        private static string Exact => "exact";

        [TraktRequestQuery("query")]
        public required string Query { get; set; }
    }

    [TraktGetRequest("search/recent_by_id/global", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class SearchTrendingGetRequest
    {
        [TraktRequestParameter]
        public TraktSearchRecentType Type { get; set; }

        [TraktRequestQuery("query")]
        public string? Query { get; set; }
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("search/recent", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SearchRecentAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktSearchRecentPost TraktSearchRecentPost { get; set; }
    }

    [TraktPostRequest("search/recent/remove", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SearchRecentRemovePostRequest
    {
        [TraktRequestPayload]
        internal required TraktSearchRecentPost TraktSearchRecentPost { get; set; }
    }
}
