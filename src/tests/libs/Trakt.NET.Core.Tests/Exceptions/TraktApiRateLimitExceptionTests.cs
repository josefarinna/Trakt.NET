#if TRAKT_NET_4XX_FRAMEWORK_TARGET
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

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.RateLimitExceeded);
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Rate Limit Exceeded");

            var rateLimitException = exception as TraktApiRateLimitException;

            rateLimitException.ShouldNotBeNull();
            rateLimitException!.RateLimitInfo.ShouldNotBeNull();
            rateLimitException!.RateLimitInfo!.Name.ShouldBe("UNAUTHED_API_GET_LIMIT");
            rateLimitException!.RateLimitInfo!.Period.ShouldBe(300U);
            rateLimitException!.RateLimitInfo!.Limit.ShouldBe(1000U);
            rateLimitException!.RateLimitInfo!.Remaining.ShouldBe(500U);
            rateLimitException!.RateLimitInfo!.Until.ShouldBe(Until);
            rateLimitException!.RetryAfter.ShouldBe(1000U);
        }
    }
}
