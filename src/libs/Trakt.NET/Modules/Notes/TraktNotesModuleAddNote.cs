using System.Net.Http.Json;

namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to notes.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/notes">"Trakt API Documentation - Notes"</a> section.
    /// </summary>
    public partial class TraktNotesModule
    {
        /// <summary>Adds notes for a <see cref="TraktMovie" />.</summary>
        /// <param name="movie">An <see cref="TraktMovie" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddMovieNoteAsync(TraktMovie movie, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddMovieNoteImplAsync(movie, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for a <see cref="TraktShow" />.</summary>
        /// <param name="show">An <see cref="TraktShow" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddShowNoteAsync(TraktShow show, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddShowNoteImplAsync(show, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for a <see cref="TraktSeason" />.</summary>
        /// <param name="season">An <see cref="TraktSeason" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddSeasonNoteAsync(TraktSeason season, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddSeasonNoteImplAsync(season, notes, spoiler, privacy, cancellationToken);

        /// <summary> Adds notes for an <see cref="TraktEpisode" />.</summary>
        /// <param name="episode">An <see cref="TraktEpisode" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddEpisodeNoteAsync(TraktEpisode episode, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddEpisodeNoteImplAsync(episode, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for a <see cref="TraktPerson" />.</summary>
        /// <param name="person">An <see cref="TraktPerson" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddPersonNoteAsync(TraktPerson person, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddPersonNoteImplAsync(person, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for an history item. </summary>
        /// <param name="historyID">The ID of the history item for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddHistoryNoteAsync(ulong historyID, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddHistoryNoteImplAsync(historyID, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for a collection <see cref="TraktMovie" />.</summary>
        /// <param name="movie">An <see cref="TraktMovie" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddCollectionMovieNoteAsync(TraktMovie movie, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddCollectionMovieNoteImplAsync(movie, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for a collection <see cref="TraktShow" />.</summary>
        /// <param name="show">An <see cref="TraktShow" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddCollectionShowNoteAsync(TraktShow show, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddCollectionShowNoteImplAsync(show, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for a rated <see cref="TraktMovie" />.</summary>
        /// <param name="movie">An <see cref="TraktMovie" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddRatedMovieNoteAsync(TraktMovie movie, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddRatedMovieNoteImplAsync(movie, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for a rated <see cref="TraktShow" />.</summary>
        /// <param name="show">An <see cref="TraktShow" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddRatedShowNoteAsync(TraktShow show, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddRatedShowNoteImplAsync(show, notes, spoiler, privacy, cancellationToken);

        /// <summary>Adds notes for a rated <see cref="TraktSeason" />.</summary>
        /// <param name="season">An <see cref="TraktSeason" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the created user notes entry.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktNote" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization required.
        /// <para>VIP enhanced.</para>
        /// <para><see href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">
        /// Trakt API Documentation: Notes: Add notes
        /// </see></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddRatedSeasonNoteAsync(TraktSeason season, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddRatedSeasonNoteImplAsync(season, notes, spoiler, privacy, cancellationToken);

        /// <summary>
        /// Adds notes for an rated <see cref="TraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Documentation: Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">An <see cref="TraktEpisode" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="TraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktNote>> AddRatedEpisodeNoteAsync(TraktEpisode episode, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
            => AddRatedEpisodeNoteImplAsync(episode, notes, spoiler, privacy, cancellationToken);
    }
}
