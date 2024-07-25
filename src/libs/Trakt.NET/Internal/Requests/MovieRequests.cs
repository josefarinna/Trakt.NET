namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("movies/{id}", SupportsExtendedInfo = true)]
    internal sealed partial class MovieGetRequest
    {
    }

    [TraktGetRequest("movies/{id}/aliases")]
    internal sealed partial class MovieAliasesGetRequest
    {
    }

    [TraktGetRequest("movies/{id}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class MovieCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? SortOrder { get; set; }
    }

    [TraktGetRequest("movies/{id}/lists", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MovieListsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? ListType { get; set; }

        [TraktRequestParameter]
        internal TraktListSortOrder? SortOrder { get; set; }
    }

    [TraktGetRequest("movies/{id}/people", SupportsExtendedInfo = true)]
    internal sealed partial class MoviePeopleGetRequest
    {
    }

    [TraktGetRequest("movies/{id}/ratings")]
    internal sealed partial class MovieRatingsGetRequest
    {
    }

    [TraktGetRequest("movies/{id}/related", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MovieRelatedMoviesGetRequest
    {
    }

    [TraktGetRequest("movies/{id}/releases")]
    internal sealed partial class MovieReleasesGetRequest
    {
        [TraktRequestParameter]
        internal string? Country { get; set; }
    }

    [TraktGetRequest("movies/{id}/stats")]
    internal sealed partial class MovieStatisticsGetRequest
    {
    }

    [TraktGetRequest("movies/{id}/studios")]
    internal sealed partial class MovieStudiosGetRequest
    {
    }

    [TraktGetRequest("movies/{id}/translations")]
    internal sealed partial class MovieTranslationsGetRequest
    {
        [TraktRequestParameter]
        internal string? Language { get; set; }
    }

    [TraktGetRequest("movies/{id}/watching", SupportsExtendedInfo = true)]
    internal sealed partial class MovieWatchingGetRequest
    {
    }

    [TraktGetRequest("movies/boxoffice", SupportsExtendedInfo = true)]
    internal sealed partial class BoxOfficeMoviesGetRequest
    {
    }

    [TraktGetRequest("movies/anticipated", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostAnticipatedMoviesGetRequest
    {
        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("movies/collected", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostCollectedMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("movies/favorited", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostFavoritedMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("movies/played", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostPlayedMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("movies/watched", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostWatchedMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("movies/popular", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class PopularMoviesGetRequest
    {
        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    [TraktGetRequest("movies/updates/id", SupportsPagination = true)]
    internal sealed partial class RecentlyUpdatedMovieIdsGetRequest
    {
        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
        internal DateTime? StartDate { get; set; }
    }

    [TraktGetRequest("movies/updates", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class RecentlyUpdatedMoviesGetRequest
    {
        [TraktRequestParameter(UseCacheEfficientDateTime = true)]
        internal DateTime? StartDate { get; set; }
    }

    [TraktGetRequest("movies/trending", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class TrendingMoviesGetRequest
    {
        // TODO: [TraktRequestQuery]
        // TODO: public ITraktFilter Filter { get; set; }
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("movies/{id}/refresh", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class MovieRefreshPostRequest
    {
    }
}
