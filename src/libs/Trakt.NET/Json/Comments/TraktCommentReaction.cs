namespace TraktNET
{
    /// <summary>Represents a Trakt comment reaction detail.</summary>
    public record class TraktCommentReaction
    {
        /// <summary>Gets or sets the type of reaction.</summary>
        public TraktReactionType? Type { get; set; }
    }
}
