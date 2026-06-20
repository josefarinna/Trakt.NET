namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to scrobbles.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/scrobble">"Trakt API Documentation - Scrobble"</a> section.
    /// </summary>
    public sealed partial class TraktScrobbleModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktMovieScrobblePostResponse>> StartMovieImplAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieScrobblePostResponse>(_context, CreateScrobbleStartRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktMovieScrobblePostResponse>> PauseMovieImplAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieScrobblePostResponse>(_context, CreateScrobblePauseRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktMovieScrobblePostResponse>> StopMovieImplAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieScrobblePostResponse>(_context, CreateScrobbleStopRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeScrobblePostResponse>> StartEpisodeImplAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisodeScrobblePostResponse>(_context, CreateScrobbleStartRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeScrobblePostResponse>> PauseEpisodeImplAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisodeScrobblePostResponse>(_context, CreateScrobblePauseRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeScrobblePostResponse>> StopEpisodeImplAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisodeScrobblePostResponse>(_context, CreateScrobbleStopRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        private static ScrobbleStartPostRequest CreateScrobbleStartRequest<T, U>(U requestBody) where U : TraktScrobblePost
            => new() { TraktScrobblePost = requestBody };

        private static ScrobblePausePostRequest CreateScrobblePauseRequest<T, U>(U requestBody) where U : TraktScrobblePost
            => new() { TraktScrobblePost = requestBody };

        private static ScrobbleStopPostRequest CreateScrobbleStopRequest<T, U>(U requestBody) where U : TraktScrobblePost
            => new() { TraktScrobblePost = requestBody };
    }
}
