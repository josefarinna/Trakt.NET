namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to movies.<para />
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/movies">"Trakt API Documentation - Movies"</a> section.
    /// </summary>
    public sealed partial class TraktMoviesModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktMovie>> GetMovieImplAsync(string movieIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieGetRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovie>(_context, request, cancellationToken);
        }
    }
}
