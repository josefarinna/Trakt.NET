namespace TraktNET
{
    /// <summary>A Trakt team member.</summary>
    public record class TraktTeamMember
    {
        /// <summary>Gets or sets the user object of the team member. See also <seealso cref="TraktUser" />.</summary>
        public TraktUser? User { get; set; }
    }
}
