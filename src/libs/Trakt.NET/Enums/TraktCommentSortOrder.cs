namespace TraktNET
{
    /// <summary>Determines the sort order for comments.</summary>
    [TraktEnum]
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

        /// <summary>Comments will be sorted by highest comments first.</summary>
        Highest,

        /// <summary>Comments will be sorted by lowest comments first.</summary>
        Lowest,

        /// <summary>Comments will be sorted by the number of plays first.</summary>
        Plays,

        /// <summary>Comments will be sorted by most watched first.</summary>
        Watched
    }
}
