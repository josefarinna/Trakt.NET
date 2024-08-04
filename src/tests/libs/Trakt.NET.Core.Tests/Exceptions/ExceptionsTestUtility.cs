using System.Net;
using System.Text;

namespace TraktNET.Exceptions
{
    internal static class ExceptionsTestUtility
    {
        internal const string TestUri = "tests/exceptions/mock";
        internal const string TestResponseContent = "response content";

        internal static Task<ExceptionParameters> CreateMockExceptionParametersAsync(HttpStatusCode statusCode, HttpMethod httpMethod,
            string? objectId = null, uint? seasonNumber = null, uint? episodeNumber = null)
        {
            var requestMessage = new MockRequest(httpMethod, new Uri(TestUri, UriKind.Relative),
                                                 objectId ?? string.Empty, seasonNumber ?? 0, episodeNumber ?? 0);

            var responseMessage = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(TestResponseContent, Encoding.UTF8)
            };

            var traktHeaders = new TraktResponseHeaders();

            return ExceptionParameters.CreateAsync(requestMessage, responseMessage, traktHeaders, false);
        }
    }
}
