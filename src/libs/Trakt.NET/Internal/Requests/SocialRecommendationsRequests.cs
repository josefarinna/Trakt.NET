namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("social_recommendations/movies", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SocialMovieRecommendationsGetRequest
    {
        [TraktRequestQuery("watch_window")]
        internal uint? WatchWindow { get; set; }

        [TraktRequestQuery("ignore_watched")]
        internal bool? IgnoreWatched { get; set; }

        [TraktRequestQuery("ignore_collected")]
        internal bool? IgnoreCollected { get; set; }

        [TraktRequestQuery("ignore_watchlisted")]
        internal bool? IgnoreWatchlisted { get; set; }
    }

    [TraktGetRequest("social_recommendations/shows", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class SocialShowRecommendationsGetRequest
    {
        [TraktRequestQuery("watch_window")]
        internal uint? WatchWindow { get; set; }

        [TraktRequestQuery("ignore_watched")]
        internal bool? IgnoreWatched { get; set; }

        [TraktRequestQuery("ignore_collected")]
        internal bool? IgnoreCollected { get; set; }

        [TraktRequestQuery("ignore_watchlisted")]
        internal bool? IgnoreWatchlisted { get; set; }
    }
}
