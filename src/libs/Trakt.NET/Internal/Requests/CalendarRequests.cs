namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("calendars/my/shows/{start_date}/{days:uint!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserShowsGetRequest
    {
        [TraktRequestQuery("group")]
        internal TraktCalendarGroup? Group { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/new/{start_date}/{days:uint!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserNewShowsGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/premieres/{start_date}/{days:uint!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserSeasonPremieresGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/shows/finales/{start_date}/{days:uint!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserFinalesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/movies/{start_date}/{days:uint!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/streaming/{start_date}/{days:uint!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserStreamingMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/my/dvd/{start_date}/{days:uint!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUSerDVDMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllShowsGetRequest
    {
        [TraktRequestQuery("group")]
        internal TraktCalendarGroup? Group { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/new/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllNewShowsGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/premieres/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllSeasonPremieresGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/shows/finales/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllFinalesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/movies/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/streaming/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllStreamingMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/all/dvd/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllDVDMoviesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/releases/hot/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllReleasesHotGetRequest
    {
        [TraktRequestQuery("group")]
        internal TraktCalendarGroup? Group { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }

        [TraktRequestQuery("type")]
        internal TraktCalendarMediaType? Type { get; set; }
    }

    [TraktGetRequest("calendars/my/media/{start_date}/{days:uint!!}", SupportsExtendedInfo = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CalendarUserMediaGetRequest
    {
        [TraktRequestQuery("group")]
        internal TraktCalendarGroup? Group { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }

        [TraktRequestQuery("type")]
        internal TraktCalendarMediaType? Type { get; set; }
    }

    [TraktGetRequest("calendars/all/media/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllMediaGetRequest
    {
        [TraktRequestQuery("group")]
        internal TraktCalendarGroup? Group { get; set; }

        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }

        [TraktRequestQuery("type")]
        internal TraktCalendarMediaType? Type { get; set; }
    }

    [TraktGetRequest("calendars/releases/hot/premieres/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllReleasesHotPremieresGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/releases/hot/finales/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllReleasesHotFinalesGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }

    [TraktGetRequest("calendars/releases/hot/new/{start_date}/{days:uint!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CalendarAllReleasesHotNewGetRequest
    {
        [TraktRequestQuery("filter")]
        internal TraktFilter? Filter { get; set; }
    }
}

