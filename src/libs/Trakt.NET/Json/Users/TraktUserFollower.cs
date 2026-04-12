namespace TraktNET
{
    /// <summary>A Trakt user follower.</summary>
    public record class TraktUserFollower : TraktCollectionUser
    {
        /// <summary>Gets or sets the UTC datetime, when the relationship began.</summary>
        public DateTime? FollowedAt { get; set; }
    }
}
