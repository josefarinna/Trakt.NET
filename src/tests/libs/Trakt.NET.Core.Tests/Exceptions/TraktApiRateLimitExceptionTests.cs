#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiRateLimitExceptionTests
    {
        private static readonly DateTime Until = DateTime.UtcNow;

        [Fact]
        public async Task TestTraktApiRateLimitExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.RateLimitExceeded, HttpMethod.Get);

            parameters.RateLimitInfo = new TraktRateLimitInfo
            {
                Name = "UNAUTHED_API_GET_LIMIT",
                Period = 300,
                Limit = 1000,
                Remaining = 500,
                Until = Until
            };

            parameters.TraktHeaders.RetryAfter = 1000;

            var exception = TraktApiException.Create(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.RateLimitExceeded);
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Rate Limit Exceeded");

            var rateLimitException = exception as TraktApiRateLimitException;

            rateLimitException.Should().NotBeNull();
            rateLimitException!.RateLimitInfo.Should().NotBeNull();
            rateLimitException!.RateLimitInfo!.Name.Should().Be("UNAUTHED_API_GET_LIMIT");
            rateLimitException!.RateLimitInfo!.Period.Should().Be(300U);
            rateLimitException!.RateLimitInfo!.Limit.Should().Be(1000U);
            rateLimitException!.RateLimitInfo!.Remaining.Should().Be(500U);
            rateLimitException!.RateLimitInfo!.Until.Should().Be(Until);
            rateLimitException!.RetryAfter.Should().Be(1000U);
        }
    }
}
