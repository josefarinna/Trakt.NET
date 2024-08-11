namespace TraktNET.Exceptions
{
    public class TraktApiUserNotFoundExceptionTests
    {
        [Fact]
        public async Task TestTraktApiUserNotFoundExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.NotFound, HttpMethod.Get, objectId: "userId");

            var exception = new TraktApiUserNotFoundException(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.NotFound);
            exception.ReasonPhrase.Should().Be("User Not Found - method exists, but no record found");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. User Not Found - method exists, but no record found");

            exception.UserID.Should().Be("userId");
        }
    }
}
