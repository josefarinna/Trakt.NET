namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("watchnow/sources")]
    internal sealed partial class WatchnowSourcesGetRequest
    {
    }

    [TraktGetRequest("watchnow/sources/{countryCode!!}")]
    internal sealed partial class WatchnowSourcesCountryGetRequest
    {
    }
}
