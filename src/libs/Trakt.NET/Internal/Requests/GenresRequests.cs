namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("genres/movies", SupportsExtendedInfo = true)]
    internal sealed partial class GenresMoviesGetRequest
    {
    }

    [TraktGetRequest("genres/shows", SupportsExtendedInfo = true)]
    internal sealed partial class GenresShowsGetRequest
    {
    }
}
