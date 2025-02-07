#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiCloudflareExceptionTests
    {
        [Fact]
        public async Task TestTraktApiCloudflareExceptionCode520Create()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.ServiceUnavailableCloudflareError520, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.ServiceUnavailableCloudflareError520);
            exception.ReasonPhrase.ShouldBe("Service Unavailable - Cloudflare error - Status Code 520");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Service Unavailable - Cloudflare error - Status Code 520");
        }

        [Fact]
        public async Task TestTraktApiCloudflareExceptionCode521Create()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.ServiceUnavailableCloudflareError521, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.ServiceUnavailableCloudflareError521);
            exception.ReasonPhrase.ShouldBe("Service Unavailable - Cloudflare error - Status Code 521");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Service Unavailable - Cloudflare error - Status Code 521");
        }

        [Fact]
        public async Task TestTraktApiCloudflareExceptionCode522Create()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.ServiceUnavailableCloudflareError522, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.ServiceUnavailableCloudflareError522);
            exception.ReasonPhrase.ShouldBe("Service Unavailable - Cloudflare error - Status Code 522");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Service Unavailable - Cloudflare error - Status Code 522");
        }
    }
}
