namespace TraktNET.Exceptions
{
    public class TraktApiSeasonNotFoundExceptionTests
    {
        [Fact]
        public async Task TestTraktApiSeasonNotFoundExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.NotFound, HttpMethod.Get, objectId: "showId", seasonNumber: 1);

            var exception = new TraktApiSeasonNotFoundException(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.NotFound);
            exception.ReasonPhrase.Should().Be("Season Not Found - method exists, but no record found");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Season Not Found - method exists, but no record found");

            exception.ShowID.Should().Be("showId");
            exception.SeasonNumber.Should().Be(1U);
        }
    }
}
