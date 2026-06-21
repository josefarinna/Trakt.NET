#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Notes
{
    public sealed class NoteGetRequestTests
    {
        private const string URIPath = "notes/123";

        [Fact]
        public void TestNoteGetRequestHasValidURIPath()
        {
            var noteGetRequest = new NoteGetRequest
            {
                Id = 123UL
            };

            noteGetRequest.BuildUri();
            noteGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestNoteGetRequestHasValidOAuthRequirement()
        {
            var noteGetRequest = new NoteGetRequest { Id = default! };
            noteGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestNoteGetRequestIsGetRequest()
        {
            var noteGetRequest = new NoteGetRequest { Id = default! };
            noteGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestNoteGetRequestHasCorrectRequestObjectType()
        {
            var noteGetRequest = new NoteGetRequest { Id = default! };
            noteGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestNoteGetRequestValidate()
        {
            var noteGetRequest = new NoteGetRequest { Id = default! };
            Action act = () => noteGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
