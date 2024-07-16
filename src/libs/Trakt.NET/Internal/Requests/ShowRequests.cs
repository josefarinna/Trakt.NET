namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("shows/{id}", SupportsExtendedInfo = true)]
    internal sealed partial class ShowGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/aliases")]
    internal sealed partial class ShowAliasesGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/certifications")]
    internal sealed partial class ShowCertificationsGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/progress/collection", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ShowCollectionProgressGetRequest
    {
        [TraktRequestQuery("hidden")]
        internal bool? Hidden { get; set; }

        [TraktRequestQuery("specials")]
        internal bool? Specials { get; set; }

        [TraktRequestQuery("count_specials")]
        internal bool? CountSpecials { get; set; }

        [TraktRequestQuery]
        internal TraktLastActivity? LastActivity { get; set; }
    }

    [TraktGetRequest("shows/{id}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class ShowCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? SortOrder { get; set; }
    }

    [TraktGetRequest("shows/{id}/last_episode", SupportsExtendedInfo = true)]
    internal sealed partial class ShowLastEpisodeGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/lists", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class ShowListsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? Type { get; set; }

        [TraktRequestParameter]
        internal TraktListSortOrder? SortOrder { get; set; }
    }

    [TraktGetRequest("shows/{id}/next_episode", SupportsExtendedInfo = true)]
    internal sealed partial class ShowNextEpisodeGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/people", SupportsExtendedInfo = true)]
    internal sealed partial class ShowPeopleGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/ratings")]
    internal sealed partial class ShowRatingsGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/related", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class ShowRelatedShowsGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/stats")]
    internal sealed partial class ShowStatisticsGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/studios")]
    internal sealed partial class ShowStudiosGetRequest
    {
    }

    [TraktGetRequest("shows/{id}/translations")]
    internal sealed partial class ShowTranslationsGetRequest
    {
        [TraktRequestParameter]
        internal string? Language { get; set; }
    }

    [TraktGetRequest("shows/{id}/progress/watched", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ShowWatchedProgressGetRequest
    {
        [TraktRequestQuery("hidden")]
        internal bool? Hidden { get; set; }

        [TraktRequestQuery("specials")]
        internal bool? Specials { get; set; }

        [TraktRequestQuery("count_specials")]
        internal bool? CountSpecials { get; set; }

        [TraktRequestQuery]
        internal TraktLastActivity? LastActivity { get; set; }
    }

    [TraktGetRequest("shows/{id}/watching", SupportsExtendedInfo = true)]
    internal sealed partial class ShowWatchingUsersGetRequest
    {
    }

    [TraktGetRequest("shows/anticipated", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostAnticipatedShowsGetRequest
    {
        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("shows/collected", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostCollectedShowsGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? Period { get; set; }

        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("shows/favorited", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostFavoritedShowsGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? Period { get; set; }

        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("shows/played", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostPlayedShowsGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? Period { get; set; }

        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("shows/watched", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostWatchedShowsGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? Period { get; set; }

        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("shows/popular", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class PopularShowsGetRequest
    {
        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("shows/updates", SupportsPagination = true)]
    internal sealed partial class RecentlyUpdatedShowIdsGetRequest
    {
        [TraktRequestParameter] // TODO: Cache Efficiency for DateTime
        internal DateTime? StartDate { get; set; }
    }

    [TraktGetRequest("shows/updates", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class RecentlyUpdatedShowsGetRequest
    {
        [TraktRequestParameter] // TODO: Cache Efficiency for DateTime
        internal DateTime? StartDate { get; set; }
    }

    [TraktGetRequest("shows/trending", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class TrendingShowsGetRequest
    {
        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("shows/{id}/refresh", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ShowRefreshMetadataPostRequest
    {
    }

    [TraktPostRequest("shows/{id}/progress/watched/reset", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ShowResetWatchedProgressPostRequest
    {
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("shows/{id}/progress/watched/reset", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ShowUndoResetWatchedProgressDeleteRequest
    {
    }
}
