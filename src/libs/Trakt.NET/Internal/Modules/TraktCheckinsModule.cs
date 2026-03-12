using System.Net.Http.Json;

namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to checkins.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/checkin">"Trakt API Documentation - Checkin"</a> section.
    /// </summary>
    public sealed partial class TraktCheckinsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktMovieCheckinResponse>> CheckIntoMovieImplAsync(TraktMovieCheckin movieCheckin, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieCheckin);
            ArgumentValidator.ThrowIfNull(movieCheckin.Movie);
            ArgumentValidator.ThrowIfNull(movieCheckin.Movie.IDs);
            if (!movieCheckin.Movie!.IDs!.HasAnyID)
            {
                throw new ArgumentException($"{nameof(movieCheckin)} has not any IDs set", nameof(movieCheckin));
            }

            var request = new CheckinPostRequest
            {
                Content = JsonContent.Create(movieCheckin),
                Flags = new RequestFlags { IsCheckinRequest = true }
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovieCheckinResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktEpisodeCheckinResponse>> CheckIntoEpisodeImplAsync(TraktEpisodeCheckin episodeCheckin, CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(episodeCheckin);
            ArgumentValidator.ThrowIfNull(episodeCheckin.Episode);
            ArgumentValidator.ThrowIfNull(episodeCheckin.Episode.IDs);
            if (!episodeCheckin.Episode!.IDs!.HasAnyID)
            {
                throw new ArgumentException($"{nameof(episodeCheckin)} has not any IDs set", nameof(episodeCheckin));
            }

            var request = new CheckinPostRequest
            {
                Content = JsonContent.Create(episodeCheckin),
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
