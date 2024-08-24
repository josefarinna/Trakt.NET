#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiVIPValidationExceptionTests
    {
        [Fact]
        public async Task TestTraktApiVIPValidationExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.VIPValidationError, HttpMethod.Get);

            parameters.TraktHeaders.UpgradeURL = "upgrade/url";

            var exception = TraktApiException.Create(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.VIPValidationError);
            exception.ReasonPhrase.Should().Be("VIP Only - user must upgrade to VIP");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. VIP Only - user must upgrade to VIP");

            var vipValidationException = exception as TraktApiVIPValidationException;

            vipValidationException.Should().NotBeNull();
            vipValidationException!.UpgradeURL.Should().Be("upgrade/url");
        }
    }
}
