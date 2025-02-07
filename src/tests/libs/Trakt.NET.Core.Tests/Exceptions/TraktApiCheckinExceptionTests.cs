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

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.Conflict);
            exception.ReasonPhrase.ShouldBe("Checkin is already in progress");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Checkin is already in progress");

            exception.ExpiresAt.ShouldBe(ExpiresAt);
        }
    }
}
