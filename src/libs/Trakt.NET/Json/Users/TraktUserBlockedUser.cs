namespace TraktNET
{
    /// <summary>A Trakt blocked user.</summary>
    public record class TraktUserBlockedUser : TraktCollectionUser
    {
        /// <summary>Gets or sets the UTC datetime when the user was blocked.</summary>
        public DateTime? BlockedAt { get; set; }
    }
}
