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

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }

        [TraktRequestQuery]
        public TraktSearchField? SearchField { get; set; }
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
}
