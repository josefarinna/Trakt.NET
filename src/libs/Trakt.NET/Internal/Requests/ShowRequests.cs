namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("shows/{id!!}", SupportsExtendedInfo = true)]
    internal sealed partial class ShowGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/aliases")]
    internal sealed partial class ShowAliasesGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/certifications")]
    internal sealed partial class ShowCertificationsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/progress/collection", OAuthRequirement = TraktOAuthRequirement.Required)]
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

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class ShowCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? SortOrder { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/last_episode", SupportsExtendedInfo = true)]
    internal sealed partial class ShowLastEpisodeGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/lists", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class ShowListsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? ListType { get; set; }

        [TraktRequestParameter]
        internal TraktListSortOrder? SortOrder { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/next_episode", SupportsExtendedInfo = true)]
    internal sealed partial class ShowNextEpisodeGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/people", SupportsExtendedInfo = true)]
    internal sealed partial class ShowPeopleGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/ratings")]
    internal sealed partial class ShowRatingsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/related", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class ShowRelatedShowsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/stats")]
    internal sealed partial class ShowStatisticsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/studios")]
    internal sealed partial class ShowStudiosGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/translations")]
    internal sealed partial class ShowTranslationsGetRequest
    {
        [TraktRequestParameter]
        internal string? Language { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/videos", SupportsExtendedInfo = true)]
    internal sealed partial class ShowVideosGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/progress/watched", OAuthRequirement = TraktOAuthRequirement.Required)]
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

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/watching", SupportsExtendedInfo = true)]
    internal sealed partial class ShowWatchingGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/anticipated", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostAnticipatedShowsGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("shows/collected", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostCollectedShowsGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("shows/favorited", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostFavoritedShowsGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("shows/played", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostPlayedShowsGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("shows/watched", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostWatchedShowsGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("shows/popular", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class PopularShowsGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("shows/updates/id", SupportsPagination = true)]
    internal sealed partial class RecentlyUpdatedShowIDsGetRequest
    {
        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
        internal DateTime? StartDate { get; set; }
    }

    [TraktGetRequest("shows/updates", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class RecentlyUpdatedShowsGetRequest
    {
        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
        internal DateTime? StartDate { get; set; }
    }

    [TraktGetRequest("shows/trending", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class TrendingShowsGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("shows/{id!!}/watchnow/{country!!}", SupportsExtendedInfo = true)]
    internal sealed partial class ShowWatchnowGetRequest
    {
        [TraktRequestQuery("links")]
        internal bool? Links { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktGetRequest("shows/{id!!}/watchnow/justwatch_links/{country!!}")]
    internal sealed partial class ShowJustwatchLinksGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("shows/{id!!}/refresh", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ShowRefreshPostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    [TraktPostRequest("shows/{id!!}/progress/watched/reset", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ShowResetWatchedProgressPostRequest
    {
        [TraktRequestQuery("reset_at", UseCacheEfficientDateTime = true)]
        internal DateTime? ResetAt { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("shows/{id!!}/progress/watched/reset", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class ShowUndoResetWatchedProgressDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }
}
