namespace TraktNET.Exceptions
{
    public class TraktApiAuthorizationExceptionTests
    {
        [Fact]
        public async Task TestTraktApiAuthorizationExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.Unauthorized, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.Unauthorized);
            exception.ReasonPhrase.Should().Be("Unauthorized - OAuth must be provided");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Unauthorized - OAuth must be provided");
        }
    }
}
