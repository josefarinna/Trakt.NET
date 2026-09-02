namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("shows/{show_id!!}/seasons", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonsAllGetRequest
    {
        [TraktRequestQuery("translations")]
        internal string? Translations { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/info", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class SeasonCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? SortOrder { get; set; }

        [TraktRequestQuery("language")]
        internal string? Language { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonEpisodesGetRequest
    {
        [TraktRequestQuery("translations")]
        internal string? Translations { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/lists", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class SeasonListsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? ListType { get; set; }

        [TraktRequestParameter]
        internal TraktListSortOrder? SortOrder { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/people", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonPeopleGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/ratings", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonRatingsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/stats")]
    internal sealed partial class SeasonStatisticsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/translations")]
    internal sealed partial class SeasonTranslationsGetRequest
    {
        [TraktRequestQuery("language")]
        internal string? Language { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/videos", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonVideosGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/watching", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonWatchingGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    [TraktGetRequest("shows/{show_id!!}/seasons/{season_number:uint}/watchnow/justwatch_links/{country!!}")]
    internal sealed partial class SeasonJustwatchLinksGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("seasons/{id!!}/report", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SeasonReportPostRequest
    {
        [TraktRequestPayload]
        internal required TraktReportPost TraktReportPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Season;
    }
}
