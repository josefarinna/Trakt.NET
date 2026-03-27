using System.Net.Http.Json;

namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to notes.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/notes">"Trakt API Documentation - Notes"</a> section.
    /// </summary>
    public sealed partial class TraktNotesModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktNote>> GetNoteImplAsync(ulong noteId, CancellationToken cancellationToken = default)
        {
            var request = new NoteGetRequest
            {
                Id = noteId
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> UpdateNoteImplAsync(ulong noteId, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                IgnoreCompleteValidation = true
            };

            traktNotePost.Validate();

            var request = new NoteUpdatePutRequest
            {
                Id = noteId,
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> DeleteNoteImplAsync(ulong noteId, CancellationToken cancellationToken = default)
        {
            var request = new NoteDeleteRequest
            {
                Id = noteId
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNoteItem>> GetNoteItemImplAsync(ulong noteId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new NoteItemGetRequest
            {
                Id = noteId,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNoteItem>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddMovieNoteImplAsync(TraktMovie movie, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Movie = movie
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddShowNoteImplAsync(TraktShow show, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Show = show
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddSeasonNoteImplAsync(TraktSeason season, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Season = season
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddEpisodeNoteImplAsync(TraktEpisode episode, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Episode = episode
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddPersonNoteImplAsync(TraktPerson person, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Person = person
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddHistoryNoteImplAsync(ulong historyID, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.History,
                    ID = historyID
                }
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddCollectionMovieNoteImplAsync(TraktMovie movie, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movie);

            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Movie = movie,
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.Collection
                }
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddCollectionShowNoteImplAsync(TraktShow show, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Show = show,
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.Collection
                }
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddRatedMovieNoteImplAsync(TraktMovie movie, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movie);

            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Movie = movie,
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.Rating
                }
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddRatedShowNoteImplAsync(TraktShow show, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(show);

            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Show = show,
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.Rating
                }
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddRatedSeasonNoteImplAsync(TraktSeason season, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(season);

            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Season = season,
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.Rating
                }
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktNote>> AddRatedEpisodeNoteImplAsync(TraktEpisode episode, string notes, bool? spoiler = null,
            TraktListPrivacy? privacy = null, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(episode);

            var traktNotePost = new TraktNotePost
            {
                Notes = notes,
                Spoiler = spoiler,
                Privacy = privacy,
                Episode = episode,
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.Rating
                }
            };

            traktNotePost.Validate();

            var request = new NotesAddPostRequest
            {
                Content = JsonContent.Create(traktNotePost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktNote>(_context, request, cancellationToken);
        }
    }
}
