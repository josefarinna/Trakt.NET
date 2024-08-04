using System.Net.Http.Headers;
using System.Text.Json;

#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace TraktNET
{
    internal sealed partial class RequestHandler
    {
        internal static async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequest>(
            TraktContext context, TRequest request, CancellationToken cancellationToken = default)
            where TRequest : RequestBase where TResponseContentType : class
        {
            request.BuildUri();
            AddRequestMessageHeaders(context, request);

            HttpClient httpClient = context.GetHttpClient();
            using HttpResponseMessage responseMessage = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

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

            TResponseContentType? responseContent;

#if NET6_0_OR_GREATER
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactory.GetContext<TResponseContentType>();

            responseContent = await JsonSerializer.DeserializeAsync(responseContentStream, typeof(TResponseContentType),
                jsonSerializerContext, cancellationToken).ConfigureAwait(false) as TResponseContentType;
#else
            responseContent = await JsonSerializer.DeserializeAsync<TResponseContentType>(responseContentStream,
                Constants.Json.JsonOptions, cancellationToken).ConfigureAwait(false);
#endif

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
