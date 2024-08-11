#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.Exceptions
{
    public class TraktApiCommentNotFoundExceptionTests
    {
        [Fact]
        public async Task TestTraktApiCommentNotFoundExceptionCreate()
        {
            ExceptionParameters parameters = await ExceptionsTestUtility.CreateMockExceptionParametersAsync(
                Constants.StatusCodes.NotFound, HttpMethod.Get, objectId: "commentId");

            var exception = new TraktApiCommentNotFoundException(parameters);

            exception.Should().NotBeNull();
            exception.StatusCode.Should().Be(Constants.StatusCodes.NotFound);
            exception.ReasonPhrase.Should().Be("Comment Not Found - method exists, but no record found");
            exception.HttpMethod.Should().Be(HttpMethod.Get);
            exception.RequestMessage.Should().NotBeNull();
            exception.RequestUri.Should().Be(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.Should().Be(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.Should().NotBeNull();
            exception.ContentHeaders.Should().NotBeNull();
            exception.Message.Should().Be("Trakt API request failed. Comment Not Found - method exists, but no record found");

            exception.CommentID.Should().Be("commentId");
        }
    }
}
