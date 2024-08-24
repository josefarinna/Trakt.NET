#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiCheckinExceptionTests
    {
        private static readonly DateTime ExpiresAt = DateTime.UtcNow;

        [Fact]
        public async Task TestTraktApiCheckinExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.Conflict, HttpMethod.Get);

            parameters.CheckinErrorResponse = new TraktCheckinErrorResponse
            {
                ExpiresAt = ExpiresAt
            };

            var exception = new TraktApiCheckinException(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.Conflict);
            exception.ReasonPhrase.Should().Be("Checkin is already in progress");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Checkin is already in progress");

            exception.ExpiresAt.Should().Be(ExpiresAt);
        }
    }
}
