namespace TraktNET
{
    /// <summary>Represents a Trakt user comment reaction item.</summary>
    public record class TraktCommentUserReaction
    {
        /// <summary>Gets or sets the UTC datetime when the reaction was added.</summary>
        public DateTime? ReactedAt { get; set; }

        /// <summary>Gets or sets the reaction details.</summary>
        public TraktCommentReaction? Reaction { get; set; }

        /// <summary>Gets or sets the user who added the reaction.</summary>
        public TraktUser? User { get; set; }
    }
}
