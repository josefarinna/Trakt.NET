namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("movies/{id!!}", SupportsExtendedInfo = true)]
    internal sealed partial class MovieGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/aliases")]
    internal sealed partial class MovieAliasesGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/comments", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class MovieCommentsGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentSortOrder? SortOrder { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/lists", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MovieListsGetRequest
    {
        [TraktRequestParameter]
        internal TraktListType? ListType { get; set; }

        [TraktRequestParameter]
        internal TraktListSortOrder? SortOrder { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/people", SupportsExtendedInfo = true)]
    internal sealed partial class MoviePeopleGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/ratings")]
    internal sealed partial class MovieRatingsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/related", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MovieRelatedMoviesGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/releases")]
    internal sealed partial class MovieReleasesGetRequest
    {
        [TraktRequestParameter]
        internal string? Country { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/stats")]
    internal sealed partial class MovieStatisticsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/sentiments")]
    internal sealed partial class MovieSentimentsGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/studios")]
    internal sealed partial class MovieStudiosGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/translations")]
    internal sealed partial class MovieTranslationsGetRequest
    {
        [TraktRequestQuery("language")]
        internal string? Language { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/videos")]
    internal sealed partial class MovieVideosGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/watching", SupportsExtendedInfo = true)]
    internal sealed partial class MovieWatchingGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/boxoffice", SupportsExtendedInfo = true)]
    internal sealed partial class BoxOfficeMoviesGetRequest
    {
    }

    [TraktGetRequest("movies/anticipated", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostAnticipatedMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/collected", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostCollectedMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/favorited", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostFavoritedMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/played", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostPlayedMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/watched", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class MostWatchedMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/popular", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class PopularMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/updates/id", SupportsPagination = true)]
    internal sealed partial class RecentlyUpdatedMovieIDsGetRequest
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

    [TraktGetRequest("movies/streaming", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class StreamingMoviesGetRequest
    {
        [TraktRequestParameter]
        internal TraktTimePeriod? TimePeriod { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/hot", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class HotMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/trending", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class TrendingMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("movies/{id!!}/watchnow/{country!!}", SupportsExtendedInfo = true)]
    internal sealed partial class MovieWatchnowGetRequest
    {
        [TraktRequestQuery("links")]
        internal bool? Links { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktGetRequest("movies/{id!!}/watchnow/justwatch_links/{country!!}")]
    internal sealed partial class MovieJustwatchLinksGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("movies/{id!!}/refresh", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class MovieRefreshPostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktPostRequest("movies/{id!!}/report", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class MovieReportPostRequest
    {
        [TraktRequestPayload]
        internal required TraktReportPost TraktReportPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }

    [TraktPostRequest("movies/{id!!}/justwatch/refresh", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class MovieRefreshJustWatchPostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movie;
    }
}
