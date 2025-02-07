#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiAccountLimitExceptionTests
    {
        [Fact]
        public async Task TestTraktApiAccountLimitExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.AccountLimitExceeded, HttpMethod.Get);

            parameters.TraktHeaders.UpgradeURL = "upgrade/url";
            parameters.TraktHeaders.IsVIPUser = true;
            parameters.TraktHeaders.AccountLimit = 1000;

            var exception = TraktApiException.Create(parameters);

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.AccountLimitExceeded);
            exception.ReasonPhrase.ShouldBe("Account Limit Exceeded - list count, item count, etc");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Account Limit Exceeded - list count, item count, etc");

            var accountLimitException = exception as TraktApiAccountLimitException;

            accountLimitException.ShouldNotBeNull();
            accountLimitException!.UpgradeURL.ShouldBe("upgrade/url");
            accountLimitException!.IsVIPUser.ShouldBe(true);
            accountLimitException!.AccountLimit.ShouldBe(1000U);
        }
    }
}
