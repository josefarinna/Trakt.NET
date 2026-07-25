namespace TraktNET
{
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
