namespace TraktNET
{
    /// <summary>Determines the privacy of a list.</summary>
    [TraktEnum]
    public enum TraktListPrivacy
    {
        /// <summary>An invalid privacy type.</summary>
        Unspecified,

        /// <summary>The list is private. Only the user who created the list can see it.</summary>
        Private,

        /// <summary>The list is only viewable by a shared link.</summary>
        Link,

        /// <summary>The list can only be seen by friends.</summary>
        Friends,

        /// <summary>The list is public and anyone can see it.</summary>
        Public
    }
}
