namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to users.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/users">"Trakt API Documentation - Users"</a> section.
    /// </summary>
    public sealed partial class TraktUsersModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktList>> GetPersonalListImplAsync(string usernameOrSlug, string listIdOrSlug,
            CancellationToken cancellationToken = default)
        {
            var request = new UserPersonalSingleListGetRequest
            {
                Id = usernameOrSlug,
                ListId = listIdOrSlug
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktList>(_context, request, cancellationToken);
        }
    }
}
