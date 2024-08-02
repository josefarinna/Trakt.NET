namespace TraktNET
{
    public partial class TraktMoviesModule
    {
        private Task<TraktResponse<TraktMovie>> GetMovieImplAsync(string movieIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MovieGetRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktMovie, MovieGetRequest>(_context, request, cancellationToken);
        }
    }
}
