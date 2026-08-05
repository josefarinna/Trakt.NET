namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to the Trakt team.
    /// <para>This module contains all methods of the "Trakt API Documentation - Team" section.</para>
    /// </summary>
    public sealed partial class TraktTeamModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktListResponse<TraktTeamMember>> GetTeamMembersImplAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new TeamMembersGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteListRequestAsync<TraktTeamMember>(_context, request, cancellationToken);
        }
    }
}
