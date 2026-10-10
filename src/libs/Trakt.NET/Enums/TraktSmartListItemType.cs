namespace TraktNET
{
    /// <summary>Determines the item type to narrow a smart list holding both media types.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktSmartListItemType
    {
        /// <summary>An invalid smart list item type.</summary>
        Unspecified,

        /// <summary>All items (movies and shows).</summary>
        All,

        /// <summary>Movies only.</summary>
        Movies,

        /// <summary>Shows only.</summary>
        Shows
    }
}

