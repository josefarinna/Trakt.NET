namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to languages.
    /// <para>This module contains all methods of the "Trakt API Documentation - Languages" section.</para>
    /// </summary>
    public sealed partial class TraktLanguagesModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktLanguage>> GetMovieLanguagesImplAsync(CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<TraktLanguage>(_context, new LanguagesMoviesGetRequest(), cancellationToken);

        private Task<TraktListResponse<TraktLanguage>> GetShowLanguagesImplAsync(CancellationToken cancellationToken = default)
            => RequestHandler.ExecuteListRequestAsync<TraktLanguage>(_context, new LanguagesShowsGetRequest(), cancellationToken);
    }
}
