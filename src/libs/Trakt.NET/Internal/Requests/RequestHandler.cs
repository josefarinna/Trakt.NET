using System.Net.Http.Headers;

namespace TraktNET
{
    internal sealed partial class RequestHandler
    {
        internal static async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequest>(
            TraktContext context, TRequest request, CancellationToken cancellationToken = default)
            where TRequest : RequestBase where TResponseContentType : class
        {
            request.Validate();
            request.BuildUri();
            AddRequestMessageHeaders(context, request);

            HttpClient httpClient = context.GetHttpClient();
            using HttpResponseMessage responseMessage =
                await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            TraktResponseHeaders traktHeaders = ParseTraktResponseHeaders(responseMessage.Headers);

            if (!responseMessage.IsSuccessStatusCode)
            {
                await HandleErrorAsync(request, responseMessage, traktHeaders, false, cancellationToken);
            }

#if NET5_0_OR_GREATER
            using Stream responseContentStream = await responseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
#else
            using Stream responseContentStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif

            TResponseContentType? responseContent =
                await responseContentStream.ReadAsJsonAsync<TResponseContentType>(cancellationToken).ConfigureAwait(false);

            return TraktResponse<TResponseContentType>.Create(responseMessage.StatusCode, responseContent,
                traktHeaders, responseMessage.Headers, responseMessage.Content.Headers);
        }

        private static void AddRequestMessageHeaders<TRequest>(TraktContext context, TRequest request) where TRequest : RequestBase
        {
            const string AuthenticationScheme = "Bearer";

            request.Headers.Add(Constants.Request.Headers.APIVersionHeaderKey, $"{Constants.API.Version}");
            request.Headers.Add(Constants.Request.Headers.APIClientIdHeaderKey, context.ClientID);

            TraktOAuthRequirement oauthRequirement = request.OAuthRequirement;

            if (oauthRequirement == TraktOAuthRequirement.NotRequired)
            {
                return;
            }

            if (context.IgnoreOAuthIfOptional && (oauthRequirement == TraktOAuthRequirement.Optional
                || oauthRequirement == TraktOAuthRequirement.OptionalButMightBeRequired))
            {
                return;
            }

            request.Headers.Authorization = new AuthenticationHeaderValue(AuthenticationScheme, context.Authorization!.AccessToken ?? string.Empty);
        }
    }
}
