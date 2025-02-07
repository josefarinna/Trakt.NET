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

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.VIPValidationError);
            exception.ReasonPhrase.ShouldBe("VIP Only - user must upgrade to VIP");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. VIP Only - user must upgrade to VIP");

            var vipValidationException = exception as TraktApiVIPValidationException;

            vipValidationException.ShouldNotBeNull();
            vipValidationException!.UpgradeURL.ShouldBe("upgrade/url");
        }
    }
}
