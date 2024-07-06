namespace TraktNET
{
    /// <summary>Determines the type of an object in a list item.</summary>
    [TraktEnum]
    public enum TraktListItemType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The list item contains a movie.</summary>
        Movie,

        /// <summary>The list item contains a show.</summary>
        Show,

        /// <summary>The list item contains a season.</summary>
        Season,

        /// <summary>The list item contains an episode.</summary>
        Episode,

        /// <summary>The list item contains a person.</summary>
        Person
    }
}
