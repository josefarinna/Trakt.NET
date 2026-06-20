namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("notes/{id:ulong!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class NoteGetRequest
    {
    }

    [TraktGetRequest("notes/{id:ulong!!}/item", SupportsExtendedInfo = true)]
    internal sealed partial class NoteItemGetRequest
    {
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("notes", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class NotesAddPostRequest
    {
        [TraktRequestPayload]
        internal required TraktNotePost TraktNotePost { get; set; }
    }

    // -------------------------------------------------------
    // PUT Requests
    // -------------------------------------------------------

    [TraktPutRequest("notes/{id:ulong!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class NoteUpdatePutRequest
    {
        [TraktRequestPayload]
        internal required TraktNotePost TraktNotePost { get; set; }
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("notes/{id:ulong!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class NoteDeleteRequest
    {
    }
}
