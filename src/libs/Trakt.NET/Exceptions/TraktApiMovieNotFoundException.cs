using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a movie was not found.</summary>
    public sealed class TraktApiMovieNotFoundException(string movieId, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                       string? responseContent = null, HttpResponseHeaders? headers = null,
                                                       HttpContentHeaders? contentHeaders = null, Exception? innerException = null)
        : TraktApiObjectNotFoundException(movieId, "Movie Not Found - method exists, but no record found", httpMethod, requestMessage,
                                          responseContent, headers, contentHeaders, innerException)
    {
    }
}
