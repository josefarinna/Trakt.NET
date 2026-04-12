namespace TraktNET
{
    /// <summary>Represents the response for the approve of a follower request.</summary>
    public record class TraktUserFollowUserPostResponse
    {
        /// <summary>Gets or sets the UTC datetime, when the follower request was approved.</summary>
        public DateTime? ApprovedAt { get; set; }

        /// <summary>Gets or sets the <see cref="TraktUser" />, who was approved.</summary>
        public TraktUser? User { get; set; }
    }
}
