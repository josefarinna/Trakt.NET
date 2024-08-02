using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a season was not found.</summary>
    public class TraktApiSeasonNotFoundException(string showId, uint seasonNumber, string message, HttpMethod httpMethod,
                                                 HttpRequestMessage requestMessage, string? responseContent = null,
                                                 HttpResponseHeaders? headers = null, HttpContentHeaders? contentHeaders = null,
                                                 Exception? innerException = null)
        : TraktApiShowNotFoundException(showId, message, httpMethod, requestMessage, responseContent, headers, contentHeaders, innerException)
    {
        public TraktApiSeasonNotFoundException(string showId, uint seasonNumber, HttpMethod httpMethod,
                                               HttpRequestMessage requestMessage, string? responseContent = null,
                                               HttpResponseHeaders? headers = null, HttpContentHeaders? contentHeaders = null,
                                               Exception? innerException = null)
        : this(showId, seasonNumber, "Season Not Found - method exists, but no record found", httpMethod, requestMessage,
               responseContent, headers, contentHeaders, innerException)
        {
        }

        public uint? SeasonNumber { get; } = seasonNumber;
    }
}
