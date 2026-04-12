namespace TraktNET
{
    /// <summary>A Trakt user friend.</summary>
    public record class TraktUserFriend : TraktCollectionUser
    {
        /// <summary>Gets or sets the UTC datetime, when the relationship began.</summary>
        public DateTime? FriendsAt { get; set; }
    }
}
