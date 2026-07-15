namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("lists/{id!!}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class ListCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? Sort { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktGetRequest("lists/{id!!}/items", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class ListItemsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListItemType? Type { get; set; }

        [TraktRequestParameter]
        internal TraktSortBy? SortBy { get; set; }

        [TraktRequestParameter]
        internal TraktSortHow? SortHow { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktGetRequest("lists/{id!!}/likes", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class ListLikesGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktGetRequest("lists/popular", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class ListsPopularGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? Type { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktGetRequest("lists/trending", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class ListsTrendingGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? Type { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktGetRequest("lists/{id!!}", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class SingleListGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("lists/{id!!}/like", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ListLikePostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    [TraktPostRequest("lists/{id!!}/report", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ListReportPostRequest
    {
        [TraktRequestPayload]
        internal required TraktReportPost TraktReportPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("lists/{id!!}/like", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ListUnlikeDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.List;
    }
}
