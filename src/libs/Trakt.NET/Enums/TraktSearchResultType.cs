namespace TraktNET
{
    /// <summary>Determines the type of an object in a search result.</summary>
    [TraktEnum]
    public enum TraktSearchResultType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The search result contains a movie.</summary>
        Movie,

        /// <summary>The search result contains a show.</summary>
        Show,

        /// <summary>The search result contains an episode.</summary>
        Episode,

        /// <summary>The search result contains a person.</summary>
        Person,

        /// <summary>The search result contains a list.</summary>
        List
    }
}
