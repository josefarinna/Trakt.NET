namespace TraktNET
{
    /// <summary>Determines how items are ordered.</summary>
    [TraktEnum]
    public enum TraktSortHow
    {
        /// <summary>An invalid sort-how type.</summary>
        Unspecified,

        /// <summary>Items are ordered in ascending order.</summary>
        [TraktEnumMember("asc")]
        Ascending,

        /// <summary>Items are ordered in descending order.</summary>
        [TraktEnumMember("desc")]
        Descending
    }
}
