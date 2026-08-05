namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to genres.
    /// <para>This module contains all methods of the "Trakt API Documentation - Genres" section.</para>
    /// </summary>
    public sealed partial class TraktGenresModule(TraktContext context) : BaseModule(context)
    {
        private async Task<TraktListResponse<TraktGenre>> GetMovieGenresImplAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new GenresMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            TraktListResponse<TraktGenre> response = await RequestHandler.ExecuteListRequestAsync<TraktGenre>(_context, request, cancellationToken);

            if (response)
            {
                foreach (TraktGenre genre in response)
                    genre.Type = TraktGenreType.Movies;
            }

            return response;
        }

        private async Task<TraktListResponse<TraktGenre>> GetShowGenresImplAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new GenresShowsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            TraktListResponse<TraktGenre> response = await RequestHandler.ExecuteListRequestAsync<TraktGenre>(_context, request, cancellationToken);

            if (response)
            {
                foreach (TraktGenre genre in response)
                    genre.Type = TraktGenreType.Shows;
            }

            return response;
        }
    }
}
