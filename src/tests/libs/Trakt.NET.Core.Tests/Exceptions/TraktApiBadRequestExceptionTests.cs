namespace TraktNET.Exceptions
{
    public class TraktApiBadRequestExceptionTests
    {
        [Fact]
        public async Task TestTraktApiBadRequestExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.BadRequest, HttpMethod.Get);

            var exception = TraktApiException.Create(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.BadRequest);
            exception.ReasonPhrase.Should().Be("Bad Request - request couldn't be parsed");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Bad Request - request couldn't be parsed");
        }
    }
}
