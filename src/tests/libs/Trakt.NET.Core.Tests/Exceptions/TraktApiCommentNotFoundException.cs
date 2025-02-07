#if TRAKT_NET_4XX_FRAMEWORK_TARGET
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
                Constants.StatusCodes.NotFound, HttpMethod.Get, objectID: "commentID");

            var exception = new TraktApiCommentNotFoundException(parameters);

            exception.ShouldNotBeNull();
            exception.StatusCode.ShouldBe(Constants.StatusCodes.NotFound);
            exception.ReasonPhrase.ShouldBe("Comment Not Found - method exists, but no record found");
            exception.HttpMethod.ShouldBe(HttpMethod.Get);
            exception.RequestMessage.ShouldNotBeNull();
            exception.RequestUri.ShouldBe(new Uri(ExceptionsTestUtility.TestUri, UriKind.Relative));
            exception.ResponseContent.ShouldBe(ExceptionsTestUtility.TestResponseContent);
            exception.Headers.ShouldNotBeNull();
            exception.ContentHeaders.ShouldNotBeNull();
            exception.Message.ShouldBe("Trakt API request failed. Comment Not Found - method exists, but no record found");

            exception.CommentID.ShouldBe("commentID");
        }
    }
}
