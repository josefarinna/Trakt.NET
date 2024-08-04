using System.Net;
using System.Net.Http.Headers;

namespace TraktNET
{
    internal sealed class ExceptionParameters
    {
        internal required HttpRequestMessage Request { get; init; }

        internal required HttpStatusCode StatusCode { get; init; }

        internal required HttpMethod Method { get; init; }

        internal required string ResponseContent { get; init; }

        internal required string ReasonPhrase { get; init; }

        internal required HttpResponseHeaders Headers { get; init; }

        internal required TraktResponseHeaders TraktHeaders { get; init; }

        internal required HttpContentHeaders ContentHeaders { get; init; }

        internal required RequestFlags Flags { get; init; }

        internal required TraktRequestObjectType RequestObjectType { get; init; }

        internal required string ObjectId { get; init; }

        internal required uint SeasonNr { get; init; }

        internal required uint EpisodeNr { get; init; }

        internal required bool IsInAuthorizationPolling { get; init; }

        internal TraktCheckinErrorResponse? CheckinErrorResponse { get; set; }

        internal TraktRateLimitInfo? RateLimitInfo { get; set; }

        internal static async Task<ExceptionParameters> CreateAsync(RequestBase request, HttpResponseMessage responseMessage,
                                                                    TraktResponseHeaders traktHeaders, bool isInAuthorizationPolling,
                                                                    CancellationToken cancellationToken = default)
        {
#if NET5_0_OR_GREATER
            string responseContent = await responseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#else
            string responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif

            return new()
            {
                Request = request,
                StatusCode = responseMessage.StatusCode,
                Method = request.Method,
                ResponseContent = responseContent,
                ReasonPhrase = responseMessage.ReasonPhrase ?? string.Empty,
                Headers = responseMessage.Headers,
                TraktHeaders = traktHeaders,
                ContentHeaders = responseMessage.Content.Headers,
                Flags = request.Flags,
                RequestObjectType = request.RequestObjectType,
                ObjectId = request.ObjectId,
                SeasonNr = request.SeasonNr,
                EpisodeNr = request.EpisodeNr,
                IsInAuthorizationPolling = isInAuthorizationPolling
            };
        }
    }
}
