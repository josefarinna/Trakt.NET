using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an episode was not found.</summary>
    public sealed class TraktApiEpisodeNotFoundException(string showId, uint seasonNumber, uint episodeNumber, HttpMethod httpMethod,
                                                        HttpRequestMessage requestMessage, string? responseContent = null,
                                                        HttpResponseHeaders? headers = null, HttpContentHeaders? contentHeaders = null,
                                                        Exception? innerException = null)
        : TraktApiSeasonNotFoundException(showId, seasonNumber, "Episode Not Found - method exists, but no record found", httpMethod, requestMessage,
                                          responseContent, headers, contentHeaders, innerException)
    {
        public uint? EpisodeNumber { get; } = episodeNumber;
    }
}
