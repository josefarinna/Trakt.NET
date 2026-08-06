namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to scrobbles.
    /// <para>This module contains all methods of the <see href="https://docs.trakt.tv/reference/about-scrobble">Trakt API Documentation - Scrobble</see> section.</para>
    /// </summary>
    public sealed partial class TraktScrobbleModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktMovieScrobblePostResponse>> StartMovieImplAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieScrobblePostResponse>(_context, CreateScrobbleStartRequest<TraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktMovieScrobblePostResponse>> PauseMovieImplAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieScrobblePostResponse>(_context, CreateScrobblePauseRequest<TraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktMovieScrobblePostResponse>> StopMovieImplAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieScrobblePostResponse>(_context, CreateScrobbleStopRequest<TraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeScrobblePostResponse>> StartEpisodeImplAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisodeScrobblePostResponse>(_context, CreateScrobbleStartRequest<TraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeScrobblePostResponse>> PauseEpisodeImplAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisodeScrobblePostResponse>(_context, CreateScrobblePauseRequest<TraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeScrobblePostResponse>> StopEpisodeImplAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisodeScrobblePostResponse>(_context, CreateScrobbleStopRequest<TraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        private static ScrobbleStartPostRequest CreateScrobbleStartRequest<T>(T requestBody) where T : TraktScrobblePost
            => new() { TraktScrobblePost = requestBody };

        private static ScrobblePausePostRequest CreateScrobblePauseRequest<T>(T requestBody) where T : TraktScrobblePost
            => new() { TraktScrobblePost = requestBody };

        private static ScrobbleStopPostRequest CreateScrobbleStopRequest<T>(T requestBody) where T : TraktScrobblePost
            => new() { TraktScrobblePost = requestBody };
    }
}
