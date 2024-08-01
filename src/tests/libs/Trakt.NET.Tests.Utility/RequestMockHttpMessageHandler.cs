using System.Net;
using System.Text;

namespace TraktNET
{
    public class RequestMockHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // TODO Add properties for customization options

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
            };

            return Task.FromResult(response);
        }
    }
}
