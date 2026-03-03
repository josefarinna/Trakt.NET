namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to languages.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/languages">"Trakt API Documentation - Languages"</a> section.
    /// </summary>
    public sealed partial class TraktLanguagesModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktLanguage>> GetLanguagesImplAsync(TraktLanguageItemType languageType, CancellationToken cancellationToken = default)
        {
            var request = new ListLanguagesGetRequest
            {
                LanguageType = languageType
            };

            return RequestHandler.ExecuteListRequestAsync<TraktLanguage>(_context, request, cancellationToken);
        }
    }
}
