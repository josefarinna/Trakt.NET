namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("people/updates/id", SupportsPagination = true)]
    internal sealed partial class PeopleRecentlyUpdatedIDsGetRequest
    {
        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
        internal DateTime? StartDate { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Person;
    }

    [TraktGetRequest("people/updates", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class PeopleRecentlyUpdatedGetRequest
    {
        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
        internal DateTime? StartDate { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Person;
    }

    [TraktGetRequest("people/{id!!}/lists", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class PersonListsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? Type { get; set; }

        [TraktRequestParameter]
        internal TraktListSortOrder? SortOrder { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Person;
    }

    [TraktGetRequest("people/{id!!}/movies", SupportsExtendedInfo = true)]
    internal sealed partial class PersonMovieCreditsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Person;
    }

    [TraktGetRequest("people/{id!!}/shows", SupportsExtendedInfo = true)]
    internal sealed partial class PersonShowCreditsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Person;
    }

    [TraktGetRequest("people/{id!!}", SupportsExtendedInfo = true)]
    internal sealed partial class PersonSummaryGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Person;
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("people/{id!!}/refresh", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class PersonRefreshPostRequest
    {
        [TraktRequestQuery("images")]
        internal bool? Images { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Person;
    }

    [TraktPostRequest("people/{id!!}/report", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class PersonReportPostRequest
    {
        [TraktRequestPayload]
        internal required TraktReportPost TraktReportPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Person;
    }
}
