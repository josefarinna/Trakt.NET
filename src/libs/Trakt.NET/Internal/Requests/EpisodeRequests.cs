namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/episodes/{episode_number:uint}", SupportsExtendedInfo = true)]
    internal sealed partial class EpisodeGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episode;
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/episodes/{episode_number:uint}/comments", SupportsExtendedInfo = true,
        SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class EpisodeCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? SortOrder { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episode;
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/episodes/{episode_number:uint}/lists", SupportsExtendedInfo = true,
        SupportsPagination = true)]
    internal sealed partial class EpisodeListsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? ListType { get; set; }

        [TraktRequestParameter]
        internal TraktListSortOrder? SortOrder { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episode;
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/episodes/{episode_number:uint}/people", SupportsExtendedInfo = true)]
    internal sealed partial class EpisodePeopleGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episode;
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/episodes/{episode_number:uint}/ratings")]
    internal sealed partial class EpisodeRatingsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episode;
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/episodes/{episode_number:uint}/stats")]
    internal sealed partial class EpisodeStatisticsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episode;
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/episodes/{episode_number:uint}/translations")]
    internal sealed partial class EpisodeTranslationsGetRequest
    {
        [TraktRequestParameter]
        internal string? Language { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episode;
    }

    [TraktGetRequest("shows/{show_id}/seasons/{season_number:uint}/episodes/{episode_number:uint}/watching", SupportsExtendedInfo = true)]
    internal sealed partial class EpisodeWatchingGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episode;
    }
}
