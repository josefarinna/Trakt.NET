namespace TraktNET
{
    /// <summary>Determines the type of an object in an hidden item.</summary>
    [TraktEnum]
    public enum TraktHiddenItemType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The hidden item contains a movie.</summary>
        Movie,

        /// <summary>The listhidden item contains a show.</summary>
        Show,

        /// <summary>The hidden item contains a season.</summary>
        Season,

        /// <summary>The hidden item contains a user.</summary>
        User
    }
}
