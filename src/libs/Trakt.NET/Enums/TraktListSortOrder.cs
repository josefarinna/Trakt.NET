namespace TraktNET
{
    ///// <summary>Determines the sort order for lists of <see cref="ITraktList" />.</summary>
    [TraktEnum]
    public enum TraktListSortOrder
    {
        /// <summary>An invalid sort order.</summary>
        Unspecified,

        /// <summary>Lists will be sorted by the most popular first.</summary>
        Popular,

        /// <summary>Lists will be sorted by the number of likes first.</summary>
        Likes,

        /// <summary>Lists will be sorted by the number of comments first.</summary>
        Comments,

        /// <summary>Lists will be sorted by the number of items first.</summary>
        Items,

        ///// <summary>Lists will be sorted by <see cref="ITraktList.CreatedAt" /> first.</summary>
        Added,

        ///// <summary>Lists will be sorted by <see cref="ITraktList.UpdatedAt" /> first.</summary>
        Updated
    }
}
