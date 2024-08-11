namespace TraktNET.Exceptions
{
    public class TraktApiMovieNotFoundExceptionTests
    {
        [Fact]
        public async Task TestTraktApiMovieNotFoundExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.NotFound, HttpMethod.Get, objectId: "movieId");

            var exception = new TraktApiMovieNotFoundException(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.NotFound);
            exception.ReasonPhrase.Should().Be("Movie Not Found - method exists, but no record found");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Movie Not Found - method exists, but no record found");

            exception.MovieID.Should().Be("movieId");
        }
    }
}
