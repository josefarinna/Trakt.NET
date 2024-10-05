namespace TraktNET
{
    /// <summary>A Trakt user statistics for a comment or reply.</summary>
    public record class TraktCommentUserStats
    {
        /// <summary>The user rating for the comment.</summary>
        public uint? Rating { get; set; }

        /// <summary>The user play count for the comment.</summary>
        public uint? PlayCount { get; set; }

        /// <summary>The user completed count for the comment.</summary>
        public uint? CompletedCount { get; set; }
    }
}
