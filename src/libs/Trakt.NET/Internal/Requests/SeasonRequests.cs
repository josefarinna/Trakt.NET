namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("shows/{show_id}/seasons", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonsAllGetRequest
    {
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/info", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonGetRequest
    {
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class SeasonCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? SortOrder { get; set; }
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonEpisodesGetRequest
    {
        [TraktRequestQuery("translations")]
        internal string? Translations { get; set; }
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/lists", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class SeasonListsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? ListType { get; set; }

        [TraktRequestParameter]
        internal TraktListSortOrder? SortOrder { get; set; }
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/people", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonPeopleGetRequest
    {
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/ratings")]
    internal sealed partial class SeasonRatingsGetRequest
    {
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/stats")]
    internal sealed partial class SeasonStatisticsGetRequest
    {
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/translations")]
    internal sealed partial class SeasonTranslationsGetRequest
    {
        [TraktRequestParameter]
        internal string? Language { get; set; }
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/watching", SupportsExtendedInfo = true)]
    internal sealed partial class SeasonWatchingGetRequest
    {
    }
}
