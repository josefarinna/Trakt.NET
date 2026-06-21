#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Notes
{
    public sealed class NotesAddPostRequestTests
    {
        private const string URIPath = "notes";

        [Fact]
        public void TestNotesAddPostRequestHasValidURIPath()
        {
            var notesAddPostRequest = new NotesAddPostRequest
            {
                TraktNotePost = new TraktNotePost()
            };

            notesAddPostRequest.BuildUri();
            notesAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestNotesAddPostRequestHasValidOAuthRequirement()
        {
            var notesAddPostRequest = new NotesAddPostRequest { TraktNotePost = default! };
            notesAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestNotesAddPostRequestIsPostRequest()
        {
            var notesAddPostRequest = new NotesAddPostRequest { TraktNotePost = default! };
            notesAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestNotesAddPostRequestHasCorrectRequestObjectType()
        {
            var notesAddPostRequest = new NotesAddPostRequest { TraktNotePost = default! };
            notesAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestNotesAddPostRequestValidate()
        {
            var notesAddPostRequest = new NotesAddPostRequest { TraktNotePost = default! };
            Action act = () => notesAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
