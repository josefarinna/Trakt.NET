namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("calendars/my/shows", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserShowsGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/new", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserNewShowsGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/premieres", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserSeasonPremieresGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/finales", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserFinalesGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/movies", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserMoviesGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/streaming", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserStreamingMoviesGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/dvd", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUSerDVDMoviesGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllShowsGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/new", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllNewShowsGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/premieres", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllSeasonPremieresGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/finales", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllFinalesGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/movies", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllMoviesGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/streaming", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllStreamingMoviesGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/dvd", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllDVDMoviesGetRequest
    {
        [TraktRequestParameter]
        internal string? StartDate { get; set; }

        [TraktRequestParameter]
        internal uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }
}
