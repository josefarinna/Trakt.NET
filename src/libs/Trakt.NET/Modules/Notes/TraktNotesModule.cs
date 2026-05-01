namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to notes.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/notes">"Trakt API Documentation - Notes"</a> section.
    /// </summary>
    public sealed partial class TraktNotesModule
    {
        /// <summary>Returns a single note.</summary>
        /// <param name="noteId">The id of the note which should is requested.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the requested note.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/note/get-a-note">
        /// Trakt API Documentation: Note: Get a note
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> GetNoteAsync(ulong noteId, CancellationToken cancellationToken = default)
            => GetNoteImplAsync(noteId, cancellationToken);

        /// <summary>Update a single note (500 maximum characters).</summary>
        /// <param name="noteId">The id of the note which should be updated.</param>
        /// <param name="notes">The new content of the note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the requested note.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/note/update-a-note">
        /// Trakt API Documentation: Note: Update a note
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> UpdateNoteAsync(ulong noteId, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => UpdateNoteImplAsync(noteId, notes, spoiler, privacy, cancellationToken);

        /// <summary>Delete a single note.</summary>
        /// <param name="noteId">The id of the note which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A <see cref="TraktResponse" />.</returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/note/delete-a-note">
        /// Trakt API Documentation: Note: Delete a note
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse> DeleteNoteAsync(ulong noteId, CancellationToken cancellationToken = default)
            => DeleteNoteImplAsync(noteId, cancellationToken);

        /// <summary>Returns the item this note is attached to.</summary>
        /// <param name="noteId">The id of the note for which the attached item should is requested.</param>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the note item.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the queried comment's media item.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNoteItem" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/item/get-the-attached-item">
        /// Trakt API Documentation: Item: Get the attached item
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNoteItem>> GetNoteItemAsync(ulong noteId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetNoteItemImplAsync(noteId, extendedInfo, cancellationToken);
    }
}
