#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Notes
{
    public sealed class NoteUpdatePutRequestTests
    {
        private const string URIPath = "notes/123";

        [Fact]
        public void TestNoteUpdatePutRequestHasValidURIPath()
        {
            var noteUpdatePutRequest = new NoteUpdatePutRequest
            {
                TraktNotePost = new TraktNotePost(),
                Id = 123UL
            };

            noteUpdatePutRequest.BuildUri();
            noteUpdatePutRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestNoteUpdatePutRequestHasValidOAuthRequirement()
        {
            var noteUpdatePutRequest = new NoteUpdatePutRequest { TraktNotePost = default!, Id = default! };
            noteUpdatePutRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestNoteUpdatePutRequestIsPutRequest()
        {
            var noteUpdatePutRequest = new NoteUpdatePutRequest { TraktNotePost = default!, Id = default! };
            noteUpdatePutRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestNoteUpdatePutRequestHasCorrectRequestObjectType()
        {
            var noteUpdatePutRequest = new NoteUpdatePutRequest { TraktNotePost = default!, Id = default! };
            noteUpdatePutRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestNoteUpdatePutRequestValidate()
        {
            var noteUpdatePutRequest = new NoteUpdatePutRequest { TraktNotePost = default!, Id = default! };
            Action act = () => noteUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
