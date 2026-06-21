#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Notes
{
    public sealed class NoteItemGetRequestTests
    {
        private const string URIPath = "notes/123/item";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestNoteItemGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var noteItemGetRequest = new NoteItemGetRequest
            {
                Id = 123UL,
                ExtendedInfo = extendedInfo
            };

            noteItemGetRequest.BuildUri();
            noteItemGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestNoteItemGetRequestHasValidOAuthRequirement()
        {
            var noteItemGetRequest = new NoteItemGetRequest { Id = default! };
            noteItemGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestNoteItemGetRequestIsGetRequest()
        {
            var noteItemGetRequest = new NoteItemGetRequest { Id = default! };
            noteItemGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestNoteItemGetRequestHasCorrectRequestObjectType()
        {
            var noteItemGetRequest = new NoteItemGetRequest { Id = default! };
            noteItemGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestNoteItemGetRequestValidate()
        {
            var noteItemGetRequest = new NoteItemGetRequest { Id = default! };
            Action act = () => noteItemGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
