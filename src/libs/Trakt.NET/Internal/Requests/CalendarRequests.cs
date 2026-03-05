namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("calendars/my/shows", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserShowsGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/new", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserNewShowsGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/premieres", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserSeasonPremieresGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/finales", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserFinalesGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/movies", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserMoviesGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/streaming", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserStreamingMoviesGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/dvd", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUSerDVDMoviesGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllShowsGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/new", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllNewShowsGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/premieres", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllSeasonPremieresGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/finales", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllFinalesGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/movies", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllMoviesGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/streaming", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllStreamingMoviesGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/dvd", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllDVDMoviesGetRequest
    {
        [TraktRequestParameter]
        public string? StartDate { get; set; }

        [TraktRequestParameter]
        public uint? Days { get; set; }

        [TraktRequestQuery("filter")]
        public TraktFilter? Filter { get; set; }
    }
}
