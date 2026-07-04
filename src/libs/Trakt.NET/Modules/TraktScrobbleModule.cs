namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to scrobbles.<para />
    /// This module contains all methods of the <a href="https://docs.trakt.tv/reference/about-scrobble">"Trakt API Documentation - Scrobble"</a> section.
    /// </summary>
    public sealed partial class TraktScrobbleModule
    {
        /// <summary>Starts watching a <see cref="TraktMovie" /> in a media center.</summary>
        /// <param name="movieScrobblePost">An <see cref="TraktMovieScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the successfully scrobbled movie's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktMovieScrobblePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postscrobblestart">
        /// Trakt API Documentation: Scrobble: Start
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktMovieScrobblePostResponse>> StartMovieAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
            => StartMovieImplAsync(movieScrobblePost, cancellationToken);

        /// <summary>Pauses watching a <see cref="TraktMovie" /> in a media center.</summary>
        /// <param name="movieScrobblePost">An <see cref="TraktMovieScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the successfully scrobbled movie's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktMovieScrobblePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postscrobblepause">
        /// Trakt API Documentation: Scrobble: Pause
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktMovieScrobblePostResponse>> PauseMovieAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
            => PauseMovieImplAsync(movieScrobblePost, cancellationToken);

        /// <summary>Stops watching a <see cref="TraktMovie" /> in a media center.</summary>
        /// <param name="movieScrobblePost">An <see cref="TraktMovieScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the successfully scrobbled movie's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktMovieScrobblePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postscrobblestop">
        /// Trakt API Documentation: Scrobble: Stop or Finish
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktMovieScrobblePostResponse>> StopMovieAsync(TraktMovieScrobblePost movieScrobblePost,
            CancellationToken cancellationToken = default)
            => StopMovieImplAsync(movieScrobblePost, cancellationToken);

        /// <summary>Starts watching a <see cref="TraktEpisode" /> in a media center.</summary>
        /// <param name="episodeScrobblePost">An <see cref="TraktEpisodeScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the successfully scrobbled episode's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeScrobblePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postscrobblestart">
        /// Trakt API Documentation: Scrobble: Start
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktEpisodeScrobblePostResponse>> StartEpisodeAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
            => StartEpisodeImplAsync(episodeScrobblePost, cancellationToken);

        /// <summary>Pauses watching a <see cref="TraktEpisode" /> in a media center.</summary>
        /// <param name="episodeScrobblePost">An <see cref="TraktEpisodeScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the successfully scrobbled episode's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeScrobblePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postscrobblepause">
        /// Trakt API Documentation: Scrobble: Pause
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktEpisodeScrobblePostResponse>> PauseEpisodeAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
            => PauseEpisodeImplAsync(episodeScrobblePost, cancellationToken);

        /// <summary>Stops watching a <see cref="TraktEpisode" /> in a media center.</summary>
        /// <param name="episodeScrobblePost">An <see cref="TraktEpisodeScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse{TResponseContentType}" /> containing the successfully scrobbled episode's data.
        /// <para />
        /// See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktEpisodeScrobblePostResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postscrobblestop">
        /// Trakt API Documentation: Scrobble: Stop or Finish
        /// </see></para>
        /// </remarks>>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<TraktEpisodeScrobblePostResponse>> StopEpisodeAsync(TraktEpisodeScrobblePost episodeScrobblePost,
            CancellationToken cancellationToken = default)
            => StopEpisodeImplAsync(episodeScrobblePost, cancellationToken);
    }
}
