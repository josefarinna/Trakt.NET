namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("smart-lists/{id!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class SmartListGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktGetRequest("smart-lists/{list_id!!}/items",
        SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.OptionalButMightBeRequired)]
    internal sealed partial class SmartListItemsGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }

        [TraktRequestQuery("watchnow")]
        internal string? Watchnow { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }
}
