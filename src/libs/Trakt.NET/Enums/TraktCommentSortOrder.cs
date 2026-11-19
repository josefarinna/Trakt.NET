namespace TraktNET
{
    /// <summary>Determines the sort order for comments.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktCommentSortOrder
    {
        /// <summary>An invalid sort order.</summary>
        Unspecified,

        /// <summary>Comments will be sorted by newest comments first.</summary>
        Newest,

        /// <summary>Comments will be sorted by oldest comments first.</summary>
        Oldest,

        /// <summary>Comments will be sorted by the number of likes first.</summary>
        Likes,

        /// <summary>Comments will be sorted by the number of replies first.</summary>
        Replies,

        /// <summary>Comments will be sorted by highest author rating first (only supported for movie, show, season, and episode comments).</summary>
        Highest,

        /// <summary>Comments will be sorted by lowest author rating first (only supported for movie, show, season, and episode comments).</summary>
        Lowest,

        /// <summary>Comments will be sorted by the author's number of plays first (only supported for movie, show, season, and episode comments).</summary>
        Plays
    }
}
