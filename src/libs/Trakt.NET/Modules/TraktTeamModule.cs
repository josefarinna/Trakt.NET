namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to the Trakt team.
    /// <para>This module contains all methods of the "Trakt API Documentation - Team" section.</para>
    /// </summary>
    public sealed partial class TraktTeamModule
    {
        /// <summary>Gets Trakt team members.</summary>
        /// <param name="extendedInfo">
        /// Specifies how much data should be queried about the team members.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried team members.
        /// <para>See also <seealso cref="TraktListResponse{TResponseContentType}" /> and <seealso cref="TraktTeamMember" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getteammembers">
        /// Trakt API Documentation: Team: Members
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<TraktTeamMember>> GetTeamMembersAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetTeamMembersImplAsync(extendedInfo, cancellationToken);
    }
}
