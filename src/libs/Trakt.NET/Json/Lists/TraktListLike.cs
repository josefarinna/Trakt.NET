namespace TraktNET
{
    /// <summary>Represents a Trakt user list like.</summary>
    public class TraktListLike
    {
        /// <summary>Gets or sets the UTC datetime, when the list was liked.</summary>
        public DateTime? LikedAt { get; set; }

        /// <summary>Gets or sets the Trakt user who liked the list. See also <seealso cref="TraktUser" />.</summary>
        public TraktUser? User { get; set; }
    }
}
