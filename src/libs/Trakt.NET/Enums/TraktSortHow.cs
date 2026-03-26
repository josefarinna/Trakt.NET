namespace TraktNET
{
    /// <summary>Determines how items are ordered.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktSortHow
    {
        /// <summary>An invalid sort-how type.</summary>
        Unspecified,

        /// <summary>Items are ordered in ascending order.</summary>
        [TraktEnumMember(JsonValue = "asc")]
        Ascending,

        /// <summary>Items are ordered in descending order.</summary>
        [TraktEnumMember(JsonValue = "desc")]
        Descending
    }
}
