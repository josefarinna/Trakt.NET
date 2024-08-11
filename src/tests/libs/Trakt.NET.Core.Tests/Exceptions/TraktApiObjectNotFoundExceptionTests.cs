#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiObjectNotFoundExceptionTests
    {
        [Fact]
        public async Task TestTraktApiObjectNotFoundExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.NotFound, HttpMethod.Get, objectId: "objectId");

            var exception = new TraktApiObjectNotFoundException(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.NotFound);
            exception.ReasonPhrase.Should().Be("Object Not Found - method exists, but no record found");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Object Not Found - method exists, but no record found");

            exception.ObjectID.Should().Be("objectId");
        }
    }
}
