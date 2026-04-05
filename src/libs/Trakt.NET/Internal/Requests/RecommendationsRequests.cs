namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("recommendations/movies", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserMovieRecommendationsGetRequest
    {
        [TraktRequestQuery("ignore_collected")]
        internal bool? IgnoreCollected { get; set; }

        [TraktRequestQuery("ignore_watchlisted")]
        internal bool? IgnoreWatchlisted { get; set; }
    }

    [TraktPostRequest("recommendations/shows", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserShowRecommendationsGetRequest
    {
        [TraktRequestQuery("ignore_collected")]
        internal bool? IgnoreCollected { get; set; }

        [TraktRequestQuery("ignore_watchlisted")]
        internal bool? IgnoreWatchlisted { get; set; }
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("recommendations/movies/{id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserRecommendationHideMovieDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktDeleteRequest("recommendations/shows/{id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class UserRecommendationHideShowDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Show;
    }
}
