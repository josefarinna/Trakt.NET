namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to checkins.<para />
    /// This module contains all methods of the <a href="https://docs.trakt.tv/reference/about-checkin">"Trakt API Documentation - Checkin"</a> section.
    /// </summary>
    public sealed partial class TraktCheckinsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktMovieCheckinResponse>> CheckIntoMovieImplAsync(TraktMovieCheckin movieCheckin, CancellationToken cancellationToken = default)
        {
            var request = new CheckinPostRequest
            {
                TraktCheckin = movieCheckin,
                Flags = new RequestFlags { IsCheckinRequest = true }
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieCheckinResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeCheckinResponse>> CheckIntoEpisodeImplAsync(TraktEpisodeCheckin episodeCheckin, CancellationToken cancellationToken = default)
        {
            var request = new CheckinPostRequest
            {
                TraktCheckin = episodeCheckin,
                Flags = new RequestFlags { IsCheckinRequest = true }
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktEpisodeCheckinResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> DeleteAnyActiveCheckinsImplAsync(CancellationToken cancellationToken = default)
        {
            var request = new CheckinDeleteRequest
            {
                Flags = new RequestFlags { IsCheckinRequest = true }
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }
    }
}
