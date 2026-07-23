namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("media/trending", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MediaTrendingGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("media/anticipated", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MediaAnticipatedGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("media/popular", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MediaPopularGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }
}
