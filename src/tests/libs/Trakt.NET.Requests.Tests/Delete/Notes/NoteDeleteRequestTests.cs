#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Notes
{
    public sealed class NoteDeleteRequestTests
    {
        private const string URIPath = "notes/123";

        [Fact]
        public void TestNoteDeleteRequestHasValidURIPath()
        {
            var noteDeleteRequest = new NoteDeleteRequest
            {
                Id = 123UL
            };

            noteDeleteRequest.BuildUri();
            noteDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestNoteDeleteRequestHasValidOAuthRequirement()
        {
            var noteDeleteRequest = new NoteDeleteRequest { Id = default! };
            noteDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestNoteDeleteRequestIsDeleteRequest()
        {
            var noteDeleteRequest = new NoteDeleteRequest { Id = default! };
            noteDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestNoteDeleteRequestHasCorrectRequestObjectType()
        {
            var noteDeleteRequest = new NoteDeleteRequest { Id = default! };
            noteDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestNoteDeleteRequestValidate()
        {
            var noteDeleteRequest = new NoteDeleteRequest { Id = default! };
            Action act = () => noteDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
