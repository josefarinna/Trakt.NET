#if TRAKT_OLDER_NET_TARGETS
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

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.AccountLimitExceeded);
            exception.ReasonPhrase.Should().Be("Account Limit Exceeded - list count, item count, etc");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Account Limit Exceeded - list count, item count, etc");

            var accountLimitException = exception as TraktApiAccountLimitException;

            accountLimitException.Should().NotBeNull();
            accountLimitException!.UpgradeURL.Should().Be("upgrade/url");
            accountLimitException!.IsVIPUser.Should().BeTrue();
            accountLimitException!.AccountLimit.Should().Be(1000U);
        }
    }
}
